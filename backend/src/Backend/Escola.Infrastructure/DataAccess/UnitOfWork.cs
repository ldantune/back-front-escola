using Escola.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly EscolaDbContext _dbContext;

    public UnitOfWork(EscolaDbContext dbContext) => _dbContext = dbContext;
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
