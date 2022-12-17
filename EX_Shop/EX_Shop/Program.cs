using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EX_Shop.Data;
using EX_Shop.SeedData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EX_ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EX_ShopContext") ?? throw new InvalidOperationException("Connection string 'EX_ShopContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//SeedData
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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
