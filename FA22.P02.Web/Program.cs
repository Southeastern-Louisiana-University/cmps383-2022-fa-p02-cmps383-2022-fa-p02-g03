//Connect to Product Data Transfer Object
using FA22.P02.Web.DTOs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

//Product List
var products = new List<ProductDto> {
    new ProductDto {
        Id = 1,
        ProductName = "Monster Energy Drink",
        Description = "caffeine beverage",
        Price = 3.09m
    },
    new ProductDto {
        Id = 2,
        ProductName = "Pencil Pack",
        Description = "pack of 5 mechanical pencils",
        Price = 6.11m
    },
    new ProductDto {
        Id = 3,
        ProductName = "M&M's",
        Description = "regular size pack of m&m's",
        Price = 1.68m
    }
};

//Get All Products
app.MapGet("/api/GetAll", () =>
{
    return products;
})
.Produces(200, typeof(ProductDto[]));



//Run App Command
app.Run();
// Hi 383 - this is added so we can test our web project automatically. More on that later
public partial class Program { }