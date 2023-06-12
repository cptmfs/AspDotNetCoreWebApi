using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EntityFramework;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        // Servisler static ,
        // program.cs de servisi method olarak kullanmak için , methodu static void olarak tanımlayıp , parametre olarak this ifadesiyle genişletmek istediğimiz parametreyi veriyoruz. Başka parametrelere ihtiyacımız var ise methodda onlarıda virgülden sonra ekleyebiliyoruz..
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });

        public static void ConfigureRepositoryManager(this IServiceCollection services)=>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services)=>services.AddScoped<IServiceManager,ServiceManager>();
    }
}
