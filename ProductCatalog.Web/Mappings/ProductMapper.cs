using Riok.Mapperly.Abstractions;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Web.Mappings
{
    [Mapper]
    public partial class ProductMapper : IProductMapper
    {
        // ===== Category Mappings =====
        public CategoryViewModel MapToCategoryViewModel(Category category)
        {
            if (category == null) return null;
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public Category MapToCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null) return null;
            return new Category
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name
            };
        }

        // ===== Product → ProductViewModel =====
        public ProductViewModel MapToProductViewModel(Product product)
        {
            if (product == null) return null;

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive,
                // Custom fields
                PriceDisplay = product.Price.ToString("N0") + " ₫",
                StockStatus = product.Stock > 0 ? "Còn hàng" : "Hết hàng",
                CategoryName = product.Category?.Name ?? string.Empty,
                CreatedAtDisplay = product.CreatedAt.ToString("dd/MM/yyyy")
            };

            return viewModel;
        }

        // ===== ProductCreateViewModel → Product =====
        public Product MapToProduct(ProductCreateViewModel model)
        {
            if (model == null) return null;

            var product = new Product
            {
                // Auto-map những properties có cùng tên
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId,

                // Set default values
                Id = 0,  // ID sẽ được tạo tự động bởi database
                IsActive = true,  // Default active
                CreatedAt = DateTime.Now  // Set current date
            };

            return product;
        }

        // ===== ProductEditViewModel → Product =====
        public Product MapToProduct(ProductEditViewModel model)
        {
            if (model == null) return null;

            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                IsActive = model.IsActive
                // Không set CreatedAt - giữ giá trị cũ
            };

            return product;
        }

        // ===== Product → ProductEditViewModel =====
        public ProductEditViewModel MapToProductEditViewModel(Product product)
        {
            if (product == null) return null;

            var viewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                IsActive = product.IsActive,
                // Custom field
                CategoryName = product.Category?.Name ?? string.Empty
                // Categories sẽ được set ở controller
            };

            return viewModel;
        }

        // ===== Collection Mappings =====
        public IEnumerable<ProductViewModel> MapToProductViewModelList(IEnumerable<Product> products)
        {
            if (products == null) return Enumerable.Empty<ProductViewModel>();
            return products.Select(MapToProductViewModel).ToList();
        }
    }
}
