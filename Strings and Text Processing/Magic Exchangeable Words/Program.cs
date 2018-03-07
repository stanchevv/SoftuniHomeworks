using System;
using System.Collections.Generic;
using System.Linq;


namespace Magic_Exchangeable_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            string firstWord = input[0];
            string secondWord = input[1];

            int l1 = firstWord.ToCharArray().Distinct().Count();
            int l2 = secondWord.ToCharArray().Distinct().Count();

            if (l1==l2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }




        }
    }
}
