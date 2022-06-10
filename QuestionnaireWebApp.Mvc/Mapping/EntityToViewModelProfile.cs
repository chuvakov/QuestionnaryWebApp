using AutoMapper;
using QuestionnaireWebApp.Core.Models;
using QuestionnaireWebApp.Models;

namespace QuestinaryWebApp.Mapping;

public class EntityToViewModelProfile : Profile
{
    public EntityToViewModelProfile()
    {
        CreateMap<Questionnaire, QuestionnaireViewModel>()
            .ForMember(
                questionnaireViewModel => questionnaireViewModel.AmountQuestion, 
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(questionnaire => questionnaire.Questions.Count)
            );

        CreateMap<Form, FormQuestionnairiesViewModel>()
            .ForMember(
                formQuestionnairiesViewModel => formQuestionnairiesViewModel.Name,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(form => form.Person.Name)
            )
            .ForMember(
                formQuestionnairiesViewModel => formQuestionnairiesViewModel.Age,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(form => form.Person.Age)
            )
            .ForMember(
                formQuestionnairiesViewModel => formQuestionnairiesViewModel.Sex,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(form => form.Person.Sex)
            )
            .ForMember(
                formQuestionnairiesViewModel => formQuestionnairiesViewModel.QuestionnaireName,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(form => form.Questionnaire.Name)
            );

        CreateMap<Form, FormModalViewModel>()
            .ForMember(
                FormModalViewModel => FormModalViewModel.QuestionnaireName,
                memberConfigurationExpression => memberConfigurationExpression
                    .MapFrom(form => form.Questionnaire.Name)
            );
        
        
    }
}