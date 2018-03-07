using System;
using System.Text;
using System.Collections.Generic;

namespace Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                output.Append("\\u");
                output.Append(String.Format("{0:x4}", (int)input[i]));
            }

            Console.WriteLine(output.ToString());
        }
    }
}
