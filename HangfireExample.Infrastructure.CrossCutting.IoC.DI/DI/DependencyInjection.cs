using HangfireExample.Application.Implementation;
using HangfireExample.Application.Services.Interfaces;
using HangfireExample.Domain.Interfaces.Repository;
using HangfireExample.Infrastructure.Data.SqlServer.Repository;
using HangfireExample.Infrastructure.Hangfire.Implementations;
using HangfireExample.Infrastructure.Hangfire.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfireExample.Infrastructure.CrossCutting.IoC.DI.DI
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static void Inject(this IServiceCollection services)
        {
            #region Services            
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ISettings, Settings>();
            services.AddSingleton<IGenericSettings, GenericSettings>();
            #endregion

            #region Repositories            
            services.AddSingleton<ILocationRepository, LocationRepository>();
            #endregion

            #region Hangfire     
            services.AddSingleton<IGetFilesService, GetFilesService>();
            #endregion

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<IGetFilesService>>();
            services.AddSingleton(typeof(ILogger), logger);
        }
    }
}