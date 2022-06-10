using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionnaireWebApp.Core;
using QuestionnaireWebApp.Core.Models;
using QuestionnaireWebApp.Models;

namespace QuestionnaireWebApp.Controllers;

public class FormQuestionnairiesController : Controller
{
    private readonly QuestionnaireContext _context;
    private readonly IMapper _mapper;

    public FormQuestionnairiesController(QuestionnaireContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var forms = _context.Forms
            .Include(x => x.Person)
            .Include(x => x.Questionnaire)
            .ToList();
        
        var model = _mapper.Map<IEnumerable<FormQuestionnairiesViewModel>>(forms);
        return View(model);
    }
    
    [HttpGet("[controller]/[action]/{id}")]
    public IActionResult FormModal(int id)
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
}