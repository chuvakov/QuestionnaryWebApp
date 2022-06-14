using Microsoft.AspNetCore.Mvc;
using QuestinaryWebApp.Dto;

namespace QuestinaryWebApp.Views.Shared.Components.Question;

public class QuestionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(QuestionViewModel model)
    {
        return View(model);
    }
}