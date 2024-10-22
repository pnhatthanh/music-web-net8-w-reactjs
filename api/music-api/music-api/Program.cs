using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicApi.Data.Data;
using MusicApi.Helper.Helpers;
using MusicApi.Helper;
using MusicApi.Service;
using System.Text;
using System.Text.Json.Serialization;
using CloudinaryDotNet;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DbContext
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion


#region AddDependency
builder.Services.AddAutoMapper(typeof(ApplicationMapper).Assembly);
builder.Services.AddMusicService();
builder.Services.AddHelperService();
#endregion

#region Authentication
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
    ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        builder.Configuration.GetSection("Jwt:Key").Value ?? throw new InvalidOperationException())),
    ClockSkew = TimeSpan.Zero
};
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
        {
            o.SaveToken = true;
            o.RequireHttpsMetadata = false;
            o.TokenValidationParameters = tokenValidationParameters;
        });
#endregion

#region AddAuthorization
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    option.AddPolicy("User", policy => policy.RequireRole("User"));
});
#endregion

#region Cloudinary
Account account = new Account (
    builder.Configuration.GetSection("Cloudinary:Cloudname").Value,
    builder.Configuration.GetSection("Cloudinary:ApiKey").Value,
    builder.Configuration.GetSection("Cloudinary:ApiSecret").Value
);
var cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);
#endregion

#region Redis
if (builder.Configuration.GetValue<bool>("RedisConfiguration:Enabled"))
{
    var connection = builder.Configuration.GetSection("RedisConfiguration:ConnectionString").Value;
    builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(connection!));
    builder.Services.AddStackExchangeRedisCache(options => options.Configuration = connection);
}
#endregion

#region CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", build =>
    {
        build.WithOrigins("http://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod();
    });
});
#endregion

builder.Services.AddLogging();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
