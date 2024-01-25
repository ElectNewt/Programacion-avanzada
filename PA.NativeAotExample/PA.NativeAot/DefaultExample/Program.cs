using System.Data.Common;
using DefaultExample.Data;
using DefaultExample.Middlewares;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddScoped<DbConnection>(x =>
        new MySqlConnection(
            "Server=127.0.0.1;Port=3308;Database=db;Uid=user;password=password;"));

builder.Services.AddScoped<ExampleData>();

var app = builder.Build();
app.UseMiddleware<RequestTimeMiddleware>();

var exampleApi = app.MapGroup("/example");
exampleApi.MapGet("/", async ([FromServices] ExampleData data) => await data.GetAll());
exampleApi.MapGet("/{id}", async (int id, [FromServices] ExampleData data) => await data.GetById(id));

app.Run();

public record TableExample(int Column1, string Column2);