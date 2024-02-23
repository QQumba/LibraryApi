using Microsoft.AspNetCore.Mvc;
using WeatherApiOnAzure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookStore>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/api/books", ([FromBody] Book book, [FromServices] BookStore store) =>
{
    store.AddBook(book);
    return Results.NoContent();
});

app.MapGet("/api/books", ([FromServices] BookStore store) =>
{
    var books = store.GetAllBooks();
    return Results.Ok(books);
});

app.Run();