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
        _logger.LogInformation($"Запрос на преобразование строки в ПОЛИЗ. mathExpression:{mathExpression}");

        string result = "";

        var db_value = db.InfixPOLISPairs.Where(p => p.Infix.Equals(mathExpression)).SingleOrDefault();

        if (db_value != null)
        {
            _logger.LogInformation($"Выражение {mathExpression} найдено в БД");
            result = db_value.POLIS;
        }
        else
        {
            _logger.LogInformation($"Вычисление ПОЛИЗ для {mathExpression}");
            result = MathUtils.fromInficsToPolis(mathExpression);
            db.InfixPOLISPairs.Add(
                    new InfixPOLISPair()
                    {
                        POLIS = result,
                        Infix = mathExpression
                    }
                    );
            db.SaveChanges();

        }

        return Ok(result);
    }

    [Route("Infix")]
    [HttpGet]
    public ActionResult<string> GetInfixForm(string mathExpression)
    {

        _logger.LogInformation($"Запрос на преобразование строки в ПОЛИЗ. mathExpression:{mathExpression}");

        string result = "";

        var db_value = db.InfixPOLISPairs.Where(p => p.POLIS.Equals(mathExpression)).SingleOrDefault();

        if (db_value != null)
        {
            _logger.LogInformation($"Выражение {mathExpression} найдено в БД");
            result = db_value.Infix;
        }
        else
        {
            _logger.LogInformation($"Вычисление инфиксной формы для {mathExpression}");
            result = MathUtils.fromInficsToPolis(mathExpression);
            db.InfixPOLISPairs.Add(
                    new InfixPOLISPair()
                    {
                        POLIS = mathExpression,
                        Infix = result
                    }
                    );
            db.SaveChanges();

        }

        return Ok(result);

    }

    [Route("Computing")]
    [HttpGet]
    public ActionResult<double> GetValue(string mathExpression)
    {
        //return Ok(MathUtils.calculate(mathExpression));
        return Ok("временно");
    }

}
