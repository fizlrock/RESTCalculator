using Microsoft.EntityFrameworkCore;
namespace Calc.Models;


public class InfixPOLISPair
{
    public required string Infix { get; set; }
    public required string POLIS { get; set; }
    public MathResult? Result { get; set; }
}
