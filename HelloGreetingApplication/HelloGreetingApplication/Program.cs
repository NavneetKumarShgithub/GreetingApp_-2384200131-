using BusinessLayer.Interface;
using BusinessLayer.Service;
using HelloGreetingApplication.Controllers;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using NLog;
using NLog.Web;

var logger = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
}).CreateLogger<Program>();
logger.LogInformation("starting");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddScoped<IGreetingBL, GreetingBL>();
    builder.Services.AddScoped<IGreetingRL, GreetingRL>();  
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var ConnectionString = builder.Configuration.GetConnectionString("SqlConnection");
    builder.Services.AddDbContext<HelloGreetingContext>(option => option.UseSqlServer(ConnectionString));


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
}
catch(Exception ex)
{
    logger.LogError(ex, "treminated the program");
}
finally
{
    NLog.LogManager.Shutdown();
}