using minimalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

List<User> allUsers = [];
List<UserService> allRegisteredUsers = [];

app.MapGet("/", () => "Hello User!");


app.MapGet("/users", () => allUsers);
app.MapPost("/users", (User user) => allUsers.Add(user));
app.MapDelete("/users/{id}", (int Id) => allUsers.RemoveAll(x => x.Id == Id));

app.MapGet("/users/register", () => allRegisteredUsers);
app.MapPost("/users/register", (UserRegistrationDto user, UserService userService) => {
    userService.NewUserRegistered(user.Name, user.Password);
    allRegisteredUsers.Add(userService);
});

app.Run();


public class User
{
    public int Id { get; set; } = Random.Shared.Next(100);
    public string Name { get; set; }
}

public record UserRegistrationDto(string Name, string Password);