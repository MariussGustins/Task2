using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;
using Task2.Services;
using AutoMapper;
using Task2.Mappings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<MigrationService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); 
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    //token registration
.AddJwtBearer(options =>
{
    options.Authority = "https://dev-dan42zmue7a65nbf.us.auth0.com";
    options.Audience = "http://localhost:5042/api";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://dev-dan42zmue7a65nbf.us.auth0.com/",
        ValidateAudience = true,
        ValidAudience = "http://localhost:5042/api",
        ValidateLifetime = true,
        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/roles"
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var claims = context.Principal?.Claims;
            if (claims != null)
            {
                foreach (var claim in claims)
                {
                    Console.WriteLine($"Claim: {claim.Type}, Value: {claim.Value}");
                }
            }
            return Task.CompletedTask;
        }
    };
});


// Register the scope handler
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.UseRouting();

app.UseHttpsRedirection();

// Enable CORS middleware
app.UseCors("AllowAngularApp");

app.UseAuthentication(); 
app.UseAuthorization(); 

//token details, using only if backend has auth 2.0
app.Use(async (context, next) =>
{
    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    if (!string.IsNullOrEmpty(token))
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);

        Console.WriteLine("Token Details:");
        Console.WriteLine($"Subject: {jsonToken.Subject}");
        Console.WriteLine($"Audience: {jsonToken.Audiences.FirstOrDefault()}");
        Console.WriteLine($"Issuer: {jsonToken.Issuer}");
        Console.WriteLine("Claims:");
        foreach (var claim in jsonToken.Claims)
        {
            Console.WriteLine($"{claim.Type}: {claim.Value}");
        }
    }

    await next.Invoke();
});

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Urls.Add("http://*:5042");

app.Run();
