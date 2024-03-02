using System.Globalization;
using List10Csharp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDatabase")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(
    options =>
    {
        options.IdleTimeout = TimeSpan.FromDays(7);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    }
    );
var app = builder.Build();

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "articleRoute",
    pattern: "{controller=ArticlesController}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "categoryRoute",
    pattern: "{controller=CategoriesController}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "shopRoute",
    pattern: "{controller=ShopController}/{action=Index}/{id?}");

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
app.Run();
