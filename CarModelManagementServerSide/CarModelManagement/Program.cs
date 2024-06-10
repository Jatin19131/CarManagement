using AutoMapper;
using CarManagement.DataLayer.DbContextOperation;
using CarManagement.ServiceLayer.Interface;
using CarManagement.ServiceLayer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add dbcontext
builder.Services.AddDbContext<DbAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// End

// Add services to the container.
builder.Services.AddScoped<ICarModels, CarModelsService>();
builder.Services.AddScoped<ICarClasses, CarClassesService>();
builder.Services.AddScoped<ISalesReport, SalesReportService>();
builder.Services.AddScoped<ICarBrands, CarBrandsService>();
// End

builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

//Added Automapper
builder.Services.AddAutoMapper();
//end

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

app.UseCors("AllowOrigin");
app.UseAuthorization();
app.MapControllers();
app.Run();
