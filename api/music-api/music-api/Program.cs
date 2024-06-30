using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMusicService();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
