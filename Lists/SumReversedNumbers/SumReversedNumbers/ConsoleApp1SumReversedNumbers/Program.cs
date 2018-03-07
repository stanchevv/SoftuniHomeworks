using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string reverse = "";
                var charArray = input[i].ToCharArray();

                for (int j = 0; j < charArray.Length; j++)
                {
                    reverse += charArray[charArray.Length - 1 - j];
                }
                sum += int.Parse(reverse);
            }

            Console.WriteLine(sum);
        }
    }
}
