using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using ProductCatalog.Web.Mappings;

namespace ProductCatalog.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMappingProfile>();
            }, NullLoggerFactory.Instance);

            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }
    }
}