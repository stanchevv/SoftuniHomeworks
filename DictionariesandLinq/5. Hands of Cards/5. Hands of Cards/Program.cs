using System;
using System.Collections.Generic;
using System.Linq;
class HandsofCards
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        var handsOfCarcds = new Dictionary<string, int>();
        while (input[0] != "JOKER")
        {
            string name = input[0];
            var cards = input[1].Split(',').Distinct().ToList();
            int multipliedOfCurrentName = ProcessingCards(cards);

            if (!handsOfCarcds.ContainsKey(name))
            {
                handsOfCarcds[name] = multipliedOfCurrentName;
            }
            else
            {
                handsOfCarcds[name] += multipliedOfCurrentName;
            }


            input = Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
        foreach (var item in handsOfCarcds)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }

    private static int ProcessingCards(List<string> cards)
    {
        List<int> multipliedName = SpecificMaps(cards);

        int resultMiltipliedName = MultipliedCurrentName(multipliedName);
        return resultMiltipliedName;
    }

    private static int MultipliedCurrentName(List<int> multipliedName)
    {
        int muldipliedNumberName = 0;
        foreach (var item in multipliedName)
        {
            muldipliedNumberName += item;
        }
        return muldipliedNumberName;
    }

    private static List<int> SpecificMaps(List<string> cards)
    {
        bool isGreather = false;
        int i = 0;
        List<int> values = new List<int>();
        List<int> resultList = new List<int>();
        string concat = "";
        foreach (var item in cards)
        {
            char[] poweType = item.Trim().ToCharArray();
            if (poweType.Length >= 3)
            {
                concat = SpecialCase(poweType);
                isGreather = true;
            }
            string power = poweType[0].ToString();
            string type = poweType[1].ToString();

            if (isGreather)
            {
                power = concat;
                type = poweType[2].ToString();
            }

            int range;
            int typeParse;
            if (int.TryParse(power, out range))
            {
                values.Add(range);
            }
            if (!int.TryParse(type, out typeParse))
            {
                if (power == "J" || type == "J")
                {
                    int powerJ = 11;
                    values.Add(powerJ);
                }
                else if (power == "Q" || type == "Q")
                {
                    int powerQ = 12;
                    values.Add(powerQ);
                }
                else if (power == "K" || type == "K")
                {
                    int powerK = 13;
                    values.Add(powerK);
                }
                else if (power == "A" || type == "A")
                {
                    int powerA = 14;
                    values.Add(powerA);
                }

                MultipliedByType(power, type, values);

            }
            int numberMultiplied = Multiplied(values, i);
            i++;
            resultList.Add(numberMultiplied);
            isGreather = false;
            values.Clear();
        }
        return resultList;
    }

    private static string SpecialCase(char[] poweType)
    {
        string first = poweType[0].ToString();
        string second = poweType[1].ToString();

        string concat = first + second;

        return concat;
    }

    private static int Multiplied(List<int> values, int i)
    {
        int multiplied = 1;
        foreach (var item in values)
        {
            multiplied *= item;
        }
        return multiplied;
    }

    private static void MultipliedByType(string power, string type, List<int> values)
    {
        if (power == "S" || type == "S")
        {
            int powerS = 4;
            values.Add(powerS);
        }
        else if (power == "H" || type == "H")
        {
            int powerH = 3;
            values.Add(powerH);
        }
        else if (power == "D" || type == "D")
        {
            int powerD = 2;
            values.Add(powerD);
        }
        else if (power == "C" || type == "C")
        {
            int powerC = 1;
            values.Add(powerC);
        }
    }
}