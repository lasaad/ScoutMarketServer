using ScoutMarket.Models.Product;

namespace ScoutMarket.Services.Product.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Models.Product.Product>> GetProductsAsync();
        Task<Models.Product.Product> GetProductAsync(int id);
        Task<Models.Product.Product> AddProductAsync(Models.Product.Product product);
        Task<int> EditProductAsync(Models.Product.Product product);
        Task<int> DeleteProductAsync(int id);
    }
} 