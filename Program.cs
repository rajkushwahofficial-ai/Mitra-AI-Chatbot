using ChatBotProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// OllamaService + HttpClient register
builder.Services.AddHttpClient<OllamaService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();