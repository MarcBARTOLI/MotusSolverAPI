using Microsoft.AspNetCore.Mvc;
using MotusSolverAPI.Records;
using MotusSolverAPI.Services;

namespace MotusSolverAPI;

[ApiController]
[Route("api/[controller]/[action]")]
public class SolverController : ControllerBase
{
    private readonly ISolverService _solverService;

    public SolverController(ILogger<SolverController> logger, ISolverService solverService)
    {
        _solverService = solverService;
    }

    [HttpPost]
    public ActionResult<char> RequestHint([FromBody] WordInput input)
    {
        var result = _solverService.GetHint(input);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<List<Prediction>> RequestPredictions([FromBody] WordInput input)
    {
        var result = _solverService.GetPredictions(input);
        return Ok(result);
    }
}