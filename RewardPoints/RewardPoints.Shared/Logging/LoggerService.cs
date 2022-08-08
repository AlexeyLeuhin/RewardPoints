using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPoints.Shared.Logging;

public class LoggerService : ILoggerService
{
    private readonly ILogger<LoggerService> logger;

    public LoggerService(ILogger<LoggerService> logger)
    {
        this.logger = logger;
    }

    public void LogInformation(string message)
    {
        logger.LogInformation(DateTime.UtcNow + " " + message);
    }

    public void LogError(Exception ex)
    {
        logger.LogError(DateTime.UtcNow + "\n" + ex.Message + "\n" + ex.StackTrace);
    }
}
