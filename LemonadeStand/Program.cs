using LemonadeStand.Models;
using LemonadeStand.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBeverageRepository, BeverageRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LemonadeStandDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:LemonadeStandDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();
