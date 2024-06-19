using RoyalLibrary.Models;

namespace RoyalLibrary.Repositories.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<List<Book>> List();
    Task<Book?> GetById(int id);
}