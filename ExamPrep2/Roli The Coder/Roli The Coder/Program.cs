using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Roli_The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string IDpatten = @"(\d+)";
            string eventPattern = @"((?<=#)[\w-\']+)";
            string participantsPattern = @"(@[\w-\']+)";
            
            var eventsDictionary = new Dictionary<KeyValuePair<string,string>,List<string>>();
            var helpDictionary = new Dictionary<string,string>();

            while (input != "Time for Code")
            {

                if (!(Regex.IsMatch(input, IDpatten)
                && Regex.IsMatch(input, eventPattern)))
                {
                    input = Console.ReadLine();
                    continue;
                }
                

                string eventName = Regex.Match(input, eventPattern).Value;
                string ID = Regex.Match(input, IDpatten).Value;
                var participants = Regex.Matches(input, participantsPattern);

                if (helpDictionary.ContainsKey(ID))
                {
                    if (helpDictionary[ID]!=eventName)
                    {
                        goto Found;
                    }
                }
                

                if (!eventsDictionary.ContainsKey(new KeyValuePair<string,string>(ID,eventName)))
                {
                    eventsDictionary.Add(new KeyValuePair<string, string>(ID, eventName), new List<string>());
                    helpDictionary.Add(ID,eventName);

                    foreach (Match participant in participants)
                    {
                        if (!eventsDictionary[new KeyValuePair<string, string>(ID, eventName)].Contains(participant.Value))
                        {
                            eventsDictionary[new KeyValuePair<string, string>(ID, eventName)].Add(participant.Value);
                        }
                    }
                }
                else 
                {
                    foreach (Match participant in participants)
                    {
                        if (!eventsDictionary[new KeyValuePair<string, string>(ID, eventName)].Contains(participant.Value))
                        {
                            eventsDictionary[new KeyValuePair<string, string>(ID, eventName)].Add(participant.Value);
                        }
                    }
                }

                Found:
                input = Console.ReadLine();
            }

            foreach (var happening in eventsDictionary.OrderByDescending(x=>x.Value.Count))
            {
                
                 Console.WriteLine(happening.Key.Value+" - "+happening.Value.Count);
                foreach (var person in happening.Value.OrderBy(x=>x))
                {
                    Console.WriteLine(person);
                }
                 
            }
        }
    }
}
