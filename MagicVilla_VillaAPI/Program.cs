

using MagicVilla_VillaAPI;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//	.WriteTo.File("log/villaLogs.txt",rollingInterval:RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicationDbContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddScoped<IVillaRepository,VillaRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers().AddNewtonsoftJson();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
