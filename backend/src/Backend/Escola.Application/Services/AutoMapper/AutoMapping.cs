using AutoMapper;
using Escola.Communication.Responses;

namespace Escola.Application.Services.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        //CreateMap<RequestCategoryJson, Domain.Entities.Category>();
    }

    private void DomainToResponse()
    {
        CreateMap<Domain.Entities.Disciplina, ResponseDisciplinaJson>();
        //CreateMap<Domain.Entities.MovieByCategory, ResponseMovieByCategoryJson>();
    }
}
