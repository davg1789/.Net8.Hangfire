using HangfireExample.Application.Services.Interfaces;
using HangfireExample.Domain.Entities;
using HangfireExample.Domain.Interfaces.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace HangfireExample.Infrastructure.Data.SqlServer.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ISettings settings;

        public LocationRepository(ISettings settings)
        {
            this.settings = settings;
        }
        public async Task<bool> AddAsync(IList<Location> locations, ILogger logger)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    connection.Open();
                    foreach (var location in locations)
                    {                        
                        string query = "INSERT INTO Location (Name) VALUES (@Name)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", location.Name);
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message} - {ex.StackTrace}");
                return false;
            }
        }
    }
}
