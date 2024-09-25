using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.ProductRequests;
using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly Context _context;

        public ProductServices(Context context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(AddProductRequest request)
        {
            Product product = new Product()
            {
                ProductSerial= request.ProductSerial,
                ProductModel= request.ProductModel,
                DateOfPurchase= request.DateOfPurchase,
                ProjectId = request.ProjectId,
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> UpdateProductAsync(int productid, UpdateProductRequest request)
        {
            var product = await _context.Products.FindAsync(productid);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.ProductSerial = request.ProductSerial;
            product.ProductModel = request.ProductModel;
            product.DateOfPurchase = request.DateOfPurchase;
            product.ProjectId = request.ProjectId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}