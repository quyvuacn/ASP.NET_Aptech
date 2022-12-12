using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ShopASP.Middlewares
{
    public class AuthUserMiddleware
    {
        
        public void Configure(IApplicationBuilder app, ITempDataProvider tempDataProvider)
        {
            app.Use(async Task (context,next) => {
                if (1==1)
                {
                    //TempData["Message"] : session dùng 1 lần
                    tempDataProvider.SaveTempData(context, new Dictionary<string, object> { ["Message"] = "Sử dụng TempData" });
                    context.Response.Redirect("/Admin/Users");
                }
                await next(context);
            });
        }
    }
}
