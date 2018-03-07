using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factoriel = 1;

            for (int i = 1; i <= n; i++)
            {
                factoriel *= i;
            }

            int numberOf0 = 0;

            while (factoriel%10==0)
            {
                numberOf0++;
                factoriel /= 10;
                
            }

            Console.WriteLine(numberOf0);

        }

    }
}

        

 
