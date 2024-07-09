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

                var json = JArray.Parse(responseBody);

                var sehirDTOs = json.Select(dto => new SehirDTO
                {
                    Isim = dto["Isim"].ToObject<string>(),
                    PlakaNumarasi = dto["PlakaNumarasi"].ToObject<int>(),
                    Derece = dto["Derece"].ToObject<double>(),
                    Ilceler = dto["Ilceler"].ToObject<List<IlceDTO>>()
                })
                .OrderBy(sehir => sehir.Derece)
                .ToList();

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
