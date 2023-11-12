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
        db.MathRequests.Add(

                new MathRequest() { 
								PolisForm = "",
								PostfixForm = mathExpression
								}
                );
				db.SaveChanges();

        //return Ok(MathUtils.fromInficsToPolis(mathExpression));
         return Ok("временно");
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
