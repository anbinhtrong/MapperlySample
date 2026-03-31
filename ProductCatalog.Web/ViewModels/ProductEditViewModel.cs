using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Web.ViewModels
{
    public class ProductEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mô tả sản phẩm là bắt buộc")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Tồn kho là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Tồn kho không được âm")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
