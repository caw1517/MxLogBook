using Backend.Configurations;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using Backend.Services.SignOffs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Setup connection string
var connectionString = builder.Configuration.GetConnectionString("MxLogBookDbConnectionString");

//Setup connection
builder.Services.AddDbContext<MxLogBookDbContext>(options => 
{
    options.UseNpgsql(connectionString);

});

//Setup Identity (Currently a default user)
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("MxLogBookApi")
    .AddEntityFrameworkStores<MxLogBookDbContext>()
    .AddDefaultTokenProviders();

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
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILogItemService, LogItemService>();
builder.Services.AddScoped<ISignOffService, SignOffService>();

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//});

//Setup JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
