using Microsoft.EntityFrameworkCore;

namespace Escola.Infrastructure.DataAccess;
public class EscolaDbContext : DbContext
{
    public EscolaDbContext(DbContextOptions<EscolaDbContext> options) : base(options)
    { }
}
