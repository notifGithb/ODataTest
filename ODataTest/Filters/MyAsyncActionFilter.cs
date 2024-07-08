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

            if (actionContext.Result is ObjectResult objectResult && objectResult.Value is IQueryable<object> queryable)
            {
                var query = context.HttpContext.Request.Query;
                int pageNumber = query.ContainsKey("pageNumber") ? int.Parse(query["pageNumber"].FirstOrDefault()) : 1;
                int pageSize = query.ContainsKey("pageSize") ? int.Parse(query["pageSize"].FirstOrDefault()) : 5;
                
                var data = await queryable.ToListAsync();

                var paginatedData = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                objectResult.Value = paginatedData;
            }
        }
    }
}