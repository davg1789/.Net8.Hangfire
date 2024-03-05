using Hangfire.Server;
using HangfireExample.Application.Services.Interfaces;
using HangfireExample.Infrastructure.Hangfire.Interfaces;
using Microsoft.Extensions.Logging;

namespace HangfireExample.Infrastructure.Hangfire.Implementations
{
    public class GetFilesService : BaseService<GetFilesService>, IGetFilesService
    {
        private readonly IFileService fileService;

        public GetFilesService(ILogger<GetFilesService> logger, IFileService fileService) : base(logger, "GetFilesService - (Read files) - ")
        {
            this.fileService = fileService;
        }

        public async Task ExecuteAsync(PerformContext context)
        {
            try
            {
                logger.LogInformation($"(GetFilesService) - Start  {DateTime.Now}");

                var result = await fileService.ReadAndSave(logger);

                logger.LogInformation($"(GetFilesService) - Completion date: {DateTime.Now} - {result} locations added");
            }
            catch (Exception ex)
            {
                logger.LogError($"(GetFilesService) - Error: {ex.Message}");
            }
        }
    }
}