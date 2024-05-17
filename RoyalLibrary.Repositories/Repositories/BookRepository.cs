using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Repositories.Interfaces;

namespace RoyalLibrary.Repositories.Repository;

public class BookRepository(IRoyalLibraryDbContext dbContext) : BaseRepository<Book>(dbContext), IBookRepository
{
    public Task<List<Book>> List() => DbContext.Set<Book>().AsNoTracking().OrderBy(b => b.book_id).ToListAsync();
    public Task<Book?> GetById(int id) => DbContext.Set<Book>().AsNoTracking().SingleOrDefaultAsync(b => b.book_id == id);
}
