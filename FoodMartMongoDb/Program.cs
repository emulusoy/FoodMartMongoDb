using System.Reflection;
using FoodMartMongoDb.Services.CategoryServices;
using FoodMartMongoDb.Services.CustomerServices;
using FoodMartMongoDb.Services.ProductServices;
using FoodMartMongoDb.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryService,CategoryServiceManager>();
builder.Services.AddScoped<ICustomerService,CustomerServiceManager>();
builder.Services.AddScoped<IProductService,ProductServiceManager>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //automapperi projeye tanitiyor backend backendin icinde butun profile siniflarini bul ve yukle mapping icindekileri!

builder.Services.Configure<IDatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));//mongo db veritabani tanitma yaptik!
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettingsManager>>().Value;
});//uygulama ilk ayaga kalktiginda buradaki verilere erisebilmek icin burayi kullaniyoruz databasesetting icinde ki tablo database name gib yerlere gidiyoru
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
