using AutoMapper;
using QuestionnaireWebApp.Core.Enums;
using QuestionnaireWebApp.Core.Models;

namespace QuestinaryWebApp.Dto;

[AutoMap(typeof(Person), ReverseMap = true)]
public class PersonDto
{
    public string Name { get; set; }
    public Sex Sex { get; set; }
    public int Age { get; set; }
}