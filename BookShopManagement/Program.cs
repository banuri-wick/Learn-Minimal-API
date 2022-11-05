using BookShopManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookShopManagement.Repositories;
using BookShopManagement.Infranstructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();


// End points
app.MapGet("/GetAllBooks", (IBookService bookService) => bookService.GetAllBooks());

app.Run();
