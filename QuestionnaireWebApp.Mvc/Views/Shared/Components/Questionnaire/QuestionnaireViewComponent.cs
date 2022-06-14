using Microsoft.AspNetCore.Mvc;

namespace QuestionnaireWebApp.Views.Shared.Components.Questionnaire;

public class QuestionnaireViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(QuestionnaireViewModel model)
    {
        return View(model);
    }
}