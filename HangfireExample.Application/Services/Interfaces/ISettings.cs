namespace HangfireExample.Application.Services.Interfaces
{
    public interface ISettings
    {
        public string FileName { get; }
        public string ConnectionString { get; }
    }
}
