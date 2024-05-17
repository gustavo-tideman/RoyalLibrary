using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models;
using RoyalLibrary.Models.Handler;
using RoyalLibrary.Repositories.Interfaces;
using RoyalLibrary.Services.Interfaces;

namespace RoyalLibrary.Services;

public class BookService : BaseService<Book>, IBookService
{
    public event BooksRetrievedEventHandler? BooksRetrieved;

    public BookService(IBookRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork, repository)
    {

    }

    public async Task<List<Book>> List()
    {
        return await ((IBookRepository)Repository).List();
    }

    public async Task<Book?> GetById(int id)
    {
        return await ((IBookRepository)Repository).GetById(id);
    }

    public void OnBooksRetrieved(BooksRetrievedEventArgs e)
    {
        BooksRetrieved?.Invoke(this, e);
    }
}
