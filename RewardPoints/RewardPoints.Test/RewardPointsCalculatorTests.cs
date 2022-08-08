using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RewardPoints.Business.Core.RewardPoints;
using RewardPoints.Business.Core.RewardPoints.Queries;
using RewardPoints.Controllers;
using RewardPoints.Data;
using RewardPoints.Data.Models;
using RewardPoints.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RewardPoints.Test;

public class RewardPointsCalculatorTests
{
    private IOptions<RewardPointsSettings> settings;

    [SetUp]
    public void Setup()
    {
        var mockedRewardPointsSettings = new RewardPointsSettings
        {
            Items = new List<RewardPointsSettingsItem>
            {
                new RewardPointsSettingsItem
                {
                    ControlValue = 50,
                    BonusForEachExtraDollar = 1
                },
                new RewardPointsSettingsItem
                {
                    ControlValue = 100,
                    BonusForEachExtraDollar = 1
                }
            }
        };
        settings = Options.Create(mockedRewardPointsSettings);
    }

    [TestCase(56, 6)]
    [TestCase(110, 70)]
    [TestCase(49, 0)]
    public void CalculateRewardPointsSettings_ShouldReturnCorrectRewardPointsAmount(int transactionValue, int correctResult)
    {
        var calculator = new RewardPointsCalculator(settings);

        Assert.AreEqual(correctResult, calculator.Calculate(transactionValue));
    }
}