using System;
using System.Collections.Generic;
using System.Linq;

namespace Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLenght = int.Parse(Console.ReadLine());
            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var bugsArray = new int[arrayLenght];

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] >= 0 && indexes[i] < bugsArray.Length)
                {
                    bugsArray[indexes[i]] = 1;
                }
            }



            while (true)
            {
                var commandText = Console.ReadLine();
                var command = commandText.Split();

                if (commandText == "end")
                {
                    break;
                }

                int startPosition = int.Parse(command[0]);
                int movement = int.Parse(command[2]);
                string direction = command[1];

                if (direction == "left")
                {
                    movement *= -1;
                }


                if (startPosition < 0 || startPosition >= arrayLenght)
                {
                    continue;
                }
                if (bugsArray[startPosition] == 0)
                {
                    continue;
                }

                bugsArray[startPosition] = 0;
                long currentPosition = startPosition;


                while (true)
                {
                    currentPosition += movement;

                    if (currentPosition < 0 || currentPosition >= arrayLenght)
                    {
                        break;
                    }

                    if (bugsArray[currentPosition] == 1)
                    {
                        continue;
                    }

                    bugsArray[currentPosition] = 1;
                    break;

                }

            }



            Console.WriteLine(String.Join(" ", bugsArray));



        }
    }
}
