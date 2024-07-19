using ScoutMarket.Repository;
using ScoutMarket.Services.Product.Interfaces;

namespace ScoutMarket.Services.Product
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productrepository;
        public ProductService(IProductRepository productService)
        {
                _productrepository = productService;
        }
        public Task<Models.Product> AddProductAsync(Models.Product product)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditProductAsync(Models.Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Product>> GetProductsAsync()
        {
            _productrepository.GetData();
            return Task.FromResult(new List<Models.Product>()
            {
                new() { Id = 0, Name = "Café", Category = 2, Description = "Café Bio Moulu", Gamme = "Café" },
                new() { Id = 1, Name = "Lait", Category = 3, Description = "Lait Lactel 1L", Gamme = "Lait", Marque = "Lactel" },
                new() { Id = 2, Name = "Pitch", Category = 4, Description = "Mini brioche pépite de chocolat", Gamme = "Brioche" },
                new() { Id = 3, Name = "Pâte Spaghetti Panzani", Category = 5, Description = "Pâte Spaghetti Panzani 500g", Gamme = "Pâte" },
            });
        }
    }
}
