namespace PhonebookUpgraded
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var command = Console.ReadLine().Split().ToList();

            var phonebook = new SortedDictionary<string, string>();

            while (command[0] != "END")
            {

                if (command[0] == "A")
                {
                    phonebook[command[1]] = command[2];
                }
                else if (command[0] == "ListAll")
                {
                    foreach (var person in phonebook.OrderBy(x => x.Key))
                    {
                        Console.WriteLine("{0} -> {1}", person.Key, person.Value);
                    }
                }
                else if (command[0] == "S")
                {
                    if (phonebook.ContainsKey(command[1]))
                    {
                        Console.WriteLine("{0} -> {1}", command[1], phonebook[command[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", command[1]);
                    }
                }

                command = Console.ReadLine().Split().ToList();
            }
        }
    }
}
