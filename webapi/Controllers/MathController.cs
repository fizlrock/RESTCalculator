using Microsoft.AspNetCore.Mvc;

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
    public string GetToPolis(string mathExpression)
    {
        return "здесь что то будет";
    }

    [Route("Math/Infix")]
    [HttpGet]
    public string GetToInfix(string mathExpression)
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
