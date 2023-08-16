using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Presentation.ActionFilters;
using Repositories.EntityFramework;
using Services;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; //içerik pazarlýðýna açýk
    config.ReturnHttpNotAcceptable = true; // Desteklenmeyen format için 406 kodu
    config.CacheProfiles.Add("5mins", new CacheProfile() { Duration = 300 }); // 5 dakikalýk bir cache profili oluþturduk ve bunu profili kullanacaðýz. ->> " [ResponseCache(CacheProfileName ="5mins")] "
})
    .AddXmlDataContractSerializerFormatters()
    .AddCustomCsvFormatter()
    .AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly);
    //.AddNewtonsoftJson();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager(); // tek parametreli olduðu için parantez içine builder.Configuration eklemedik.
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureDataShapper();
builder.Services.AddCustomeMediaTypes();
builder.Services.AddScoped<IBookLinks, BookLinks>();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching(); //Caching
builder.Services.ConfigureHttpCacheHeaders(); //Caching
builder.Services.AddMemoryCache(); // Rate Limit
builder.Services.ConfigureRateLimitingOptions(); // Rate Limit
builder.Services.AddHttpContextAccessor(); // Rate Limit
builder.Services.ConfigureIdentity(); //Identity
builder.Services.ConfigureJWT(builder.Configuration); //Identity -ConfigureJWT

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();

app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();
app.UseCors("CorsPolicy");
app.UseResponseCaching(); // Microsoft Cors'dan sonra Caching ifadesine yer vermemizi öneriyor.
app.UseHttpCacheHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
