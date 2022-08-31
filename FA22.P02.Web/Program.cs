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
int myId = 1;
var products = new List<ProductDto> {
    new ProductDto {
        Id = myId++,
        ProductName = "Monster Energy Drink",
        Description = "caffeine beverage",
        Price = 3.09m
    },
    new ProductDto {
        Id = myId++,
        ProductName = "Pencil Pack",
        Description = "pack of 5 mechanical pencils",
        Price = 6.11m
    },
    new ProductDto {
        Id = myId++,
        ProductName = "M&M's",
        Description = "regular size pack of m&m's",
        Price = 1.68m
    }
};

//Get All Products
app.MapGet("/api/products", () => {
    return products;
})
.Produces(200, typeof(ProductDto[]));

//Get By ID Endpoint
app.MapGet("/api/products{id}", (int id) => {
    var results = products.FirstOrDefault(x => x.Id == id);
    if(results == null) {    
        return Results.NotFound();
    }
    return Results.Ok(results);
})
.WithName("GetById");

//Create Product Endpoint
app.MapPost("/api/products/", (ProductDto product) => {
    if(product.Id == 0 || product.ProductName == null || product.Description == null || product.Price <= 0) {
        return Results.BadRequest();
    }
    product.Id = myId++;
    products.Add(product);
    return Results.CreatedAtRoute("GetById", new{id = product.Id}, product);
})
.Produces(400)
.Produces(200, typeof(ProductDto));

//Update Product Endpoint
app.MapPut("/api/products{id}", (int id, ProductDto product) => {
    if(product.Id == 0 || product.ProductName == null || product.Description == null || product.Price <= 0) {
        return Results.BadRequest();
    }

    new ProductDto {
        ProductName = product.ProductName,
        Description = product.Description,
        Price = product.Price,
    };
    var current = Results.CreatedAtRoute("GetById", new {id = product.Id == id}, product);
    products.Remove(product);
    products.Add(product);
    return current;
});

/*Delete Product Endpoint
app.MapDelete("/api/products{id}", (int id, ProductDto product) => {
       var results = products.FirstOrDefault(x => x.Id == id);

    if(results.Equals(product.Id) ) {    
        products.Remove(product);
    }

    return Results.Ok();
})
.Produces(200, typeof(ProductDto[]));
*/

//Run App Command
app.Run();
// Hi 383 - this is added so we can test our web project automatically. More on that later
public partial class Program { }