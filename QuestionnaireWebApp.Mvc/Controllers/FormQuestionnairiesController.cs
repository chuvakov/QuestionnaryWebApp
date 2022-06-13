using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestinaryWebApp.Extensions;
using QuestionnaireWebApp.Core;
using QuestionnaireWebApp.Models;

namespace QuestionnaireWebApp.Controllers;

public class FormQuestionnairiesController : Controller
{
    private readonly QuestionnaireContext _context;
    private readonly ILogger<FormQuestionnairiesController> _logger;
    private readonly IMapper _mapper;

    public FormQuestionnairiesController(
        QuestionnaireContext context,
        IMapper mapper,
        ILogger<FormQuestionnairiesController> logger
    )
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public IActionResult Index()
    {
        try
        {
            var forms = _context.Forms
                .Include(x => x.Person)
                .Include(x => x.Questionnaire)
                .ToList();

            var model = _mapper.Map<IEnumerable<FormQuestionnairiesViewModel>>(forms);
            return View(model);
        }
        catch (Exception e)
        {
            _logger.Error(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[controller]/[action]/{id}")]
    public IActionResult FormModal(int id)
    {
        try
        {
            var form = _context.Forms
                .Include(x => x.Questionnaire)
                .ThenInclude(x => x.Questions)
                .Include(x => x.Person)
                .Include(x => x.FormAnswers)
                .ThenInclude(x => x.Answer)
                .Include(x => x.FormAnswers)
                .ThenInclude(x => x.Question)
                .FirstOrDefault(x => x.Id == id);

            var model = _mapper.Map<FormModalViewModel>(form);
            return View("_FormModal", model);
        }
        catch (Exception e)
        {
            _logger.Error(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
    }
}