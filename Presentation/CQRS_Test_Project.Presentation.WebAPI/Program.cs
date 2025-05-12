using System.Text;
using CQRS_Test_Project.API.Extensions;
using CQRS_Test_Project.Core.Application;
using CQRS_Test_Project.Core.Application.Validations.User;
using CQRS_Test_Project.Infrastructure.Persistence;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using CQRS_Test_Project.Infrastructure.Persistence.Security;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddJwtAuthentication(builder.Configuration);

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


var configuration = builder.Configuration;

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
