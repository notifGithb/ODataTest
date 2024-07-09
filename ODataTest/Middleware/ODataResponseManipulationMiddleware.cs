using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ODataTest.DTOs;

namespace ODataTest.Middleware
{
    public class ODataResponseManipulationMiddleware
    {
        private readonly RequestDelegate _next;

        public ODataResponseManipulationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                var sehirDTOs = JsonConvert.DeserializeObject<List<SehirDTO>>(responseBody)!.OrderBy(sehir => sehir.Derece).ToList();

                var jsonResult = JsonConvert.SerializeObject(sehirDTOs);

                context.Response.Body = originalBodyStream;
                await context.Response.WriteAsync(jsonResult);

            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseODataResponseManipulation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ODataResponseManipulationMiddleware>();
        }
    }

}
