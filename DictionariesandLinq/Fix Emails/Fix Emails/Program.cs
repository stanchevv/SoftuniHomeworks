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

            var minedItems = new Dictionary<string, string>();

            while (resource != "stop")
            {
                string quantity = Console.ReadLine();

                if (minedItems.ContainsKey(resource) == false)
                {
                    minedItems.Add(resource, "");
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
