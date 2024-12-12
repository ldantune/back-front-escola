using Escola.Application.Services.AutoMapper;
using Escola.Application.UseCases.Disciplinas.Get;
using Escola.Application.UseCases.Disciplinas.GetByCodDisc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddAutoMapper(services);
        AddUserCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(autoMapperOptions =>
        {
            autoMapperOptions.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUserCases(IServiceCollection services)
    {
        services.AddScoped<IGetDisciplinasUseCase, GetDisciplinasUseCase>();
        services.AddScoped<IGetByCodDisciplinaUseCase, GetByCodDisciplinaUseCase>();
    }
}
