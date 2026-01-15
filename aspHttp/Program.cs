using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.WebHost.UseUrls("http://0.0.0.0:5050/");

var app = builder.Build();

List<RegistrationData> registrations = [];
RegistrationData data = new("Danpel", "happy@pappy.com");
RegistrationData data2 = new("Mickey", "mickey@disney.com");
registrations.Add(data);
registrations.Add(data2);

app.MapGet("/api/time", () => DateTime.Now.ToLongTimeString());
app.MapGet("/api/registrations", () => registrations);
app.MapPost("/api/registrations", (
    [FromForm]RegistrationData rd) => {
        registrations.Add(rd);
        return Results.Redirect("/index.html");
        }
    ).DisableAntiforgery();

app.UseDefaultFiles();
app.UseStaticFiles();


app.Run();

record RegistrationData(string Name, string Email);