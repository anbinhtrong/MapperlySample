using AutoMapper;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Repositories;
using ProductCatalog.Web.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _repo.GetAll();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public ProductViewModel GetProduct(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return null;
            return _mapper.Map<ProductViewModel>(product);
        }

        public void CreateProduct(ProductCreateViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            _repo.Add(product);
        }
    }
}