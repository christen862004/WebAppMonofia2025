using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMonofia2025.Filtters
{
    public class MyFilterActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //empty
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //
        }
    }
}
