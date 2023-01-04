using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class BoneYard 
    {
        List<Domino> dominos = new List<Domino>();

     

        //generates the BoneYard
        public BoneYard(int maxDots)
        {
            for (int side1 = 0; side1 <= maxDots; side1++)
                for (int side2 = 0; side2 <= side1; side2++)
                    dominos.Add(new Domino(side1, side2));

        }

   

        //the number of dominos left in the BoneYard
        public int DominosRemaining
        {
            get
            {
                return dominos.Count;
            }
        }

        //the indexer
        public Domino this[int i]
        {
            get
            {
                return dominos[i];
            }
        }

        //checks for an empty BoneYard
        public bool IsEmpty()
        {
            if (dominos.Count == 0)
                return true;
            else
                return false;
        }

        public Domino Deal()
        {
            if (!IsEmpty())
            {
                Domino d = dominos[0];

                dominos.Remove(d);

                return d;
            }
            return null;
        }

        //shuffles BoneYard
        public void Shuffle()
        {
            Random gen = new Random();

            for (int i = 0; i < DominosRemaining; i++)
            {
                int rnd = gen.Next(0, DominosRemaining);

                Domino d = dominos[rnd];
                dominos[rnd] = dominos[i];
                dominos[i] = d;
            }
        }

        public void Sort()
        {
            dominos.Sort();
        }

        //overridden ToString
        public override string ToString()
        {
            string output = "";

            foreach (Domino d in dominos)
            {
                output += d.ToString() + "\n";

            }
            return output;
        }

    }
}
