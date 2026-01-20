using System.Text.Json;

var Person = new Person { Name = "Anna", Age = 30 };
var User  = new User { Id = 1, Name = "John Doe", IsActive = true, Roles = ["admin", "editor"]};

// Serialisera användarobjektet till JSON
string jsonString = JsonSerializer.Serialize(Person);
Console.WriteLine(jsonString);
string jsonString2 = JsonSerializer.Serialize(User);
Console.WriteLine(jsonString2);

// Deserialisera JSON tillbaka till ett användarobjekt
Person? deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
Console.WriteLine($"Name: {deserializedPerson?.Name}, Age: {deserializedPerson?.Age}");
User? deserializedUser = JsonSerializer.Deserialize<User>(jsonString2);
Console.WriteLine($"Id: {deserializedUser?.Id}, Name: {deserializedUser?.Name} IsActive: {deserializedUser?.IsActive} Roles: {deserializedUser?.Roles}");

Book? deserializedBook = JsonSerializer.Deserialize<Book>(File.ReadAllText("book.json"), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
Console.WriteLine($"Title: {deserializedBook?.Title}, Name: {deserializedBook?.Author} Year: {deserializedBook?.Year} Price: {deserializedBook?.Price} InStock: {deserializedBook?.InStock}");

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<string> Roles { get; set; }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }

}