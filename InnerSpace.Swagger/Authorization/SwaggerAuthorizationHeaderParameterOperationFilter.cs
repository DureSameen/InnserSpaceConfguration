using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace InnerSpace.Swagger.Authorization
{
    public class SwaggerAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters?.Add(new NonBodyParameter
            {
                Name = "Authorization",
                In = "header",
                Description = "Access Token",
                Required = false,
                Type = "string"
            });
        }
    }


}
