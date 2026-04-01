using Riok.Mapperly.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Web.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}