using Microsoft.Extensions.Options;
using RewardPoints.Data.Models;
using RewardPoints.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPoints.Business.Core.RewardPoints;

public class RewardPointsCalculator : IRewardPointsCalculator
{
    public readonly RewardPointsSettings rewardPointsSettings;

    public RewardPointsCalculator(IOptions<RewardPointsSettings> rewardPointsSettings)
    {
        this.rewardPointsSettings = rewardPointsSettings.Value;
    }

    public int Calculate(int transactionValue)
    {
        int pointsSum = 0;
        
        foreach(var settingItem in rewardPointsSettings.Items)
        {
            if (transactionValue < settingItem.ControlValue)
            {
                return pointsSum;
            }

            pointsSum += (transactionValue - settingItem.ControlValue) * settingItem.BonusForEachExtraDollar;
        }

        return pointsSum;
    }
}
