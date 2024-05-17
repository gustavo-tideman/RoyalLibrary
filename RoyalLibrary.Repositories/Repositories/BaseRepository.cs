using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Repositories.Interfaces;

namespace RoyalLibrary.Repositories.Repository;

public class BaseRepository<TEntity>(IRoyalLibraryDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly IRoyalLibraryDbContext DbContext = dbContext;
}
