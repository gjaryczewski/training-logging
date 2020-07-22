using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace LoggingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logSettings = new EventLogSettings
            {
                Filter = (source, level) => level >= LogLevel.Trace
            };

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole()
                    .AddEventLog(logSettings);
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation(1234, "Example log information message");
            logger.LogWarning(5678, "Example log warning message");
        }
    }
}
