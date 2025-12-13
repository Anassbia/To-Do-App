using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace To_Do.Filters
{
    public class ThemeFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            var httpContext = context.HttpContext;

            var theme = httpContext.Session.GetString("theme") ?? "light";

            if (context.Controller is Controller controller)
            //si context.Controller est un  MVC Controller -> siftha lController w stockiha dans une variable nomme controller
            {
                controller.ViewBag.Theme = theme;

            }
        }
        

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
