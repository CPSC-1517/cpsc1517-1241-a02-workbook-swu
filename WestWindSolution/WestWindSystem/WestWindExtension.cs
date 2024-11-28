using Microsoft.EntityFrameworkCore; // for DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection; // for IServiceCollection
using WestWindSystem.BLL;
using WestWindSystem.DAL; // for WestWindContext

namespace WestWindSystem
{
    public static class WestWindExtension
    {
        //this class can hold an set of extension methods
        //this sample creates an extension method that will add services
        //  to IServiceCollection
        //this method will be called from an separate project to
        //  gain data from the WestWind database
        //In this demo, the call will be done in the WestWindApp Program.cs file
        //this method will do 2 things:
        //  a) register the context connection string
        //  b) register ALL services that I create within the BLL class(es)
        public static void AddBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //handle the connection string
            //add my context class to the services (IServiceCollection)
            services.AddDbContext<WestWindContext>(options);

            //YOU MUST REGISTER EACH AND EVERY BLL SERVICE CLASS YOU WISH YOUR WEB APP TO USE

            //to register a service class you will use the IServiceCollection method
            //  .AddTransient<T>
            //for any outside coding that requires acces to one or more services
            //  you MUST register the service class
            //ALL methods within the class are available to the outside world
            services.AddTransient<BuildVersionService>((serviceProvider) =>
            {
                //this statement obtains the context information reqistered above
                var context = serviceProvider.GetRequiredService<WestWindContext>();

                //create an instance of the service class and register said class in
                //  IServiceCollection
                //once the class has been registered, it can be used by ANY outside source
                //  as long as the outside source has referenced the extension class
                //  (see your Program.cs in your web app)
                return new BuildVersionService(context);
            });

            services.AddTransient<RegionService>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new RegionService(context);
            });

            services.AddTransient<CategoryService>((serviceProvider) => 
            {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new CategoryService(context);
            });

            services.AddTransient<ProductService>((serviceProvider) => 
            {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new ProductService(context);
            });

            services.AddTransient<ShipperService>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new ShipperService(context);
            });

            services.AddTransient<SupplierService>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new SupplierService(context);
            });
        }
    }
}
