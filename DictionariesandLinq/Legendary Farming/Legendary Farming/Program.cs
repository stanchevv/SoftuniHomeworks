using System;
using System.Collections.Generic;
using System.Linq;


namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var items = new SortedDictionary<string, int>();

            items.Add("shards", 0);
            items.Add("fragments", 0);
            items.Add("motes", 0);

            string currentItem = "";
            int currentQuantity = 0;

            while (items["shards"] < 250 && items["fragments"] < 250 && items["motes"] < 250)
            {
                for (int i = 0; i < input.Length / 2; i++)
                {
                    currentItem = input[i * 2 + 1];
                    currentQuantity = int.Parse(input[i * 2]);

                    if (items.ContainsKey(currentItem) == false)
                    {
                        items.Add(currentItem, currentQuantity);
                        if (items["shards"] >= 250 || items["fragments"] >= 250 || items["motes"] >= 250) break;
                    }
                    else
                    {
                        items[currentItem] += currentQuantity;
                        if (items["shards"] >= 250 || items["fragments"] >= 250 || items["motes"] >= 250) break;
                    }
                }
                if (items["shards"] >= 250 || items["fragments"] >= 250 || items["motes"] >= 250) break;

                input = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (items["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                items["shards"] -= 250;
            }
            else if (items["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                items["fragments"] -= 250;
            }
            else if (items["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                items["motes"] -= 250;
            }

            foreach (var item in items.OrderByDescending(x => x.Value))
            {
                if (item.Value >= 0 && (item.Key == "shards" || item.Key == "fragments" || item.Key == "motes"))
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }

            foreach (var item in items)
            {
                if (item.Value > 0 && (item.Key != "shards" && item.Key != "fragments" && item.Key != "motes"))
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }

        }
    }
}
