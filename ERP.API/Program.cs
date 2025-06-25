using ERP.BusinessLogic.BusinessLogics;
using ERP.BusinessLogic.IBusinessLogics;
using ERP.BusinessRepository.BusinessRepository;
using ERP.BusinessRepository.IBusinessRepository;
using ERP.BusinessRepository.Services;
using ERP.Database.ERPDbContext;
using ERP.Database.Seeders;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using Npgsql;
using System.Data;
using ERP.BusinessLogic.IBusinessLogics.RealEstate;
using ERP.BusinessRepository.IBusinessRepository.RealEstate;
using ERP.BusinessRepository.BusinessRepository.RealEstate;
using ERP.BusinessLogic.BusinessLogics.RealEstate;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = string.Empty;

connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddTransient<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnectionString")));
// Add services to the container.
builder.Services.AddDbContext<ERPDBContext>(options =>
{
    _ = options.UseNpgsql(connectionString);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");

#region Repository Registration
builder.Services.AddScoped(typeof(IGenericCRUDService<>), typeof(GenericCRUDService<>));
builder.Services.AddTransient<IVendorBl, VendorBl>();
builder.Services.AddTransient<IVendorBr, VendorBr>();
builder.Services.AddTransient<IPurchaseRequestBl, PurchaseRequestBl>();
builder.Services.AddTransient<IPurchaseRequestBr, PurchaseRequestBr>();
builder.Services.AddTransient<IRealestateBl, RealestateBl>();
builder.Services.AddTransient<IRealestateBr, RealestateBR>();
builder.Services.AddTransient<IChequeBl, ChequeBl>();
builder.Services.AddTransient<IChequeBr, ChequeBR>();
#endregion

#region Cors Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders", builder =>
    {
        _ = builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
#endregion

var app = builder.Build();

// Run seeding after building the app
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    CsvSeeder.SeedAll(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
