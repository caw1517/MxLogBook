using Backend.Configurations;
using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Setup connection string
var connectionString = builder.Configuration.GetConnectionString("MxLogBookDbConnectionString");

//Setup connection
builder.Services.AddDbContext<MxLogBookDbContext>(options => 
{
    options.UseNpgsql(connectionString);

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure Cors
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());
});

//Setup Serilog
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

//Setup AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

//Configure Services
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//Use App Cors
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
