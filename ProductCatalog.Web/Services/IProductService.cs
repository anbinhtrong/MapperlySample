using ProductCatalog.Web.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProduct(int id);
        void CreateProduct(ProductCreateViewModel model);
        void UpdateProduct(ProductEditViewModel model);
    }
}
