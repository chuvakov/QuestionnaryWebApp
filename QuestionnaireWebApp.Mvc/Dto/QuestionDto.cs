using Newtonsoft.Json;
using QuestionnaireWebApp.Core.Enums;

namespace QuestinaryWebApp.Dto;

public class QuestionDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public QuestionType Type { get; set; }
    public IEnumerable<VariantAnswerDto> VariantAnswers { get; set; }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((QuestionDto) obj);
    }
}