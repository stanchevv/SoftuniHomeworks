using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();

            var command = new List<string>();

            while (true)
            {
                command = Console.ReadLine().Split(' ').ToList();

                if (command[0] == "3:1")
                {
                    break;
                }

                if (command[0]=="merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex<0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex>=input.Count)
                    {
                        continue;
                    }

                    if (endIndex < 0)
                    {
                        continue;
                    }
                    else if (endIndex >= input.Count)
                    {
                        endIndex = input.Count - 1;
                    }

                    for (int i = startIndex+1; i <= endIndex; i++)
                    {
                        input[startIndex] += input[i];
                    }

                    input.RemoveRange(startIndex+1,endIndex-(startIndex));
                }
                else if (command[0]=="divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);

                    if (index<0||index>=input.Count)
                    {
                        continue;
                    }

                    if (input[index].Length%partitions==0)
                    {
                        int partLenght = input[index].Length / partitions;
                        var dividedList = new List<string>();

                        for (int i = 0; i < partitions; i++)
                        {
                            dividedList.Add(input[index].Substring(partLenght*i,partLenght));    
                        }

                        input.RemoveAt(index);
                        input.InsertRange(index, dividedList);

                    }
                    else
                    {
                        int partLenght = input[index].Length / partitions;
                        var dividedList = new List<string>();

                        for (int i = 0; i < partitions; i++)
                        {
                            if (i==partitions-1)
                            {
                                dividedList.Add(input[index].Substring(partLenght * i, partLenght+input[index].Length-partitions*partLenght));
                                break;
                            }
                            dividedList.Add(input[index].Substring(partLenght * i, partLenght));
                        }

                        input.RemoveAt(index);
                        input.InsertRange(index, dividedList);
                    }
                }
            }


            Console.WriteLine(String.Join(" ",input));
        }
    }
}
