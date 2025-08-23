using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.Interface;
using Sooqak.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SooqakDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-V1IJ63L\\SQLEXPRESS;Initial Catalog=SooqakDB;Integrated Security=True;TrustServerCertificate=True"));
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IAdvertisement, AdvertisementService>();

builder.Services.AddScoped<ICar, CarsService>();
builder.Services.AddScoped<IApartment, ApartmentService>();
builder.Services.AddScoped<IElectricalAppliance, ElectricalApplianceService>();
builder.Services.AddScoped<IWork, WorkService>();
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
