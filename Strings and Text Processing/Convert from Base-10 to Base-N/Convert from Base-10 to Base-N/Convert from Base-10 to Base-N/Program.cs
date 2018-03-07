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

            while (number > 0)
            {
                int current = (int)(number % n);
                number = number / n;
                sb.Insert(0,current);
                
            }

            string output = sb.ToString();
            Console.WriteLine(output);
        }
    }
}
