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
            #region ===== Category Mappings =====

            // ✅ Example 1: Simple mapping with ReverseMap()
            // Category ↔ CategoryViewModel (bidirectional)
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap(); // Creates automatic reverse mapping
                               // Equivalent to: CreateMap<CategoryViewModel, Category>();

            #endregion

            #region ===== Product → ProductViewModel =====

            // ✅ Example 2: Complex ForMember() with custom logic
            // Product → ProductViewModel
            CreateMap<Product, ProductViewModel>()
                // ForMember usage 1: MapFrom with property chaining
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name))
                // Equivalent to attribute: [MapProperty(Source = nameof(Product.Category) + "." + nameof(Category.Name))]

                // ForMember usage 2: MapFrom with expression/calculation
                .ForMember(dest => dest.PriceDisplay,
                           opt => opt.MapFrom(src =>
                               src.Price.ToString("N0") + " ₫"))
                // Equivalent to attribute: [MapProperty(Use = typeof(PriceFormatter))]

                // ForMember usage 3: MapFrom with ternary operator (conditional logic)
                .ForMember(dest => dest.StockStatus,
                           opt => opt.MapFrom(src =>
                               src.Stock > 0 ? "Còn hàng" : "Hết hàng"))
                // Equivalent to attribute: [MapProperty(Use = typeof(StockStatusResolver))]

                // ForMember usage 4: MapFrom with DateTime formatting
                .ForMember(dest => dest.CreatedAtDisplay,
                           opt => opt.MapFrom(src =>
                               src.CreatedAt.ToString("dd/MM/yyyy")));
                // Equivalent to attribute: [MapProperty(Use = typeof(DateFormatter))]

            #endregion

            #region ===== ProductCreateViewModel → Product =====

            // ✅ Example 3: Ignore() for properties that shouldn't be mapped
            // ProductCreateViewModel → Product (form submission)
            CreateMap<ProductCreateViewModel, Product>()
                // Ignore usage 1: Ignore auto-increment ID
                .ForMember(dest => dest.Id,
                           opt => opt.Ignore())
                // Equivalent to attribute: [MapperIgnoreTarget] on Product.Id

                // ForMember usage with constant value
                .ForMember(dest => dest.CreatedAt,
                           opt => opt.MapFrom(_ => DateTime.Now))
                // Equivalent to attribute: [MapProperty(Default = typeof(DateTimeNowProvider))]

                // ForMember with constant value (not from source)
                .ForMember(dest => dest.IsActive,
                           opt => opt.MapFrom(_ => true))
                // Equivalent to attribute: [MapProperty(Default = true)]

                // Ignore usage 2: Ignore nested object (will load separately)
                .ForMember(dest => dest.Category, 
                           opt => opt.Ignore());
                // Equivalent to attribute: [MapperIgnoreTarget] on Product.Category

            #endregion

            #region ===== Product ↔ ProductEditViewModel =====

            // ✅ Example 4: ReverseMap() for bidirectional mapping (Edit scenarios)
            // Product ↔ ProductEditViewModel (for edit form binding)
            CreateMap<Product, ProductEditViewModel>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                // ReverseMap: ProductEditViewModel → Product
                .ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            #endregion
        }
    }

    #region ===== AutoMapper Method Reference =====

    /* 
     * ✅ COMPLETE REFERENCE GUIDE
     * 
     * 1. .ReverseMap()
     *    Purpose: Creates automatic bidirectional mapping
     *    Syntax:  CreateMap<Source, Destination>().ReverseMap();
     *    Result:  Maps both Source→Destination AND Destination→Source
     *    Attribute equivalent: [Mapper] on both classes
     * 
     * 2. .ForMember()
     *    Purpose: Configure how a specific destination member should be mapped
     *    Patterns:
     *      a) MapFrom()     - Map from source property
     *         .ForMember(d => d.Prop, opt => opt.MapFrom(s => s.SourceProp))
     *      b) Constant      - Set constant value
     *         .ForMember(d => d.Prop, opt => opt.MapFrom(_ => true))
     *      c) Expression    - Use custom logic
     *         .ForMember(d => d.Display, opt => opt.MapFrom(s => s.Price.ToString("C")))
     *      d) Resolver      - Use custom resolver class
     *         .ForMember(d => d.Prop, opt => opt.UseValue(defaultValue))
     *    Attribute equivalent: [MapProperty(Source = "..."), [MapProperty(Use = typeof(...)]
     * 
     * 3. .Ignore()
     *    Purpose: Skip mapping a property entirely
     *    Syntax:  .ForMember(d => d.Prop, opt => opt.Ignore())
     *    Use case: 
     *      - Auto-increment IDs (will be generated by DB)
     *      - Nested objects (loaded separately)
     *      - Calculated/read-only properties
     *    Attribute equivalent: [MapperIgnoreTarget]
     * 
     * 4. Chaining
     *    Multiple configurations can be chained:
     *    CreateMap<A, B>()
     *        .ForMember(...)
     *        .ForMember(...)
     *        .Ignore()
     *        .ReverseMap();
     */

    #endregion
}

