using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        //the protected list of cards we use to make the hand 
        protected List<Card> cards = new List<Card>();

        //default constructor
        public Hand() { }

        //overloaded constructor
        public Hand(Deck d, int numCards)
        {
            for(int i = 0; i <= numCards; i++)
            {
                cards.Add(d.Deal());
            }
        }

        //adds a card to the list 
        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        //discards the card from the hand
        public Card Discard(int index)
        {
          if(index <= NumCards)
            {
                Card c = cards[index];
                cards.RemoveAt(index);
                return c;
            }
            return null;
        }

        //grabs a specific card based on the index inputted
        public Card GetCard(int index)
        {
            return cards[index];

        }

        public bool HasCard(Card c)
        {
            return IndexOf(c) != -1; 
        } 
        
        public bool HasCard(int value)
        {
            return IndexOf(value) != -1;
        }

        public bool HasCard(int value, int suit)
        {
           for(int i = 0; i < cards.Count; i++)
            {
                if(cards[i].Value == value && cards[i].Suit == suit)
                {
                    return true;
                }
            }
            return false;
           
        }

        //returns the the index of a card object as an int
        public int IndexOf(Card c)
        {
           return  cards.IndexOf(c);           
        }

        
        public int IndexOf(int value)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if(cards[i].Value == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if(cards[i].Value == value && cards[i].Suit == suit)
                {
                    return i;
                }
            }
            return -1;
        }

        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }



        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }

    }
}
