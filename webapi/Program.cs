// Создание логгера
using Serilog;
using Microsoft.EntityFrameworkCore;
using Calc.Models;
Log.Logger = new LoggerConfiguration()
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Настройка подключения к БД"

string connection = "Data Source=/home/fizlrock/code/hobby/Calculator/webapi/Database/mydb.db;";
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
Log.Warning($"юзаем бд по адресу: {connection}");
builder.Services.AddDbContext<MathRequestContext>(
        options =>
        {
            options.UseSqlite(connection);
            options.LogTo(Log.Logger.Debug);
        });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Host.UseSerilog();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseForwardedHeaders();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();


Log.CloseAndFlush();





