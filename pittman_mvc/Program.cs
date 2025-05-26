using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1) Register your controllers, Swagger, etc.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2) Pull in your user‑secrets into IConfiguration and add the OpenAI service
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddOpenAIService();

// 3) Build the app
var app = builder.Build();

// 4) Static file + default file for *all* environments
var fileProvider = new FileExtensionContentTypeProvider();
fileProvider.Mappings[".glb"] = "model/gltf-buffer";

app.UseDefaultFiles();                          // will look for index.html
app.UseStaticFiles(new StaticFileOptions {
  ContentTypeProvider = fileProvider
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 5) Routing / HTTPS / Authorization
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// 6) Your API controllers
app.MapControllers();

// 7) **SPA fallback** — any non‑API route returns index.html
app.MapFallbackToFile("index.html");

app.Run();
