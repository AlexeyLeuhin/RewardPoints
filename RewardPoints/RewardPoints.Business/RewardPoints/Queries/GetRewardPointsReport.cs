using MediatR;
using RewardPoints.Data;
using RewardPoints.Data.Models;
using RewardPoints.Shared;
using RewardPoints.Shared.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPoints.Business.Core.RewardPoints.Queries;

public class GetRewardPointsReport
{
    public class Query : IRequest<FileModel>
    {

    }

    public class Handler : IRequestHandler<Query, FileModel>
    {
        private readonly IStorageContext storageContext;
        private readonly IRewardPointsCalculator rewardPointsCalculator;
        private readonly IReportService reportService;
        private readonly ILoggerService logger;
        
        public Handler(
            IStorageContext storageContext,
            IRewardPointsCalculator rewardPointsCalculator,
            IReportService reportService,
            ILoggerService logger)
        {
            this.storageContext = storageContext;
            this.rewardPointsCalculator = rewardPointsCalculator;
            this.reportService = reportService;
            this.logger = logger;
        }

        public Task<FileModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var customers = storageContext.GetCustomers();
            var transactions = storageContext.GetTransactions();

            var reportDataModels = GetReportDataModels(customers, transactions);
            var report = reportService.GenerateRewardPointsReport(reportDataModels);

            logger.LogInformation(Constants.RewardPointsReportWasGeneratedMessage);

            return Task.FromResult(report);
        }

        private IEnumerable<RewardPointsReportModel> GetReportDataModels(IEnumerable<Customer> customers, IEnumerable<Transaction> transactions)
        {
            return customers.GroupJoin(
                transactions,
                c => c.Id,
                t => t.CustomerId,
                (customer, transactions) => new RewardPointsReportModel
                {
                    CustomerName = customer.Name,
                    FirstMonthRewardPoints = GetRewardPointsForMonth(1, transactions),
                    SecondMonthRewardPoints = GetRewardPointsForMonth(2, transactions),
                    ThirdMonthRewardPoints = GetRewardPointsForMonth(3, transactions),
                    TotalRewardPoints = transactions.Sum(t => rewardPointsCalculator.Calculate(t.Value))
                });
        }

        private int GetRewardPointsForMonth(int monthNumber, IEnumerable<Transaction> transactions)
        {
            return transactions.Where(t => t.Date.Month == monthNumber).Sum(t => rewardPointsCalculator.Calculate(t.Value));
        }
    }
}
