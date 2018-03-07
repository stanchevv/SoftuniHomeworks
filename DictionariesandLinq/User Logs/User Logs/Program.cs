using System;
using System.Collections.Generic;
using System.Linq;


namespace User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);


            var users = new SortedDictionary<string, Dictionary<string, int>>();
            string userName = "";
            string IP = "";

            while (command[0] != "end")
            {
                IP = command[1];
                userName = command[5];

                if (users.ContainsKey(userName) == false)
                {
                    users.Add(userName, new Dictionary<string, int>());
                    if (users[userName].ContainsKey(IP) == false)
                    {
                        users[userName].Add(IP, 1);

                    }
                    else
                    {
                        users[userName][IP]++;
                    }
                }
                else
                {
                    if (users[userName].ContainsKey(IP) == false)
                    {
                        users[userName].Add(IP, 1);

                    }
                    else
                    {
                        users[userName][IP]++;
                    }
                }
                command = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var user in users)
            {
                Console.WriteLine("{0}: ", user.Key);
                var helper = new List<string>();
                foreach (var IPUsage in users[user.Key])
                {
                    helper.Add($"{IPUsage.Key} => {IPUsage.Value}");
                }
                Console.Write(string.Join(", ", helper));
                Console.WriteLine(".");
            }
        }
    }
}
