using Microsoft.EntityFrameworkCore;
using ScoutMarket.Repository;
using ScoutMarket.Repository.Repository;
using ScoutMarket.Services.Product;
using ScoutMarket.Services.Product.Interfaces;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);

});

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//    );


builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IProductService, ProductService>()
                .AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

//builder.Services.AddControllers();

var app = builder.Build();

var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

//var p = new List<ScoutMarket.Models.Product.Product>()
//            {
//                new() { Id = 0, Name = "Café", Category = 2, Description = "Café Bio Moulu", Gamme = "Café" },
//                new() { Id = 1, Name = "Lait", Category = 3, Description = "Lait Lactel 1L", Gamme = "Lait", Marque = "Lactel" },
//                new() { Id = 2, Name = "Pitch", Category = 4, Description = "Mini brioche pépite de chocolat", Gamme = "Brioche" },
//                new() { Id = 3, Name = "Pâte Spaghetti Panzani", Category = 5, Description = "Pâte Spaghetti Panzani 500g", Gamme = "Pâte" },
//            };


//var todosApi = app.MapGroup("/todos");
//todosApi.MapGet("/", () => sampleTodos);
//todosApi.MapGet("/{id}", (int id) =>
//    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
//        ? Results.Ok(todo)
//        : Results.NotFound());

var product =  app.MapGroup("/products");
product.MapGet("/", async (IProductService ps) => await ps.GetProductsAsync());
product.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());


app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
[JsonSerializable(typeof(List<ScoutMarket.Models.Product>[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
