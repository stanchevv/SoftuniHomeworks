using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Anonymous_Downsite
{
    class Program
    {

        static void Main(string[] args)
        {
            int numberOfSites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            var siteNames = new List<string>();
            decimal totalLosses = 0;

            for (int i = 0; i < numberOfSites; i++)
            {
                var input = Console.ReadLine().Split(' ');
                siteNames.Add(input[0]);
                totalLosses += long.Parse(input[1]) * decimal.Parse(input[2]);
            }

            for (int i = 0; i < siteNames.Count; i++)
            {
                Console.WriteLine(siteNames[i]);
            }

            Console.WriteLine($"Total Loss: {totalLosses:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey,numberOfSites)}");
        }
    }
}
