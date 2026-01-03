using QrudNTier.BLL.Implementations;
using QrudNTier.BLL.Interfaces;
using QrudNTier.DAL.Implementation;
using QrudNTier.DAL.Interfaces;

namespace QrudNTier.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Add web-specific dependencies here
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
        return services;
    }
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Add web-specific dependencies here
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
