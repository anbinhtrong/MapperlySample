using ProductCatalog.Web.Mappings;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Repositories;
using ProductCatalog.Web.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IProductMapper _mapper;

        public ProductService(IProductRepository repo, IProductMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _repo.GetAll();
            return _mapper.MapToProductViewModelList(products);
        }

        public ProductViewModel GetProduct(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return null;
            return _mapper.MapToProductViewModel(product);
        }

        public void CreateProduct(ProductCreateViewModel model)
        {
            var product = _mapper.MapToProduct(model);
            _repo.Add(product);
        }

        public void UpdateProduct(ProductEditViewModel model)
        {
            var product = _mapper.MapToProduct(model);
            _repo.Update(product);
        }
    }
}
