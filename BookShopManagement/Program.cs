using BookShopManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookShopManagement.Repositories;
using BookShopManagement.Infranstructure;
using BookShopManagement.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("api"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BooksService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();


// End points
app.MapGet("/api/getAllBooks", (IBookService bookService) => bookService.GetAllBooks());
app.MapPost("/api/createBook", (IBookService bookService, Request request) => bookService.CreateBooks(request));
app.MapPut("/api/updateBook", (IBookService bookService, Book request) => bookService.UpdateBook(request));
app.MapDelete("/api/deleteBook", (IBookService bookService, int id) => bookService.DeleteBook(id));

app.Run();
