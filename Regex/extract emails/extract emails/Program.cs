using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace extract_emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(?<=\s|^)([a-z\d]+[\._-]*[a-z\d]+)@([a-z]+[a-z-]*(\.[a-z]+)+)");

            string text = Console.ReadLine();
            MatchCollection matches = pattern.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
