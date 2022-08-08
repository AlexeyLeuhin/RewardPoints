using RewardPoints.Shared.Exceptions;
using RewardPoints.Shared.Logging;
using System.Net;

namespace RewardPoints;

public class ErrorWrappingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILoggerService logger;

    public ErrorWrappingMiddleware(RequestDelegate next, ILoggerService logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (StorageFileNotFoundException ex)
        {
            logger.LogError(ex);
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
