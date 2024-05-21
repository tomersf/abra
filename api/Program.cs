
using System.Text.Json.Serialization;
using api.Data;
using api.Services;
using DotNetEnv;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
Env.Load();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Abra API", Version = "v1", Description = "Abra API" });
});


var databaseSettings = new DatabaseSettings
{
    PetCollectionName = Environment.GetEnvironmentVariable("PET_COLLECTION_NAME") ?? "",
    ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "",
    DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? ""
};

builder.Services.AddSingleton(databaseSettings);
builder.Services.AddSingleton<ApplicationDBContext>();
builder.Services.AddScoped<PetService>();

builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }); ;

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

app.UseCors();
app.MapControllers();
app.Run();