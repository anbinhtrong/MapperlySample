using ProductCatalog.Web.Models;
using System.Collections.Generic;

namespace ProductCatalog.Web.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
    }
}