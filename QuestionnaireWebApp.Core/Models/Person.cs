using QuestionnaireWebApp.Core.Enums;

namespace QuestionnaireWebApp.Core.Models;

public class Person : Entity
{
    public string Name { get; set; }
    public Sex Sex { get; set; }
    public int Age { get; set; }
}