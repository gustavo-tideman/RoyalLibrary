namespace RoyalLibrary.Models.Handler;

public class BooksRetrievedEventArgs : EventArgs
{
    public List<Book> Books { get; }

    public BooksRetrievedEventArgs(List<Book> books)
    {
        Books = books;
    }
}
