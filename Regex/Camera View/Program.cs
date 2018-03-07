using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string view = Console.ReadLine();

            int skip = numbers[0];
            int take = numbers[1];

            string pattern = @"(\|<)([\w]{0,"+skip+@"})([\w]{0,"+take+@"})";

            var matches = Regex.Matches(view,pattern);
            List<string> result = new List<string>();

            foreach (Match match in matches)
            {
                result.Add(match.Groups[3].Value);
            }

            Console.WriteLine(string.Join(", ",result));
        }
    }
}
