using AutoMapper;
using QuestinaryWebApp.Dto;
using QuestionnaireWebApp.Core.Models;

namespace QuestinaryWebApp.Mapping;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<Question, QuestionDto>()
            .ForMember(
                questionDto => questionDto.Name,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(question => question.Text)
            )
            .ForMember(
                questionDto => questionDto.VariantAnswers,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(question => question.AnswerVariants)
            ).ReverseMap();

        CreateMap<Answer, VariantAnswerDto>()
            .ForMember(
                variantAnswerDto => variantAnswerDto.Name,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(answer => answer.Text)
            ).ReverseMap();
    }
}