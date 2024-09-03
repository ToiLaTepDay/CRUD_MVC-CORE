using ASP_CORE_API.Data;
using ASP_CORE_API.Repositories;
using ASP_CORE_API.Repositories.ProductRepository;
using ASP_CORE_API.Services.Categorys;
using ASP_CORE_API.Services.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")));

// set use the services and repository
// repository 
builder.Services.AddScoped<ICategoryRepository, CateogryRepositoryImpl>();
builder.Services.AddScoped<IProductRepositorycs, ProductRepositoryImpl>();

// service
builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>(); 
builder.Services.AddScoped<IProductService, ProductServiceImpl>();  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
