using System;

namespace ProductCatalog.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PriceDisplay { get; set; }      // "1.500.000 ₫"  ← format from decimal
        public string StockStatus { get; set; }       // "Còn hàng" or "Hết hàng"
        public string CategoryName { get; set; }      // flatten from Category.Name
        public bool IsActive { get; set; }
        public string CreatedAtDisplay { get; set; }  // "21/05/2025"
    }
}