using ProductCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Fake in-memory data
        private static readonly List<Category> _categories = new List<Category>
    {
        new Category { Id = 1, Name = "Laptop",      Description = "laptop", IsActive = true },
        new Category { Id = 2, Name = "Phụ kiện",    Description = "Mouse, keyboard...", IsActive = true },
        new Category { Id = 3, Name = "Màn hình",    Description = "Monitor",   IsActive = true },
    };

        private static readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Dell XPS 13",        Price = 25_000_000, Stock = 5,  CategoryId = 1, Category = _categories[0], IsActive = true,  CreatedAt = new DateTime(2025, 1, 10), Description = "Intel Core i7, 16GB RAM" },
        new Product { Id = 2, Name = "Logitech MX Master 3", Price = 1_850_000, Stock = 20, CategoryId = 2, Category = _categories[1], IsActive = true,  CreatedAt = new DateTime(2025, 2, 14), Description = "Chuột không dây cao cấp" },
        new Product { Id = 3, Name = "LG 27UL850",          Price = 12_500_000, Stock = 0,  CategoryId = 3, Category = _categories[2], IsActive = false, CreatedAt = new DateTime(2025, 3, 1),  Description = "4K IPS 27 inch" },
        new Product { Id = 4, Name = "MacBook Pro M3",       Price = 42_000_000, Stock = 3,  CategoryId = 1, Category = _categories[0], IsActive = true,  CreatedAt = new DateTime(2025, 4, 5),  Description = "Apple M3 Pro, 18GB RAM" },
        new Product { Id = 5, Name = "Keychron K2",          Price = 1_650_000, Stock = 15, CategoryId = 2, Category = _categories[1], IsActive = true,  CreatedAt = new DateTime(2025, 5, 1),  Description = "Bàn phím cơ compact" },
    };

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
    }
}