WebApplicationBuilder builder = WebApplication.CreateBuilder();

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();



app.MapDefaultControllerRoute();

app.Run();