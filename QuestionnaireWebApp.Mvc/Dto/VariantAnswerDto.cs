using Newtonsoft.Json;

namespace QuestinaryWebApp.Dto;

public class VariantAnswerDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
}