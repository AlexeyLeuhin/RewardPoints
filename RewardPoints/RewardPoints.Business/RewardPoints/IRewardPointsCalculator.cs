using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPoints.Business.Core.RewardPoints;

public interface IRewardPointsCalculator
{
    int Calculate(int transactionValue);
}
