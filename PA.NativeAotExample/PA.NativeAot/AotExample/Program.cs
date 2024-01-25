using System.Data.Common;
using System.Text.Json.Serialization;
using AotExample.Data;
using AotExample.Middlewares;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services
    .AddScoped<DbConnection>(x =>
        new MySqlConnection(
            "Server=127.0.0.1;Port=3308;Database=db;Uid=user;password=password;"));

builder.Services.AddScoped<ExampleData>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();
app.UseMiddleware<RequestTimeMiddleware>();

var exampleApi = app.MapGroup("/example");
exampleApi.MapGet("/", async ([FromServices] ExampleData data) => await data.GetAll());
exampleApi.MapGet("/{id}", async (int id, [FromServices] ExampleData data) => await data.GetById(id));


app.Run();

public record TableExample(int Column1, string Column2);

[JsonSerializable(typeof(TableExample[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
