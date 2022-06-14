using QuestinaryWebApp.Dto;

namespace QuestinaryWebApp.Views.Shared.Components.Question;

public class QuestionViewModel
{
    public QuestionDto Question { get; set; }
    public FormAnswerDto[] SelectedAnswers { get; set; }
}