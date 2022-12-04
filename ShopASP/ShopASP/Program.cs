using Microsoft.EntityFrameworkCore;
using ShopASP.Data;
using ShopASP.Features;
using ShopASP.SeedData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShopASPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopASPContext") ?? throw new InvalidOperationException("Connection string 'ShopASPContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//Dịch vụ convert razor sang html 
builder.Services.AddScoped<IViewRenderService, ViewRenderService>();
//Dịch vụ send Mail
builder.Services.AddScoped<IEmail, Email>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
