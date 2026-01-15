// See https://aka.ms/new-console-template for more information

using antikvariatet;

AppDbContext db = new();
// db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// db.Add(newPublisher);

Author newAuthor = new() {Name = "J. K. Rowling", AuthorBooks = []};
Book newBook = new() {Title="Harry Potter and the Sorcerer's Stone",  ReleaseYear = 1997, Price = 19.99m, Quality = Quality.New, AuthorId = 1, PublisherId = 2};
Publisher newPublisher = new() {Name="Random House", Books = [newBook]};
AuthorBook newAuthorBook = new() {Books = [newBook], Authors = [newAuthor]};



db.Add(newBook);


db.SaveChanges();

