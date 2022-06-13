using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestinaryWebApp.Dto;
using QuestionnaireWebApp.Core;
using QuestionnaireWebApp.Core.Models;
using QuestionnaireWebApp.Models;

namespace QuestionnaireWebApp.Controllers;

public class HomeController : Controller
{
    private readonly QuestionnaireContext _context;
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, QuestionnaireContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        try
        {
            //В переменную кладем Запрос на всю колекцию Опросников из БД
            var questionnaire = _context
                .Questionnairees
                .Include(x => x.Questions);

            //Маппим каждый опросник из набора до модели страницы и кладем результат в переменную(набор) моделей
            var model = _mapper.Map<IEnumerable<QuestionnaireViewModel>>(questionnaire);

            //Возвращаем модель (с набором опросников)
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
    }

    [HttpPost]
    public void Delete(int id)
    {
        try
        {
            var questionnaire = _context.Questionnairees.Find(id);
            _context.Questionnairees.Remove(questionnaire);
            _context.SaveChanges();
        
            _logger.LogInformation($"удален опросник с id = {id}");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }
    
    //Кнопка прохождения опросника
    [HttpGet("[controller]/[action]/{id}")]
    public IActionResult FormQuestionnaire(int id)
    {
        try
        {
            var questionnaire = _context.Questionnairees
                .Include(questionnaire => questionnaire.Questions) 
                .ThenInclude(question => question.AnswerVariants)
                .FirstOrDefault(questionnaire => questionnaire.Id == id);

            var questionnaireDto = _mapper.Map<QuestionnaireDto>(questionnaire);
            var model = new FormQuestionnaireViewModel()
            {
                Questionnaire = questionnaireDto
            };

            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
    }
    
    //Сохранение результатов опроса (Кнопка закончить опрос)
    [HttpPost]
    public void SaveFormQuestionnaire(FormDto input)
    {
        try
        {
            var person = _context.Persons.FirstOrDefault(x =>
                x.Name == input.Person.Name && x.Age == input.Person.Age && x.Sex == input.Person.Sex);

            var form = new Form()
            {
                QuestinnaryId = input.QuestionnaireId,
                FormAnswers = _mapper.Map<ICollection<FormAnswer>>(input.Answers)
            };

            if (person is null)
            {
                person = _mapper.Map<Person>(input.Person);
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            form.PersonId = person.Id;
            _context.Forms.Add(form);
            _context.SaveChanges();
        
            _logger.LogInformation($"Сохранение результата опроса {input.QuestionnaireId}");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
        
    }

    //Кнопка скачать опросник
    public IActionResult Download(int id)
    {
        try
        {
            var questionnaire = _context.Questionnairees
                .Include(ques => ques.Questions)
                .ThenInclude(x => x.AnswerVariants)
                .FirstOrDefault(q => q.Id == id);

            if (questionnaire is null)
            {
                _logger.LogWarning($"Не найден опросник с id = {id}");
                return NotFound("Не найден опросник");
            }

            var questionnaireDto = _mapper.Map<QuestionnaireDto>(questionnaire);

            var json = JsonConvert.SerializeObject(questionnaireDto);
            string fileName = questionnaire.Name + ".json";

            //Получаем массив байт в кодировке UTF8 для json строки. Данный массив запишем в файл.
            var bytes = Encoding.UTF8.GetBytes(json);
            var content = new MemoryStream(bytes);
            return File(content, "application/json", fileName);//"application/json" - то же самое чт ои ниже
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
        
    }
    
    //Кнопка загрузить опросник
    public IActionResult Import(IFormFile file)
    {
        if (file == null)
        {
            _logger.LogWarning("Не передан файл");
            return BadRequest("Не передан файл");
        }
        
        //Проверяем что к нам пришел файл в формате Json **тоже самое что и выше
        if (file.ContentType != MediaTypeNames.Application.Json && file.ContentType != MediaTypeNames.Text.Plain)
        {
            _logger.LogWarning("Файл не верного формата");
            return BadRequest("Файл не верного формата");
        }

        try
        {
            string json;
            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                json = sr.ReadToEnd();
            }
        
            var questionnaire = JsonConvert.DeserializeObject<QuestionnaireDto>(json);
            var entity = _mapper.Map<Questionnaire>(questionnaire);
        
            _context.Questionnairees.Add(entity);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest("файл не удалось загрузить");
        }
    }
}