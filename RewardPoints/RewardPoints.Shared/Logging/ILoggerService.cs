namespace RewardPoints.Shared.Logging;

public interface ILoggerService
{
    void LogInformation(string message);

    void LogError(Exception ex);
}
