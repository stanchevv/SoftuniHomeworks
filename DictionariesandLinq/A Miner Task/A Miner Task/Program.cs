namespace Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string resource = Console.ReadLine();

            var minedItems = new Dictionary<string, int>();
            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (minedItems.ContainsKey(resource) == false)
                {
                    minedItems.Add(resource, 0);
                }
                minedItems[resource] += quantity;

                resource = Console.ReadLine();
            }

            foreach (var item in minedItems)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

        }
    }
}
