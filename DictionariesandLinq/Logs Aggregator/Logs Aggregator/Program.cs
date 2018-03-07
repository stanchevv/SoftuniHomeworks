using System;
using System.Collections.Generic;
using System.Linq;


namespace Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var users = new SortedDictionary<string, SortedDictionary<string, int>>();

            string user = "";
            string IP = "";
            int secondsVisit = 0;

            for (int i = 0; i < n; i++)
            {
                user = command[1];
                IP = command[0];
                secondsVisit = int.Parse(command[2]);
                if (users.ContainsKey(user) == false)
                {
                    users.Add(user, new SortedDictionary<string, int>());

                }


                if (users[user].ContainsKey(IP) == false)
                {
                    users[user].Add(IP, secondsVisit);
                }
                else
                {
                    users[user][IP] += secondsVisit;
                }

                command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            int totalTime = 0;

            foreach (var person in users.OrderBy(x => x.Key))
            {
                foreach (var adress in person.Value)
                {
                    totalTime += adress.Value;
                }
                Console.WriteLine(person.Key + ": " + totalTime + " [" + string.Join(", ", person.Value.Keys) + "]");
                totalTime = 0;

            }

        }
    }
}
