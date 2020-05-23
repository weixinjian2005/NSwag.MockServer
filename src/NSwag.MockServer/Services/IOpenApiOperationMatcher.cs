using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;

namespace NSwag.MockServer.Services
{
    public interface IOpenApiOperationMatcher
    {
        OpenApiOperation MatchByRequestAction(OpenApiPathItem pathItem, HttpContext httpContext);
    }

    public class OpenApiOperationMatcher : IOpenApiOperationMatcher
    {
        public OpenApiOperation MatchByRequestAction(OpenApiPathItem pathItem, HttpContext httpContext)
        {
            var result = pathItem.Operations
                .TryGetValue(TranslateRequestMethod(httpContext.Request.Method), out var operation);

            return result ? operation : null;
        }

        private OperationType TranslateRequestMethod(string method)
        {
            var memberInfo = typeof(OperationType)
                .GetMembers()
                .First(m => m.Name.Equals(method, StringComparison.InvariantCultureIgnoreCase));

            var type = (OperationType)Enum.Parse(typeof(OperationType), memberInfo.Name);
            return type;
        }
    }
}