using ScoutMarket.Models;

namespace ScoutMarket.Services.Product.Interfaces
{
    public interface IProductService
    {
        Task<List<Models.Product>> GetProductsAsync();
        Task<Models.Product> GetProductAsync(int id);
        Task<Models.Product> AddProductAsync(Models.Product product);
        Task<int> EditProductAsync(Models.Product product);
        Task<int> DeleteProductAsync(int id);
    }
} 