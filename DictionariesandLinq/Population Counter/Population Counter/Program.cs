using System;
using System.Collections.Generic;
using System.Linq;


namespace Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var countries = new Dictionary<string, Dictionary<string, long>>();

            string country = "";
            string city = "";
            long cityPopulation = 0;

            while (command[0] != "report")
            {
                country = command[1];
                city = command[0];
                cityPopulation = int.Parse(command[2]);
                if (countries.ContainsKey(country) == false)
                {
                    countries.Add(country, new Dictionary<string, long>());
                }

                if (countries[country].ContainsKey(city) == false)
                {
                    countries[country].Add(city, cityPopulation);
                }
                else
                {
                    countries[country][city] += cityPopulation;
                }

                command = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            }



            foreach (var state in countries.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{state.Key} (total population: {state.Value.Values.Sum()})");
                foreach (var town in state.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }
            }

        }
    }
}
