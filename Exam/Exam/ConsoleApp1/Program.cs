using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string,List<string>>();
            string input = Console.ReadLine();
            string pattern = @"(.+)([|\-][>]*)(.+)";

            while (input!= "Lumpawaroo")
            {
                var inputMatch = Regex.Match(input,pattern);
                string forceUser = "";
                string forceSide = "";

                if (inputMatch.Groups[2].Value=="|")
                {
                    forceUser = inputMatch.Groups[3].Value.Trim();
                    forceSide = inputMatch.Groups[1].Value.Trim();
                }
                else if (inputMatch.Groups[2].Value == "->")
                {
                    forceUser = inputMatch.Groups[1].Value.Trim();
                    forceSide = inputMatch.Groups[3].Value.Trim();
                }

                if (inputMatch.Groups[2].Value == "|")
                {
                    if (!data.ContainsKey(forceSide))
                    {
                        data.Add(forceSide,new List<string>());

                        if (!data[forceSide].Contains(forceUser))
                        {
                            data[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        if (!data[forceSide].Contains(forceUser))
                        {
                            data[forceSide].Add(forceUser);
                        }
                    }
                }
                else if (inputMatch.Groups[2].Value == "->")
                {

                    foreach (var force in data)
                    {
                        if (force.Value.Contains(forceUser))
                        {
                            force.Value.Remove(forceUser);
                        }
                    }

                    if (!data.ContainsKey(forceSide))
                    {
                        data.Add(forceSide, new List<string>());

                        if (!data[forceSide].Contains(forceUser))
                        {
                            data[forceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                    }
                    else
                    {
                        if (!data[forceSide].Contains(forceUser))
                        {
                            data[forceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                        }
                    }
                }

                input = Console.ReadLine();

            }

            foreach (var force in data.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (force.Value.Count>0)
                {
                    Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                    foreach (var user in force.Value.OrderBy(x => x))
                    {
                        Console.WriteLine("! "+ user);
                    }
                }
            }
        }
    }
}
