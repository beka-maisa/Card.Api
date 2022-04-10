using Card.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Filters
{
    public class HandleExceptionAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Values.SelectMany(s => s.Errors)
                    .Select(s => s.ErrorMessage)
                    .ToList();

                context.Result = new ObjectResult(new CardResponse(false, error));
                return;
            }

            await next();
        }
    }
}
