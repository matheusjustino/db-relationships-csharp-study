using db_relationships_csharp_study.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationServices(builder.Configuration);

var app = builder.Build();

app.ConfigureMiddleware();
app.RegisterEndpoints();

app.Run();
