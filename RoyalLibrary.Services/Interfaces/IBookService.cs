using RoyalLibrary.Models;
using RoyalLibrary.Models.Handler;

namespace RoyalLibrary.Services.Interfaces;

public interface IBookService : IBaseService<Book>
{
    event BooksRetrievedEventHandler BooksRetrieved;

    Task<List<Book>> List();
    Task<Book?> GetById(int id);
    void OnBooksRetrieved(BooksRetrievedEventArgs booksRetrievedEventArgs);
}
