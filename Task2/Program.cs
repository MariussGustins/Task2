using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;
using Task2.Services;
using AutoMapper;
using Task2.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Entity Framework to use SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EstateContext>(opt => opt.UseSqlServer(connectionString));

// Register AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Register services
builder.Services.AddScoped<IHousesService, HousesService>();
builder.Services.AddScoped<IResidentService, ResidentsService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") 
            .AllowAnyHeader()
            .AllowAnyMethod());
});

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

app.UseRouting();

// Enable CORS middleware
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
