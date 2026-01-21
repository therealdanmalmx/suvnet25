using System.Net.Http.Json;

using var httpClient = new HttpClient();

// var urlList = "https://www.suvnet.se/api/customers";
// var urlSingle = "https://www.suvnet.se/api/customers/50";
// var responseList = await httpClient.GetFromJsonAsync<IEnumerable<Customer>>(urlList);
// var responseSingle = await httpClient.GetFromJsonAsync<Customer>(urlSingle);
// Console.WriteLine("-----------------------------");
// Console.WriteLine(responseSingle.Name);
// Console.WriteLine("-----------------------------");

// foreach (var item in responseList)
// {
//     Console.WriteLine(item.Name);
// }

// var url = "https://www.suvnet.se/api/products/106";
// var response = await httpClient.GetStringAsync(url);
// Console.WriteLine(response);

// var url = "https://www.suvnet.se/api/customers";
// var newCustomer = new Customer {
//     Name = "Haga Mana",
//     Email = "haga@mana.se",
//     Phone = "0764564543",
//     CreatedAt = DateTime.UtcNow,
//     Address = new Address {Street = "Happystreet, 777", PostalNumber = "12345", City="Happytown", Country="Nowhere"},
//     BirthDate = new DateTime(2000, 05, 05) };

// var postResponse = await httpClient.PostAsJsonAsync(url, newCustomer);

// if (postResponse.IsSuccessStatusCode)
// {
//     var createdCustomer= await postResponse.Content.ReadFromJsonAsync<Customer>();
//     Console.WriteLine(@$"
//         Name: {createdCustomer?.Name},
//         Email: {createdCustomer?.Email}
//         Phone: {createdCustomer?.Phone}
//         Created at: {createdCustomer?.CreatedAt}
//         Street: {createdCustomer?.Address.Street}
//         Postal number: {createdCustomer?.Address.PostalNumber}
//         City: {createdCustomer?.Address.City}
//         Country: {createdCustomer?.Address.Country}
//         BirthDate: {createdCustomer?.BirthDate}
//     ");
// }
// else
// {
//     Console.WriteLine("Error creating todo");
// }

// var url = "https://www.suvnet.se/api/products";
// var newProduct = new Product {
//     Name = "Happy Pen",
//     Description = "Best pen ever created. Like for sure.",
//     Brand = "Bic",
//     Category = "Pen",
//     ImageUrl = "https://pixabay.com/images/download/pen-33237_1920.png",
//     Url = null,
//     DateAdded = DateTime.UtcNow
// };

// var postResponse = await httpClient.PostAsJsonAsync(url, newProduct);

// if (postResponse.IsSuccessStatusCode)
// {
//     var createdProduct= await postResponse.Content.ReadFromJsonAsync<Product>();
//     Console.WriteLine(@$"
//         Name: {createdProduct?.Name},
//         Description: {createdProduct?.Description}
//         Brand: {createdProduct?.Brand}
//         Category: {createdProduct?.Category}
//         ImageUrl: {createdProduct?.ImageUrl}
//         Url: {createdProduct?.Url}
//         DateAddeed: {createdProduct?.DateAdded}
//     ");
// }
// else
// {
//     Console.WriteLine("Error creating todo");
// }


var url = "https://www.suvnet.se/api/products/106/reviews/12";

httpClient.DefaultRequestHeaders.Add("X-Api-Key", "qwerty123456");
var deleteResponse = await httpClient.DeleteAsync(url);



public class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Completed { get; set; }
}


public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public Address Address { get; set; }
    public DateTime BirthDate { get; set; }

}

public class Address
{
    public string Street { get; set; }
    public string PostalNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

}

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }
    public string Url { get; set; }
    public DateTime DateAdded { get; set; }
}

public class Review
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime DateAdded { get; set; }

}