using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product?> GetProduct(int id);
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(int id, Product product);
        public Task<Product?> DeleteProduct(int id);
    }
}