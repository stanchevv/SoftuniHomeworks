using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamPreparation1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" -> ");

            var pokemons = new Dictionary<string,List<KeyValuePair<string,int>>>();
            while (input[0]!= "wubbalubbadubdub")
            {
                if (input.Length>1)
                {
                    if (!pokemons.ContainsKey(input[0]))
                    {
                        pokemons.Add(input[0],new List<KeyValuePair<string, int>>());
                        pokemons[input[0]].Add(new KeyValuePair<string, int>(input[1], int.Parse(input[2])));
                    }
                    else
                    {
                        pokemons[input[0]].Add(new KeyValuePair<string, int>(input[1], int.Parse(input[2])));
                    }
                }
                else
                {
                    if (pokemons.ContainsKey(input[0]))
                    {
                        Console.WriteLine($"# {input[0]}");
                        foreach (var evolution in pokemons[input[0]])
                        {
                            Console.WriteLine($"{evolution.Key} <-> {evolution.Value}");
                        }
                    }
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var evolution in pokemon.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{evolution.Key} <-> {evolution.Value}");
                }
            }



        }
    }
}
