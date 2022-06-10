using System.ComponentModel.DataAnnotations.Schema;
using QuestionnaireWebApp.Core.Enums;

namespace QuestionnaireWebApp.Core.Models;

public class Question : Entity
{
    public virtual int Number { get; set; }
    public virtual string Text { get; set; }
    public virtual QuestionType Type { get; set; }
    
    [InverseProperty("Question")]
    public virtual ICollection<Answer> AnswerVariants { get; set; }

    public virtual int QuestionnaireeId { get; set; }
    
    [ForeignKey("QuestionnaireeId")]
    public virtual Questionnaire Questionnaire { get; set; }
}