
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// OpenAI Dependency Injection Config
var aibuilder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();

IConfiguration configuration = aibuilder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);
serviceCollection.AddOpenAIService();
