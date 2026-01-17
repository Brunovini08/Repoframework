using Repoframework.Repository.Utils.extensions;
using Repoframework.Repository.Utils.settings;
using User.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

builder.Services.AddCoreDependencies(builder.Configuration, opt =>
{
    opt.ConnectionString = builder.Configuration.GetSection("ConnectionStrings")["ConnectionString"];
});

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
