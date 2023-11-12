
namespace Calc.Models;


public class MathRequest
{
    public int MathRequestId { get; set; }
    public string PolisForm { get; set; }
    public string PostfixForm { get; set; }
    public double Result { get; set; }

    public override string? ToString()
    {
        return $"{MathRequestId} {PostfixForm}={Result}";
    }
}
