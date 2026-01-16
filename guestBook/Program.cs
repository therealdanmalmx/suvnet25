using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5050/");

List<GuestList> guests = [];

GuestList newGuest = new("Mike Spike", "Need extra peanuts");

guests.Add(newGuest);

var app = builder.Build();

app.MapGet("/api/guests", () => guests);
app.MapPost("/api/guests", ([FromForm]GuestList gl) => {
    guests.Add(gl);
    return Results.Redirect("/index.html");
}).DisableAntiforgery();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

record GuestList (string name, string message);