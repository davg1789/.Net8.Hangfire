using Hangfire.Console;
using Hangfire.Server;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HangfireExample.Infrastructure.Hangfire.Implementations
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseService<T>
    {
        protected ILogger<T> logger;
        protected readonly string PrefixoLog;

        protected BaseService(ILogger<T> logger, string prefixoLog)
        {
            this.logger = logger;
            this.PrefixoLog = prefixoLog;
        }

        protected void Log(LogLevel logLevel, string message, PerformContext context = null, [CallerMemberName] string methodName = null)
        {
            logger.Log(logLevel, $"{PrefixoLog} ({methodName}): {message}");

            if (context != null)
                context.WriteLine(message);
        }
    }
}