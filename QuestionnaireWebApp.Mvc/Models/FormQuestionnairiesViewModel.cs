using QuestionnaireWebApp.Core.Enums;

namespace QuestionnaireWebApp.Models;

public class FormQuestionnairiesViewModel
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Sex Sex { get; set; }
    public string QuestionnaireName { get; set; }
    public int Id { get; set; }
}