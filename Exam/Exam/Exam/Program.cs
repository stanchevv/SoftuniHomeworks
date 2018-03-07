using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            string keyPartsPattern = @"([starSTAR])";

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string message = Console.ReadLine();
                var keyLetters = Regex.Matches(message,keyPartsPattern);
                int key = keyLetters.Count;

                var decryptedMessage = new StringBuilder();
                for (int j = 0; j < message.Length; j++)
                {
                    decryptedMessage.Append(Convert.ToChar(message[j] - key));
                }

                string validMessagePattern = @"@([a-zA-Z]+).*:(\d+).*!([AD])!.*->(\d+)";
                

                if (Regex.IsMatch(decryptedMessage.ToString(),validMessagePattern)==false)
                {
                    continue;
                }

                var messageMatch = Regex.Match(decryptedMessage.ToString(), validMessagePattern);

                
                if (messageMatch.Groups[3].Value=="D")
                {
                    destroyedPlanets.Add(messageMatch.Groups[1].Value);
                }
                else if(messageMatch.Groups[3].Value == "A")
                {
                    attackedPlanets.Add(messageMatch.Groups[1].Value);
                }


            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
