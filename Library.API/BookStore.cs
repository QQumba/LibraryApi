namespace WeatherApiOnAzure;

public class BookStore
{
    private readonly ILogger<BookStore> _logger;
    private static readonly List<Book> Books = new();

    public BookStore(ILogger<BookStore> logger)
    {
        _logger = logger;
    }
    
    public void AddBook(Book book)
    {
        _logger.LogInformation("Adding new book. Name: '{Name}', Author: '{Author}'", book.Name, book.Author);
        Books.Add(book);
    }
    
    public IEnumerable<Book> GetAllBooks()
    {
        _logger.LogInformation("Getting all books");
        return Books;
    }
}

public class Book
{
    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;
}