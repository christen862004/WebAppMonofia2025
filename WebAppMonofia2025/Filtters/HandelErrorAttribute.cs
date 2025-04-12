using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMonofia2025.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult view=new ViewResult();
            view.ViewName = "Error";
            context.Result =view;
        }
    }
}
