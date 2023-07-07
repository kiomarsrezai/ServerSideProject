using Microsoft.EntityFrameworkCore;
using WareHousingApi.DataModel;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.DataModel.Services.Repository;
using WareHousingApi.WebApi.Extensions;
using WareHousingApi.WebApi.Tools;
using WareHousingApi.WebApi.Tools.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(FileNamesExtenstions.AppSettingName).Build();

builder.Services.AddControllers();
//DataBase
builder.Services.AddDbContextService(configuration);
//Identity
builder.Services.AddIdentityService(configuration);
//
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IFiscalYearRepository, FiscalYearRepository>();
builder.Services.AddScoped<IWareHouseRepository, WareHouseRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
builder.Services.AddScoped<IProductLocationRepository, ProductLocationRepository>();
builder.Services.AddScoped<IRialiStockRepository, RialiStockRepository>();
builder.Services.AddScoped<IWastageRialiRepository, WastageRialiRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddAutoMapper(typeof(Program));
//
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificationOrigins",
        builder =>
        {
            //builder.WithOrigins("https://localhost:7215", "https://porsnet.ir");
            builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true);
        });
});

builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});
//////////////////////////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("_myAllowSpecificationOrigins");

//احراز هویت
app.UseAuthentication();
//مجوزهای دسترسی
app.UseAuthorization();

app.MapControllers();

app.Run();