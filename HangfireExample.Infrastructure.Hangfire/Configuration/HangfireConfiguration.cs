using Hangfire;
using Hangfire.Common;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using HangfireExample.Infrastructure.Hangfire.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace HangfireExample.Infrastructure.Hangfire.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class HangfireConfiguration
    {
        public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services)
        {

            services.AddHangfire(c => c
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseRecommendedSerializerSettings()
                .UseConsole()
                .UseMemoryStorage());

            services.AddHangfireServer();

            return services;
        }

        public static void HangfireConfigure(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseHangfireDashboardCustomOptions(new HangfireDashboardCustomOptions
            {
                DashboardTitle = () => "1 - Read and save file in database",
            });

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = Enumerable.Empty<IDashboardAuthorizationFilter>()
            });

            var manager = new RecurringJobManager();

            manager.AddOrUpdate("1 - Read and save file in database", Job.FromExpression<IGetFilesService>((x) => x.ExecuteAsync(null)), configuration.GetValue<string>("CronGetFilesService"));    
        }
    }
}