namespace Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var hand = Console.ReadLine().Split(new char[] {':',' ',',' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();
            int sum = 0;
            var players = new Dictionary<string,List<string>>();
            string name = "";
            var cards = new List<string>();

            while (hand[0]!="JOKER")
            {
                name = hand[0];
                cards = hand.Skip(1).ToList();
                cards = cards.Distinct().ToList();

                if (players.ContainsKey(name)==false)
                {
                    players.Add(name, cards);
                }
                else
                {
                    players[name].AddRange(cards);
                    players[name] = players[name].Distinct().ToList();
                }

                hand = Console.ReadLine().Split(new char[] { ':', ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            }

            int multiplier = 0;
            int cardValue = 0;

            foreach (var player in players)
            {
                foreach (var card in player.Value)
                {
                    switch (card[card.Length-1])
                    {
                        case 'S':multiplier = 4; break;  
                        case 'H':multiplier = 3; break;  
                        case 'D':multiplier = 2; break;  
                        case 'C':multiplier = 1; break;
                        
                    }
                    string currentCard = card.Remove(card.Length - 1,1);
                    switch (currentCard)
                    {
                        case "J": cardValue = 11; break;
                        case "Q": cardValue = 12; break;
                        case "K": cardValue = 13; break;
                        case "A": cardValue = 14; break;
                        default: cardValue = int.Parse(currentCard);
                            break;
                    }
                    sum += multiplier * cardValue;
                }
                Console.WriteLine("{0}: {1}",player.Key,sum);
                sum = 0;
            }

        }
    }
}
