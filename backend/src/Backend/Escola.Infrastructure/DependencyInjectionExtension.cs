using Escola.Domain.Repositories;
using Escola.Domain.Repositories.Disciplina;
using Escola.Infrastructure.DataAccess;
using Escola.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDisciplineReadOnlyRepository, DisciplineRepository>();

        
    }
}
