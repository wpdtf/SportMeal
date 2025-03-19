using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Infrastructure.Data;
using SportMeal.Api.Infrastructure.Repositories;
using DataBaseContext = SportMeal.Api.Infrastructure.Repositories.DataBaseContext;
using SportMeal.Api.Domain.Services;

namespace SportMeal.Api;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOptionsWithValidateOnStart<AppSettings>().Bind(builder.Configuration).ValidateDataAnnotations();
        var configuration = builder.Configuration.Get<AppSettings>();

        builder.Services.AddDbContext<DataBaseContext>(x =>
            x.UseSqlServer(configuration.ConnectionStrings.MsSqlConnection));

        builder.Services.AddHttpLogging(x => x.LoggingFields = HttpLoggingFields.ResponseBody | HttpLoggingFields.RequestBody |
            HttpLoggingFields.RequestProperties | HttpLoggingFields.ResponseStatusCode);

        builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = true).AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: true));
            x.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
        });
        builder.Services.AddSwaggerGen(options =>
        {
            options.CustomOperationIds(e => $"{Regex.Replace(e.RelativePath, "{|}", "")}{e.HttpMethod}");
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = typeof(Program).Assembly.GetName().Name,
                Version = "v1",
            });
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
        });

        builder.Services.AddProblemDetails(options => options.CustomizeProblemDetails = (context) =>
        {
            var ex = context.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex is SqlException sqlException)
            {
                context.ProblemDetails.Detail = ex.Message;
            }
            context.ProblemDetails.Extensions["errorCode"] = -1;
        });

        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddScoped<AuthService>();

        builder.Services.AddResponseCaching();

        var app = builder.Build();

        var cultureInfo = new CultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        if (app.Environment.IsProduction() is false)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpLogging();
        _ = app.Environment.IsProduction() is false
            ? app.UseDeveloperExceptionPage()
            : app.UseExceptionHandler();

        app.UseStatusCodePages();

        app.MapControllers();

        app.Run();
    }
}
