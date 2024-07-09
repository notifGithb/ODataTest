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

                var manipulatedResponseBody = ManipulateResponse(responseBody);
                context.Response.Headers["Content-Type"] = "application/json";


                await context.Response.WriteAsync(manipulatedResponseBody);
                context.Response.Body = originalBodyStream;
            }

            await _next(context);

        }
        private string ManipulateResponse(string responseBody)
        {
            var json = JArray.Parse(responseBody);

            var sehirDTOs = json.Select(jToken => new SehirDTO
            {
                Isim = jToken["Isim"].ToObject<string>(),
                PlakaNumarasi = jToken["PlakaNumarasi"].ToObject<int>(),
                Derece = jToken["Derece"].ToObject<double>(),
                Ilceler = jToken["Ilceler"].ToObject<List<IlceDTO>>()
            })
            .OrderBy(sehir => sehir.Derece)
            .ToList();

            var jsonResult = JsonConvert.SerializeObject(sehirDTOs);

            return jsonResult;
        }
    }

}
