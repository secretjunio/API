using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.Insfracstructure.DBContext;
using Domain.Insfracstructure.Entities;
using Domain.Insfracstructure.Persistance.IRepository;
using Domain.Insfracstructure.Persistance.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EFContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThienConnect"));
}); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();


builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

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
