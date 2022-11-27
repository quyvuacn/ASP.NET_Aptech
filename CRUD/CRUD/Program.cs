using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUD.Data;
using CRUD.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CRUDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDContext") ?? throw new InvalidOperationException("Connection string 'CRUDContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => {
    options.LowercaseUrls = true; //LowercaseUrls 
    //options.LowercaseQueryStrings = true; //LowercaseQueryStrings
});


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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
