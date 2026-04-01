using Riok.Mapperly.Abstractions;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Web.Mappings
{
    public interface IProductMapper
    {
        // ===== Category Mappings =====
        CategoryViewModel MapToCategoryViewModel(Category category);
        Category MapToCategory(CategoryViewModel categoryViewModel);

        // ===== Product → ProductViewModel =====
        ProductViewModel MapToProductViewModel(Product product);

        // ===== ProductCreateViewModel → Product =====
        Product MapToProduct(ProductCreateViewModel model);

        // ===== ProductEditViewModel → Product =====
        Product MapToProduct(ProductEditViewModel model);

        // ===== Product → ProductEditViewModel =====
        ProductEditViewModel MapToProductEditViewModel(Product product);

        // ===== Collections =====
        IEnumerable<ProductViewModel> MapToProductViewModelList(IEnumerable<Product> products);
    }
}
