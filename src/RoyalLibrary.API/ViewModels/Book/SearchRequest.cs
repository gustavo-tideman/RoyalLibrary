namespace RoyalLibrary.API.ViewModels.Book;

public record SearchRequest
{
    public string searchType;
    public string searchTerm;
}