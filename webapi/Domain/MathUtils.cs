namespace Calc.Models;
using System;
public class MathUtils
{
    private static string[] lib = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "(", ")", "+", "-", "*", "/" };
    static string[] result;
    static Table[] check = new Table[6];
    private static void fillTable()
    {
        check[0] = new Table("(", 10);
        check[1] = new Table(")", 0);
        check[2] = new Table("+", 1);
        check[3] = new Table("-", 1);
        check[4] = new Table("*", 2);
        check[5] = new Table("/", 2);
    }
    //Перевод строки из Полиз в инфикс
    public static string fromPolisToInfics(string polis)
    {
        throw new NotImplementedException();
    }

    private class Table
    {
        string oper;
        int weight;
        public Table(string oper1, int weight1)
        {
            oper = oper1;
            weight = weight1;

        }
        public string getOper()
        {
            return oper;
        }
        public int getWeight()
        {
            return weight;
        }
    }


    private static bool isNumber(string a)
    {
        int x = 0;
        if (System.Int32.TryParse(a, out x))
            return true;
        else
            return false;
    }
    //Перевод из инфикс в Полиз
    private static int findWeigth(string a)
    {
        string b;

        for (int i = 0; i < check.Length; i++)
        {
            if (a == check[i].getOper())
            {
                return check[i].getWeight();
            }
        }
        return -1;
    }
    public static string fromInficsToPolis(string infics)
    {
        result = new string[infics.Length];
        for (int i = 0; i < result.Length; i++)
        { result[i] = "0"; }
        string[] line = infics.Split(" ");
        string[] stack = new string[line.Length];
        int indR = 0;
        int indS = 0;
        if (isPolis(infics))
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (isNumber(line[i]))
                {
                    result[indR] = line[i];
                    indR++;
                }
                else
                {
                    stack[indS] = line[i];
                    for (int j = 0; j < stack.Length; j++)
                    {
                        if (findWeigth(stack[j]) >= findWeigth(line[i]))
                        {
                            result[indR] = stack[j];
                            stack[i] = "0";
                        }
                    }
                }
            }
        }
        return string.Join("", result);
    }
    public void outputPolis()
    {
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
    //Проверка строки на наличие лишних символов, лучше назвать isCorrect
    private static bool isPolis(string polis)
    {
        bool a = false;
        string[] line = polis.Split(" ");
        for (int i = 0; i < line.Length; i++)
        {
            for (int j = 0; j < lib.Length; j++)
            {
                if (line[i] == lib[j])
                {
                    a = true;
                    break;
                }
                else
                    a = false;
            }
            if (a == false)
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