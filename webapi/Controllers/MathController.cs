using Microsoft.AspNetCore.Mvc;
using Calc.Models;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{

    private readonly ILogger<MathController> _logger;

    public MathController(ILogger<MathController> logger, MathRequestContext db)
    {
        _logger = logger;
    }

    [Route("/Postfix")]
    [HttpGet]
    public ActionResult<string> GetPolisForm(string mathExpression)
    {
        return Ok(MathUtils.fromInficsToPolis(mathExpression));
    }

    [Route("/Infix")]
    [HttpGet]
    public ActionResult<string> GetInfixForm(string mathExpression)
    {
        return Ok(MathUtils.fromPolisToInfics(mathExpression));
    }

    [Route("/Computing")]
    [HttpGet]
    public ActionResult<double> GetValue(string mathExpression)
    {
        return Ok(MathUtils.calculate(mathExpression));
    }

}
