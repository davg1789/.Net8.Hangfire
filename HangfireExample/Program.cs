using HangfireExample.Application.Implementation;
using HangfireExample.Application.Services.Interfaces;
using HangfireExample.Domain.Interfaces.Repository;
using HangfireExample.Infrastructure.Data.SqlServer.Repository;
using HangfireExample.Infrastructure.Hangfire.Configuration;
using HangfireExample.Infrastructure.Hangfire.Implementations;
using HangfireExample.Infrastructure.Hangfire.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IGetFilesService, GetFilesService>();
builder.Services.AddSingleton<ISettings, Settings>();
builder.Services.AddSingleton<IGenericSettings, GenericSettings>();
builder.Services.AddSingleton<ILocationRepository, LocationRepository>();
var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<IGetFilesService>>();
builder.Services.AddSingleton(typeof(ILogger), logger);

builder.Services.AddHangfireConfiguration();

var app = builder.Build();

app.MapGet("/", () => "");
app.HangfireConfigure(app.Configuration);
app.Run();
