using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireWebApp.Core.Models;

public class Form : Entity
{
    [ForeignKey("PersonId")]
    public Person Person { get; set; }
    public int PersonId { get; set; }
    
    [ForeignKey("QuestinnaryId")]
    public Questionnaire Questionnaire { get; set; }
    public int QuestinnaryId { get; set; }
    
    public virtual ICollection<FormAnswer> FormAnswers { get; set; }
}