using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calc.Models;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{

    private readonly ILogger<MathController> _logger;
    private MathRequestContext db;

    public MathController(ILogger<MathController> logger, MathRequestContext db)
    {
        _logger = logger;
        this.db = db;
    }

    [Route("Postfix")]
    [HttpGet]
    public string GetPolisForm(string mathExpression)
    {
        _logger.LogWarning($"Запрос на преобразование строки в ПОЛИЗ. mathExpression:{mathExpression}");
        db.MathRequests.Add(
                new MathRequest() { 
								PolisForm = "",
								PostfixForm = mathExpression
								}
                );
				db.SaveChanges();

        //return MathUtils.fromInficsToPolis(mathExpression);
        return "arst";
    }

    [Route("Infix")]
    [HttpGet]
    public string GetInfixForm(string mathExpression)
    {
        return "здесь тоже что то будет";
    }

    [Route("Computing")]
    [HttpGet]
    public double GetValue(string mathExpression)
    {
        return 0;
    }

}
