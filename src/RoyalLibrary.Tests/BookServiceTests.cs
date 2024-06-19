using Moq;
using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models;
using RoyalLibrary.Repositories.Interfaces;
using RoyalLibrary.Services;
using RoyalLibrary.Tests.Fixture;

namespace RoyalLibrary.Tests;

public class BookServiceTests : BookFixture
{
    [Fact]
    public async Task List_ShouldReturnListOfBooks()
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var bookService = new BookService(bookRepositoryMock.Object, unitOfWorkMock.Object);
        var expectedBooks = new List<Book>();

        bookRepositoryMock.Setup(repo => repo.List()).ReturnsAsync(expectedBooks);

        // Act
        var result = await bookService.List();

        // Assert
        Assert.Equal(expectedBooks, result);
    }

    [Fact]
    public async Task GetById_WithValidId_ShouldReturnBook()
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var bookService = new BookService(bookRepositoryMock.Object, unitOfWorkMock.Object);
        var expectedBook = CreateBookForTest();

        bookRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(expectedBook);

        // Act
        var result = await bookService.GetById(1);

        // Assert
        Assert.Equal(expectedBook, result);
    }

    [Fact]
    public async Task GetById_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var bookService = new BookService(bookRepositoryMock.Object, unitOfWorkMock.Object);

        bookRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Book)null);

        // Act
        var result = await bookService.GetById(1);

        // Assert
        Assert.Null(result);
    }
}