namespace Calc.Models;
public class MathUtils
{
    private string [] lib  = {'1','2','3','4','5','6','7','8','9','0','(',')','+','-','*','/'};

    //Перевод строки из Полиз в инфикс
    public static string fromPolisToInfics(string polis)
    {
        // if (isPolis(polis))
        // {

        // }
        // else
        // {

        // }
        throw new NotImplementedException();
    }
    
    private static class Table (string oper1, int weight1)
    {
        string oper = oper1;
        int weight = weight1;
    } 

    private static bool isNumber (string a)
    {
        int x = 0;
        if (Int32.TryParse(a, out x))
            return true;
    }
    //Перевод из инфикс в Полиз
    public static string fromInficsToPolis(string infics)
    {
        Table[] check = new Table[]{
            ('(', 10), 
            (')', 0), 
            ('+', 1), 
            ('-', 1), 
            ('*', 2), 
            ('/', 2) };

        string [] line = infics.split([separator[]]);

        if(isPolis(infics))
        {
            
        }

        throw new NotImplementedException();
    }
    //Проверка строки на наличие лишних символов, лучше назвать isCorrect
    private bool isPolis(string polis)
    {
        bool a = 0;
        string [] line = infics.split([separator[]]);
        for (int i = 0; i<line.Length; i++)
        {
            for (int j = 0; j<lib.Length; i++)
            {
                if (line[i] == lib[j])
                    a = 1;
            }
            if (a == 0)
                break;
        }
        return a;
    }
    public static double calculate(string infics)
    {
        throw new NotImplementedException();
    }

}
//throw new NotImplementedException();