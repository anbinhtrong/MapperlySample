using ProductCatalog.Web.Mappings;

namespace ProductCatalog.Web.App_Start
{
    public static class MapperlyConfig
    {
        public static IProductMapper Mapper { get; private set; }

        public static void Initialize()
        {
            // Mapperly generates the implementation automatically
            // Just instantiate the mapper - implementation is generated at compile time
            Mapper = new ProductMapper();
        }
    }
}
