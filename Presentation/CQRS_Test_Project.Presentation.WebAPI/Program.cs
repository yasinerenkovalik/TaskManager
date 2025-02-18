using System.Text;
using CQRS_Test_Project.Core.Application;
using CQRS_Test_Project.Core.Application.Validations.User;
using CQRS_Test_Project.Infrastructure.Persistence;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using CQRS_Test_Project.Infrastructure.Persistence.Security;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

// ✅ HATA DÜZELTİLDİ: Secret doğru okundu.
var secretKey = jwtSettings["Secret"];
if (string.IsNullOrEmpty(secretKey))
{
    throw new ArgumentNullException("JwtSettings:Secret", "JWT Secret değeri bulunamadı!");
}

// ✅ HATA DÜZELTİLDİ: En az 32 karakter olmalı.
if (secretKey.Length < 32)
{
    throw new ArgumentException("JWT Secret Key en az 32 karakter olmalıdır!");
}

var key = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("SuperAdminPolicy", policy => policy.RequireRole("SuperAdmin"));
});

// Services
builder.Services.AddControllers().AddFluentValidation(conf=>conf.RegisterValidatorsFromAssemblyContaining<UserValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistanceLayerServices();
builder.Services.AddAplicationLayerServices();

builder.Services.AddScoped<JwtService>();
builder.Services.AddDbContext<CqrsContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ✅ LOG: Secret Key düzgün okunuyor mu?
var configuration = builder.Configuration;
Console.WriteLine("JWT Secret Key: " + (configuration["JwtSettings:Secret"] ?? "NULL DEĞER!"));

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
