using Microsoft.Extensions.DependencyInjection;

namespace NSwag.MockServer.Services
{
    public static class ServicesRegister
    {
       public static void AddMockServer(this IServiceCollection services)
       {
           services.AddScoped<IOpenApiDocumentValidator, OpenApiDocumentValidator>();
           services.AddScoped<OpenApiDocumentReader>();
           services.AddScoped<IOpenApiPathItemMatcher, OpenApiPathItemMatcher>();
           services.AddScoped<IOpenApiOperationMatcher, OpenApiOperationMatcher>();
           services.AddScoped<IOpenApiSchemaSelector, OpenApiSchemaSelector>();
           services.AddScoped<IOpenApiObjectTransformer, OpenApiObjectTransformer>();
       } 
    }
}