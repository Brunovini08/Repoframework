using Repoframework.Repository.Implementations;
using Repoframework.Repository.Implementations.Data.SqlServer;
using Repoframework.Repository.Interfaces;
using User.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddSingleton<IConfigurationDB, DatabaseSqlServer>();
builder.Services.AddSingleton(typeof(IRepositoryBase), typeof(RepositoryBase));
builder.Services.AddSingleton<RepositoryUser>();

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
