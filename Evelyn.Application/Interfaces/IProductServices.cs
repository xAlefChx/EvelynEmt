using Evelyn.Application.Requests.ProductRequests;
using Evelyn.Domain.Entities;

namespace Evelyn.Application.Interfaces
{
    public interface IProductServices
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(AddProductRequest request);
        Task<Product> UpdateProductAsync(int productid, UpdateProductRequest request);
        Task<bool> DeleteProductAsync(int id);
    }
}
