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
    public string GetPolisForm(string mathExpression)
    {
				_logger.LogWarning($"Запрос на преобразование строки в ПОЛИЗ. mathExpression:{mathExpression}");
        return MathUtils.fromInficsToPolis(mathExpression);
    }

    [Route("/Infix")]
    [HttpGet]
    public string GetInfixForm(string mathExpression)
    {
        return MathUtils.fromPolisToInfics(mathExpression);
    }

    [Route("/Computing")]
    [HttpGet]
    public double GetValue(string mathExpression)
    {
        return MathUtils.calculate(mathExpression);
    }

}
