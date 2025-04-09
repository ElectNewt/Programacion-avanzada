using System.Threading.Channels;
using ExampleChannels.Data;
using ExampleChannels.Dtos;
using ExampleChannels.Entities;
using ExampleChannels.UseCases;
using ExampleChannels.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<UpdateItem>();
builder.Services.AddScoped<IDatabaseRepository, FakeDatabaseRepository>();
BoundedChannelOptions options = new BoundedChannelOptions(100) {
    FullMode = BoundedChannelFullMode.Wait
};
builder.Services.AddSingleton(Channel.CreateBounded<ItemUpdated>(options));

builder.Services.AddHostedService<ItemUpdatedWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPut("items", async (UpdateItem updateItem, ItemDto itemDto) 
    => await updateItem.Execute(itemDto));

app.Run();

