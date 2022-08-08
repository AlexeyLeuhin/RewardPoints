using MediatR;
using RewardPoints;
using RewardPoints.Business.Core.RewardPoints;
using RewardPoints.Business.Core.RewardPoints.Queries;
using RewardPoints.Data;
using RewardPoints.Data.Models;
using RewardPoints.Shared;
using RewardPoints.Shared.Logging;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRewardPointsCalculator, RewardPointsCalculator>();
builder.Services.AddScoped<IStorageContext, CsvStorageContext>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddSingleton<ILoggerService, LoggerService>();

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(GetRewardPointsReport).GetTypeInfo().Assembly);
builder.Services.Configure<RewardPointsSettings>(builder.Configuration.GetSection(nameof(RewardPointsSettings)));
builder.Services.AddHealthChecks();

var app = builder.Build();

app.Services.GetRequiredService<ILoggerFactory>().AddFile(Constants.LogsFilePath);

app.UseRouting();
app.UseMiddleware<ErrorWrappingMiddleware>();
app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();
