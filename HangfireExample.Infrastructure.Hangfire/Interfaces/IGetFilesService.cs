using Hangfire.Server;

namespace HangfireExample.Infrastructure.Hangfire.Interfaces
{
    public interface IGetFilesService
    {
        Task ExecuteAsync(PerformContext context);
    }
}
