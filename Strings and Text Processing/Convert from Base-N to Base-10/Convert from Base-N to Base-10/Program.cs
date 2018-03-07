using System;
using System.Text;
using System.Linq;
using System.Numerics;

namespace Convert_from_Base_10_to_Base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            int n = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);

            var sb = new StringBuilder();
            int power = 0;
            BigInteger output = 0;

            while (number > 0)
            {
                int current = (int)(number % 10);
                number = number / 10;
                output += current * BigInteger.Pow(n, power);
                power++;

            }

            Console.WriteLine(output);


        }
    }
}
