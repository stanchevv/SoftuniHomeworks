using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace extract_emails
{
    class Program
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();
            string text = Console.ReadLine();

            var sentences = text.Split(new char[] { '.','!','?'},StringSplitOptions.RemoveEmptyEntries).ToArray();
            string pattern = $@"\b{word}\b";

            foreach (string sentence in sentences)
            {
                if (Regex.IsMatch(sentence,pattern))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
