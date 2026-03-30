using AutoMapper;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.ViewModels;
using System;

namespace ProductCatalog.Web.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Category → CategoryViewModel
            CreateMap<Category, CategoryViewModel>();

            // Product → ProductViewModel (có custom logic)
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.PriceDisplay,
                           opt => opt.MapFrom(src =>
                               src.Price.ToString("N0") + " ₫"))
                .ForMember(dest => dest.StockStatus,
                           opt => opt.MapFrom(src =>
                               src.Stock > 0 ? "In stock" : "Out of stock"))
                .ForMember(dest => dest.CreatedAtDisplay,
                           opt => opt.MapFrom(src =>
                               src.CreatedAt.ToString("dd/MM/yyyy")));

            // ProductCreateViewModel → Product (form submit)
            CreateMap<ProductCreateViewModel, Product>()
                .ForMember(dest => dest.Id,
                           opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt,
                           opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsActive,
                           opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}