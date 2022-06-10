using AutoMapper;
using QuestionnaireWebApp.Core.Models;

namespace QuestinaryWebApp.Dto;

public class FormDto //Символизирует пройденный опрос
{
    public PersonDto Person { get; set; }
    public int QuestionnaireId { get; set; }
    public IEnumerable<FormAnswerDto> Answers { get; set; }
}

[AutoMap(typeof(FormAnswer), ReverseMap = true)]
public class FormAnswerDto
{
    public int? AnswerId { get; set; }
    public int QuestionId { get; set; }
    public string OurAnswer { get; set; }
    public QuestionDto Question { get; set; }
    public VariantAnswerDto Answer { get; set; }
}