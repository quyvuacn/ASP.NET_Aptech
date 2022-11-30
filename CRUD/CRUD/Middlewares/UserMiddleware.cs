using CRUD.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CRUD.Middlewares
{
    public class UserMiddleware : Controller
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Use(async (context, next) =>
            {
                
                if (1==1)
                {
                    context.Response.Redirect("/movies/details/3");     
                }
                await next();
                
                
            });
        }
    }
}
