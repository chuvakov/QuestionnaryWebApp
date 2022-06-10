using QuestinaryWebApp.Dto;

namespace QuestionnaireWebApp.Models;

public class FormModalViewModel
{
    public PersonDto Person { get; set; }
    public string QuestionnaireName { get; set; }
    public IEnumerable<FormAnswerDto> FormAnswers { get; set; }
}