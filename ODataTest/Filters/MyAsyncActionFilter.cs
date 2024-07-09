using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace ODataTest.Filters
{
    public class MyAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionContext = await next();

            //if (actionContext.Result is ObjectResult objectResult)
            //{
            //    if (objectResult.Value is IQueryable<object> queryable)
            //    {
            //        var headers = context.HttpContext.Request.Headers;
            //        int pageNumber = headers.ContainsKey("pageNumber") ? int.Parse(headers["pageNumber"].FirstOrDefault()) : 1;
            //        int pageSize = headers.ContainsKey("pageSize") ? int.Parse(headers["pageSize"].FirstOrDefault()) : 5;

            //        var paginatedData = await queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            //        objectResult.Value = paginatedData;
            //    }
            //}
        }
    }
}