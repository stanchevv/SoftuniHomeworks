using System;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            string firstWord = input[0];
            string secondWord = input[1];

            long sum = 0;

            for (int i = 0; i < Math.Min(firstWord.Length,secondWord.Length); i++)
            {
                sum += firstWord[i] * secondWord[i];
            }

            if (firstWord.Length!=secondWord.Length)
            {
                if (firstWord.Length > secondWord.Length)
                {
                    for (int i = secondWord.Length; i < firstWord.Length; i++)
                    {
                        sum += firstWord[i];
                    }
                }
                else
                {
                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        sum += secondWord[i];
                    }
                }
            }

            Console.WriteLine(sum);

        }
    }
}
