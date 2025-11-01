using Microsoft.EntityFrameworkCore;
using task4;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddDataAccess(connectionString);
builder.Services.AddBusinessLogic();
builder.Services.AddPresentation();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "api");
    });
}

app.AddPresentation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
