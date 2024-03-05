using HangfireExample.Infrastructure.CrossCutting.IoC.DI.DI;
using HangfireExample.Infrastructure.Hangfire.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Inject();

builder.Services.AddHangfireConfiguration();

var app = builder.Build();

app.MapGet("/", () => "");
app.HangfireConfigure(app.Configuration);
app.Run();
