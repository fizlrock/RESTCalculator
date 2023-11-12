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
    public ActionResult<string> GetPolisForm(string mathExpression)
    {
        _logger.LogWarning($"Запрос на преобразование строки в ПОЛИЗ. mathExpression:{mathExpression}");

        string result = "";

        var db_value = db.InfixPOLISPairs.Where(p => p.Infix.Equals(mathExpression)).SingleOrDefault();

        if (db_value != null)
            result = db_value.POLIS;
        else
        {
						result = MathUtils.fromInficsToPolis(mathExpression);

        }


        //return Ok(MathUtils.fromInficsToPolis(mathExpression));
        return Ok(result);
    }

    [Route("Infix")]
    [HttpGet]
    public ActionResult<string> GetInfixForm(string mathExpression)
    {
        // return Ok(MathUtils.fromPolisToInfics(mathExpression));
        return Ok("временно");
    }

    [Route("Computing")]
    [HttpGet]
    public ActionResult<double> GetValue(string mathExpression)
    {
        //return Ok(MathUtils.calculate(mathExpression));
        return Ok("временно");
    }

}
