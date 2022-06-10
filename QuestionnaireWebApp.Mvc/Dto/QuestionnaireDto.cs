using AutoMapper;
using Newtonsoft.Json;
using QuestionnaireWebApp.Core.Models;

namespace QuestinaryWebApp.Dto;

[AutoMap(typeof(Questionnaire), ReverseMap = true)]
public class QuestionnaireDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<QuestionDto> Questions { get; set; }
}