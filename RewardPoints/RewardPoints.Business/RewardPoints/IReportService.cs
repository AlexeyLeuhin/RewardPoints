using RewardPoints.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPoints.Business.Core.RewardPoints;

public interface IReportService
{
    public FileModel GenerateRewardPointsReport(IEnumerable<RewardPointsReportModel> reportModels);
}
