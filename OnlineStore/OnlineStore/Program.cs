using Microsoft.EntityFrameworkCore;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Services;
using OnlineStore.DAL.Context;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<OnlineStoreContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();