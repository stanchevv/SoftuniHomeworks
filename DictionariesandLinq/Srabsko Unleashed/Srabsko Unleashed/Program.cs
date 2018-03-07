namespace Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var inputArray = input.Split(' ');

            bool valid = false;
            int price = 0;
            int tickets = 0;
            string venue = "";
            string singer = "";

            var srabsko = new Dictionary<string, Dictionary<string, long>>();

            int venueStartingIndex = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i][0] == '@')
                {
                    venueStartingIndex = i;
                    valid = true;
                    break;
                }
                else
                {
                    singer += inputArray[i] + " ";
                }
            }

            try
            {
                tickets = int.Parse(inputArray[inputArray.Length - 1]);
                price = int.Parse(inputArray[inputArray.Length - 2]);
            }
            catch (Exception)
            {
                valid = false;
            }

            if (valid)
            {
                for (int i = venueStartingIndex; i < inputArray.Length - 2; i++)
                {
                    if (i == venueStartingIndex)
                    {
                        inputArray[i] = inputArray[i].Substring(1);
                    }
                    venue += inputArray[i] + " ";
                }
            }

            venueStartingIndex = 0;

            // do not forget  valid = false; input and inputArray

            // getting valid input until here

            while (input != "End")
            {
                if (valid)
                {
                    if (srabsko.ContainsKey(venue) == false)
                    {
                        srabsko.Add(venue, new Dictionary<string, long>());
                        srabsko[venue].Add(singer, price * tickets);
                    }
                    else
                    {
                        if (srabsko[venue].ContainsKey(singer) == false)
                        {
                            srabsko[venue].Add(singer, price * tickets);
                        }
                        else
                        {
                            srabsko[venue][singer] += price * tickets;
                        }
                    }
                }

                // filling the result dictionary until here

                valid = false;

                input = Console.ReadLine();
                inputArray = input.Split(' ');
                venue = "";
                singer = "";
                tickets = 0;
                price = 0;

                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i][0] == '@')
                    {
                        venueStartingIndex = i;
                        valid = true;
                        break;
                    }
                    else
                    {
                        singer += inputArray[i] + " ";
                    }
                }

                try
                {
                    tickets = int.Parse(inputArray[inputArray.Length - 1]);
                    price = int.Parse(inputArray[inputArray.Length - 2]);
                }
                catch (Exception)
                {
                    valid = false;
                }

                if (valid)
                {
                    for (int i = venueStartingIndex; i < inputArray.Length - 2; i++)
                    {
                        if (i == venueStartingIndex)
                        {
                            inputArray[i] = inputArray[i].Substring(1);
                        }
                        venue += inputArray[i] + " ";
                    }
                }

                venueStartingIndex = 0;
            }

            // printing output from here on

            foreach (var place in srabsko)
            {
                Console.WriteLine(place.Key);
                foreach (var performer in place.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  " + performer.Key + "-> " + performer.Value);
                }
            }



        }
    }
}
