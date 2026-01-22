using BookAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5165/");

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=servers.db"));
var app = builder.Build();

using var scope = app.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.EnsureCreated();

// List<Book> allBooks = [];
Book newBook = new Book {Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Year = 1997};
Book newBook2 = new Book {Title = "Harry Potter and the Chamber of Secrets ", Author = "J.K. Rowling", Year = 1998};

// allBooks.Add(newBook);
// allBooks.Add(newBook2);

app.MapGet("/api", () => "running");
app.MapGet("/api/books", async (AppDbContext db) => {
    return await db.Books.ToListAsync();
});
app.MapGet("/api/books/{id}", async (AppDbContext db, int id) => await db.Books.FindAsync(id));

app.MapGet($"/api/books/search", async (AppDbContext db, [FromQuery] string a) => {
    var dbBooks = await db.Books.ToListAsync();
    if (dbBooks == null)
    return;
    dbBooks.Where(x => x.Author.Contains(a, StringComparison.CurrentCultureIgnoreCase));
});

app.MapPost("/api/books", async (AppDbContext db, Book book) => {
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"{book.Title} was created", book);
});

app.MapPost("/api/books/register", (BookService bookService, Book book) => {
    bookService.NewBook(Title: book.Title, Author: book.Author, Year: book.Year);
});

app.Run();
