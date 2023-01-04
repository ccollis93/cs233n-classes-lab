using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        public BJHand() : base() { }

        public BJHand(Deck d, int numCards)
        {

        }

        public bool HasAce
        {
            get
            {
                return HasCard(1);
            }
        }

        public bool IsBusted
        {
            get
            {
                return Score > 21;
            }
        }

        public int Score
        {
            get
            {
                int score = 0;
                foreach (Card c in cards)
                {
                    if (c.IsFaceCard)
                    {
                        score += 10;
                    }
                    else
                        score += c.Value;

                }
                if (this.HasAce && score <= 11)
                    score += 10;

                return score;
            }
        }
    }
}
