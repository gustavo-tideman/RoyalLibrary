using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Repositories.Interfaces;
using RoyalLibrary.Services.Interfaces;

namespace RoyalLibrary.Services;

public class BaseService<TEntity>(IUnitOfWork unitOfWork, IBaseRepository<TEntity> repository) : IBaseService<TEntity> where TEntity : class
{
    protected readonly IUnitOfWork UnitOfWork = unitOfWork;
    protected readonly IBaseRepository<TEntity> Repository = repository;
}
