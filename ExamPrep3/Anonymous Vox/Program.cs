using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var values = Console.ReadLine().Split('{');
            
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].TrimEnd('}');
            }

            string pattern = @"([A-Za-z]+)(.+)(\1)";

            var matches = Regex.Matches(input, pattern);
            int counter = 1;
            foreach (Match item in matches)
            {
                int startIndex = input.IndexOf(item.Groups[2].Value);
                if (counter<values.Length)
                {
                    input = input.Remove(startIndex, item.Groups[2].Value.Length);
                    input = input.Insert(startIndex, values[counter]);
                }

                counter++;

            }

            Console.WriteLine(input);

        }
    }
}
