using Customers.Infraestructure;
using Customers.Application;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using Customers.Domain.Enums;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<IdentificationType>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetValues(typeof(IdentificationType)).Cast<IdentificationType>()
        .Select(value =>
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo?.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return new OpenApiString((attribute?.Name) ?? value.ToString());
        })
        .ToList<IOpenApiAny>()
    });
});
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
FluentValidationConfig.AddFluentValidation(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
