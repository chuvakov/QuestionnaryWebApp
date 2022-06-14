using Microsoft.AspNetCore.Mvc;

namespace QuestinaryWebApp.Views.Shared.Components.FormQuestionnaire;

public class FormQuestionnaireViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FormQuestionnaireViewModel model)
    {
        return View(model);
    }
}