using HangfireExample.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace HangfireExample.Domain.Interfaces.Repository
{
    public interface ILocationRepository
    {
        Task<bool> AddAsync(IList<Location> location, ILogger logger);
    }
}
