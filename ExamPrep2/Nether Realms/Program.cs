using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var daemonNames = input.Split(new char[] {' ',',' },StringSplitOptions.RemoveEmptyEntries);
            int currentHealth = 0;
            double currentDamage = 0;

            var lettersPattern = @"[^=0-9-+*\/.]";
            var digitsPattern = @"[-+]*\d+\.*\d*";
            var multipliersPattern = @"[*\/]";

            var Daemons = new Dictionary<string,List<double>>();

            foreach (var daemonName in daemonNames)
            {
                var letters = Regex.Matches(daemonName,lettersPattern);
                var digits = Regex.Matches(daemonName,digitsPattern);
                var multipliers = Regex.Matches(daemonName,multipliersPattern);

                if (Regex.IsMatch(daemonName,lettersPattern))
                {
                    foreach (Match letter in letters)
                    {
                        char current = letter.Value[0];
                        currentHealth += current;
                    }
                }

                if (Regex.IsMatch(daemonName, digitsPattern))
                {
                    foreach (Match digit in digits)
                    {
                        double current = double.Parse(digit.Value);
                        currentDamage += current;
                    }

                    foreach (Match multi in multipliers)
                    {
                        if (multi.Value=="*")
                        {
                            currentDamage *= 2;
                        }
                        else
                        {
                            currentDamage /= 2;
                        }
                    }
                }

                Daemons.Add(daemonName,new List<double>());
                Daemons[daemonName].Add(currentHealth);
                Daemons[daemonName].Add(currentDamage);

                currentDamage = 0;
                currentHealth = 0;

                
            }

            foreach (var daemon in Daemons.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{daemon.Key} - {daemon.Value[0]} health, {daemon.Value[1]:F2} damage");
            }
        }
    }
}
