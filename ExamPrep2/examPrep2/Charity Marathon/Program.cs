using System;

namespace Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            long marathonDays = long.Parse(Console.ReadLine());
            long runnersTotal = long.Parse(Console.ReadLine());
            long lapsPerRunner = long.Parse(Console.ReadLine());
            long trackLenght = long.Parse(Console.ReadLine());
            long trackCapacity = long.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            long actualRunners = 0;

            if (marathonDays*trackCapacity<=runnersTotal)
            {
                actualRunners = marathonDays * trackCapacity;
            }
            else
            {
                actualRunners = runnersTotal;
            }

            decimal kilometers = actualRunners * lapsPerRunner * trackLenght*0.001m;

            Console.WriteLine("Money raised: {0:F2}",kilometers*moneyPerKilometer);
            
        }
    }
}
