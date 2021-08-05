using GroceryStore.Api.Profiles;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Repositories;
using GroceryStore.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStore.Api.Extensions
{
    /// <summary>
    ///     Extension methods for custom dependencies.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds auto mapper profile classes.
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerProfile));
        }

        /// <summary>
        ///     Adds services.
        /// </summary>
        /// <param name="services"></param>
        public static void AddGroceryStoreServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
        }

        /// <summary>
        ///     Adds repositories.
        /// </summary>
        /// <param name="services"></param>
        public static void AddGroceryStoreRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}