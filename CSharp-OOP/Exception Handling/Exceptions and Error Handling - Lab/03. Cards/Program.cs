namespace _03._Cards
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Card
    {
        private string[] validFaces = new string[]
        { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private string face;
        public string Face
        {
            get { return face; }
            private set 
            { 
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value; 
            }
        }

        private string suit;
        public string Suit
        {
            get { return suit; }
            private set 
            {
                if (value == "S")
                    suit = "\u2660";
                else if (value == "H")
                    suit = "\u2665";
                else if (value == "D")
                    suit = "\u2666";
                else if (value == "C")
                    suit = "\u2663";
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] card = input[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Card newCard = new Card(card[0], card[1]);
                    cards.Add(newCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(String.Join(' ', cards));
        }
    }
}
