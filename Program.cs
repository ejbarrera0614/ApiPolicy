using InsurancePoliciesAPI.Services;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register Library Service to use it with Dependency Injection in Controllers
builder.Services.AddTransient<ICoverageService, CoverageService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IPolicyService, PolicyService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IPolicyVehicleService, PolicyVehicleService>();
builder.Services.AddTransient<IPolicyCoverageService, PolicyCoverageService>();

builder.Services.AddDbContext<InsurancePoliciesContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("InsurancePoliciesContext")));

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
