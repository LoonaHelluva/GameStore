using GameStore;
using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

var app = builder.Build();

// Games Endpoints
app.MapGamesEndpoints();

app.Run();