﻿namespace Escola.Domain.Repositories;
public interface IUnitOfWork
{
    public Task Commit();
}
