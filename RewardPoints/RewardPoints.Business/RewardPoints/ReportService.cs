using CsvHelper;
using RewardPoints.Data.Models;
using RewardPoints.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPoints.Business.Core.RewardPoints;

public class ReportService : IReportService
{
    public FileModel GenerateRewardPointsReport(IEnumerable<RewardPointsReportModel> reportModels)
    {
        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(reportModels);
            csvWriter.Flush();

            return new FileModel
            {
                Data = memoryStream.ToArray(),
                FileName = Constants.RewardPointsReportFileName,
                ContentType = Constants.CsvContentType
            };
        }
    }
}
