// Создание логгера
using Serilog;
using Microsoft.EntityFrameworkCore;
Log.Logger = new LoggerConfiguration()
		.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Настройка подключения к БД
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<MathRequestContext>(options => options.UseSqlite(connection));

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





