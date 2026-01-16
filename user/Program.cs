using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repoframework.Repository.Implementations;
using Repoframework.Repository.Implementations.Data;
using Repoframework.Repository.Interfaces;
using user.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IConfigurationDB, DatabaseSqlServer>();
builder.Services.AddSingleton<IFactoryDatabase, FactoryDatabase>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
