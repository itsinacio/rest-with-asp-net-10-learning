using RestWithASPNET.Configurations;
using RestWithASPNET.Repositories;
using RestWithASPNET.Repositories.Impl;
using RestWithASPNET.Services;
using RestWithASPNET.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.addSerilogLogging();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.addDataBaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration,builder.Environment);
builder.Services.AddSingleton<MathService>();
builder.Services.AddScoped<IPersonServices,PersonServiceImpl>();
builder.Services.AddScoped<IPersonRepository,PersonRepositoryImpl>();
builder.Services.AddScoped<IBookServices,BookServiceImpl>();
builder.Services.AddScoped<IBookRepository,BookRepositoryImpl>();

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
