using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Services.AddScoped<IGreetingRL, GreetingRL>();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
