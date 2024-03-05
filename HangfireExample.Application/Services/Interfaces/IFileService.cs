using Microsoft.Extensions.Logging;

namespace HangfireExample.Application.Services.Interfaces
{
    public interface IFileService
    {
        Task<int> ReadAndSave(ILogger logger);
    }
}