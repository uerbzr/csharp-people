using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using workshop.Data;
using workshop.models;
using workshop.Repository;
using workshop.wwwapi.Endpoints;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("People"));
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.ConfigurePeopleEndpoints();

app.Run();


