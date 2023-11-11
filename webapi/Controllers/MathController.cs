using Microsoft.AspNetCore.Mvc;
using Calc.Models;

namespace webapi.Controllers;

[ApiController]


public class MathController : ControllerBase
{

    private readonly ILogger<MathController> _logger;

    public MathController(ILogger<MathController> logger)
    {
        _logger = logger;
    }

    [Route("Math/Postfix")]
    [HttpGet]
    public string GetPolisForm(string mathExpression)
    {
				_logger.LogWarning($"Запрос на преобразование строки в ПОЛИЗ. mathExpression:{mathExpression}");
        return "здесь что то будет";
    }

    [Route("Math/Infix")]
    [HttpGet]
    public string GetInfixForm(string mathExpression)
    {
        return "здесь тоже что то будет";
    }

    [Route("Math/Computing")]
    [HttpGet]
    public double GetToValue(string mathExpression)
    {
        return 0;
    }

}
