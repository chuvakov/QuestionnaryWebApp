using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireWebApp.Core.Models;

public class FormAnswer : Entity
{
    [ForeignKey("FormId")]
    public Form Form { get; set; }
    public int FormId { get; set; }
    
    [ForeignKey("AnswerId")]
    public Answer Answer { get; set; }
    public int? AnswerId { get; set; }
    
    [ForeignKey("QuestionId")]
    public Question Question { get; set; }
    public int QuestionId { get; set; }
    
    public string OurAnswer { get; set; }
}