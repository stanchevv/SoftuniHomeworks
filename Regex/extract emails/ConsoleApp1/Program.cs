using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPattern = @"^([a-zA-Z]+)(?=[<\|\\])";
            string endPattern = @"(?<=[\<\|\\])([a-zA-Z]+\z)";

            string key = Console.ReadLine();
            string input = Console.ReadLine();
            var start = Regex.Match(key, startPattern).Value;
            var end = Regex.Match(key, endPattern).Value;


            string extractor = $@"{start}(?!{end})(.*?){end}";

            var matches = Regex.Matches(input,extractor);
            List<string> result = new List<string>();

            if (Regex.IsMatch(input,extractor))
            {
                foreach (Match match in matches)
                {
                    result.Add(match.Groups[1].Value);
                }

                Console.WriteLine(string.Join("", result));

            }
            else
            {
                Console.WriteLine("Empty result");
            }




        }
    }
}
