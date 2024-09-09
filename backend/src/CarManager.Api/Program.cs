using CarManager.Api.Extensions;
using CarManager.Application.Configuration;
using CarManager.Application.Mapster.Mappers;
using CarManager.Application.Queries;
using CarManager.Application.Services;
using CarManager.DataAccess;
using CarManager.DataAccess.Repositories.Read;
using CarManager.DataAccess.Repositories.Write;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarReadRepository, CarReadRepository>();
builder.Services.AddScoped<IBrandReadRepository, BrandReadRepository>();
builder.Services.AddScoped<IBodyTypeReadRepository, BodyTypeReadRepository>();
builder.Services.AddScoped<ICarWriteRepository, CarWriteRepository>();

builder.Services.RegisterMapster<SingleValueObjectsMapper>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllCarsQuery).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.MigrateDatabase<ApplicationDbContext>();

app.Run();