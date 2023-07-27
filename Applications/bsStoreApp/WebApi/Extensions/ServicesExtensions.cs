using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
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

        public static void ConfigureServiceManager(this IServiceCollection services)=>
            services.AddScoped<IServiceManager,ServiceManager>();
        public static void ConfigureLoggerService(this IServiceCollection services) =>
           services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureActionFilters (this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
            services.AddScoped<ValidateMediaTypeAttribute>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination")
                );
            });
        }
        public static void ConfigureDataShapper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<BookDto>,DataShaper<BookDto>>();
        }
        public static void AddCustomeMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var sysemTextJsonOutputFormatter = config.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();
                if (sysemTextJsonOutputFormatter is not null)
                {
                    sysemTextJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.cptmfs.hateoas+json");
                }
                var xmlOutputFormatter = config.OutputFormatters.OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();
                if (xmlOutputFormatter is not null)
                {
                    xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.cptmfs.hateoas+xml");
                }
            });
        }
    }
}
