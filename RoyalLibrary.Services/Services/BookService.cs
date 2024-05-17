using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models;
using RoyalLibrary.Repositories.Interfaces;
using RoyalLibrary.Services.Interfaces;

namespace RoyalLibrary.Services;

public class BookService(IBookRepository repository, IUnitOfWork unitOfWork) : BaseService<Book>(unitOfWork, repository), IBookService
{
    public async Task<List<Book>> List() => await ((IBookRepository)Repository).List();
    public async Task<Book?> GetById(int id) => await ((IBookRepository)Repository).GetById(id);
}