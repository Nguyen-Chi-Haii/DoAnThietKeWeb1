using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using DoAnThietKeWeb1.Models.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GorocoDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GorocoShopDbContextConnection")));

builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IReviewRepository,ReviewRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
app.UseSession();


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
    pattern: "{controller=Home}/{action=HomeIndex}/{id?}");

app.Run();
