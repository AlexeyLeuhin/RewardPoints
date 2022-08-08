using MediatR;
using Microsoft.AspNetCore.Mvc;
using RewardPoints.Business.Core.RewardPoints.Queries;

namespace RewardPoints.Controllers;

[Route("api/[controller]")]
public class RewardPointsController : Controller
{
    private readonly IMediator mediator;

    public RewardPointsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRewardPointsReport(GetRewardPointsReport.Query query)
    {
        var file = await mediator.Send(query);

        return File(file.Data, file.ContentType, file.FileName);
    }
}
