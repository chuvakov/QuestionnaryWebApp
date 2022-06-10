using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireWebApp.Core.Models;

public class Answer : Entity
{
    public virtual int Number { get; set; }
    public virtual string Text { get; set; }
    
    [ForeignKey("QuestionId")]
    public virtual Question Question { get; set; }
    
    public virtual int QuestionId { get; set; }
    
    [ForeignKey("ExtraQuestionId")]
    public virtual Question ExtraQuestion { get; set; }
    public virtual int? ExtraQuestionId { get; set; }
    
    public bool IsExistExtraQuestion() => ExtraQuestionId.HasValue;

    public override string ToString()
    {
        return $"{Number}: {Text}";
    }
}