using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Card
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

       
        
        //default constructor
        public Card()
        {
            Value = generator.Next(1, 14);
            Suit = generator.Next(1, 5);
        }

        public Card(int v, int s)
        {
            Value = v;
            Suit = s;
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value >= 1 && value <= 13)
                    this.value = value;
                else
                    throw new ArgumentException("Error! Must be between 1 and 13!");

            }
        }

        public int Suit
        {
            get
            {
                return suit;
            }
            set
            {
                if (value >= 1 && value <= 4)
                    suit = value;
                else
                    throw new ArgumentException("Error! Must be between 1 and 4");
            }
        }

        public bool HasMatchingSuit(Card other)
        {
            if (this.Suit == other.Suit)         
                return true;  
            else
             return false;
        }

        public bool HasMatchingValue(Card other)
        {
            if (this.Value == other.Value)           
                return true;  
            else
                return false;
        }

        public bool IsAce
        {
            get
            {
                if (value == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool IsBlack
        {
            get
            {
                if (suit == 1 || suit == 4)
                    return true;
                else
                    return false;
            }
           
        }

        public bool IsRed
        {
            get
            {
                if (suit == 2 || suit == 3)
                    return true;
                else
                    return false;
  
            }

        }

        public bool IsClub
        {
            get
            {
                if (suit == 1)
                    return true;
                else
                    return false;
                
            }
        }

        public bool IsDiamond
        {
            get
            {
                if (suit == 2)
                    return true;
                else
                    return false;
            }

        }

        public bool IsHeart
        {
            get
            {
                if (suit == 3)
                    return true;
                else
                    return false;
            }
        }

        public bool IsSpade
        {
            get
            {
                if (suit == 4)
                    return true;
                else
                    return false;
            }

        }

        public bool IsFaceCard
        {
            get
            {
                if (value >= 11 && value <= 13)
                    return true;
                else
                    return false;
            }

        }

        public override bool Equals(object obj)
        {
            Card c = (Card)obj;
            if (c.value == this.value && c.suit == this.suit)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    

    public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }

    }
}
