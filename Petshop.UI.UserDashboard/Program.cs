
using Petshop.Application.Baskets.Command.Add;
using Petshop.Contract.Products.Images;
using Petshop.Core.Baskets;
using Petshop.Infra.Products.Images;
using Petshop.Utility.Paginations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
var cnn = builder.Configuration.GetConnectionString("BentiStore");
builder.Services.AddDbContext<BentiShopContext>(options => options.UseSqlServer(cnn));
builder.Services.AddScoped<ProductRepository, EfProductRepository>();
builder.Services.AddScoped<CategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<OrderRepository, EFOrderRepository>();
builder.Services.AddScoped<OrderInfoRepository, EFOrderInfoRepository>();
builder.Services.AddScoped<ImageRepository, EFImageRepository>();
builder.Services.AddScoped<OrderInfoService, EFOrderInfoService>();
builder.Services.AddScoped<PaymentService, EFPayIrService>();
builder.Services.Configure<PageInfo>(opt => builder.Configuration.GetSection("PageInfo").Bind(opt));
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Basket>(c => SessionBasket.GetBasket(c));
builder.Services.AddMediatR(typeof(AddBasketHandler).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/HomeDashboard/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeDashboard}/{action=Index}/{id?}");

app.Run();
