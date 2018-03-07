using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        Console.WriteLine(SumBigNumbers(firstNumber, secondNumber));
    }

    public static String SumBigNumbers(String firstNumber, String secondNumber)
    {

        var sb = new StringBuilder();

        int currentSum = 0;
        int remainder = 0;

        if (firstNumber.Length > secondNumber.Length)
        {
            secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
        }
        else if (firstNumber.Length < secondNumber.Length)
        {
            firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
        }

        if (FullOfZeros(firstNumber, secondNumber))
        {
            return "0";
        }

        for (int i = firstNumber.Length - 1; i >= 0; i--)
        {
            currentSum = ((int)Char.GetNumericValue(firstNumber[i]) +
                   ((int)Char.GetNumericValue(secondNumber[i]) + remainder));
            sb.Insert(0, (currentSum % 10).ToString());
            remainder = 0;
            if (currentSum > 9)
            {
                remainder = 1;
            }

        }

        if (remainder == 1)
        {
            sb.Insert(0, 1.ToString());
        }

        return (sb.ToString().TrimStart('0'));
    }

    public static Boolean FullOfZeros(String firstNumber, string secondNumber)
    {
        for (int i = 1; i < 10; i++)
        {
            if (firstNumber.Contains(i.ToString()) || secondNumber.Contains(i.ToString()))
            {
                return false;
            }
        }
        return true;
    }
}