using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using GameStore;
using GameStore.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Enabling validation to DTOs
builder.Services.AddValidation();

//Adding GameStore DataBase via extintion of the builder in DataExtention.cs
builder.AddGameStoreDb();

var app = builder.Build();

// Games Endpoints
app.MapGamesEndpoints();

//DB migration before start of the server
app.MigrateDb();

//Start
app.Run();