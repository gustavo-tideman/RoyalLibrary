using RoyalLibrary.Models;

namespace RoyalLibrary.Services.Interfaces;

public interface IBookService : IBaseService<Book>
{
    Task<List<Book>> List();
    Task<Book?> GetById(int id);
}
