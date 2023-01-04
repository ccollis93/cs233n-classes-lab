using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
           //TestCardConstructors();
           //TestToString();
           //TestMatchingSuit();
           //TestMatchingValue();
           //TestGetters();
           //TestTruePropGetters();
           //TestFalsePropGetters();
       
            //TestDeckConstructor();
            //TestDeckShuffle();
            //TestDeckDeal();

            TestHandConstructor();
            TestAddCard();
            TestDiscard();
            TestGetCard();
            TestHasCard();
            TestIndexOf();
            TestNumCardsProp();
            TestHandToString();

            //TestBJHasAce();
            //TestBJIsBusted();
            //TestBJScore();


            Console.ReadLine();
        }

        static void TestCardConstructors()
        {
            Card c1 = new Card();
            Card c2 = new Card(1, 4);

            Console.WriteLine("Testing Constructors");
            Console.WriteLine("Default Constructor, expecting random value and suit, " + c1.ToString());
            Console.WriteLine("Overloaded Constructor, expecting Ace of Spades, " + c2.ToString());
            Console.WriteLine();
        }

        static void TestToString()
        {
            Card c1 = new Card(3,1);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 3 of Clubs, " + c1);
            Console.WriteLine();
        }

        static void TestMatchingSuit()
        {
            Card c1 = new Card(2, 2);
            Card c2 = new Card(6, 2);

            Console.WriteLine("Testing Matching Suits");

            if (c1.HasMatchingSuit(c2) == true)
                Console.WriteLine("The cards have matching suits");
            else
                Console.WriteLine("The cards do not have matching suits");

            Console.WriteLine();

        }

        static void TestMatchingValue()
        {
            Card c1 = new Card(6, 3);
            Card c2 = new Card(6, 4);

            if (c1.HasMatchingValue(c2))
                Console.WriteLine("The cards have matching values");
            else
                Console.WriteLine("The cards do not have matching values");

            Console.WriteLine();
        }

        static void TestGetters()
        {
            Card c1 = new Card(9, 4);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Expecting Suit 4, " + c1.Suit);
            Console.WriteLine("Expecting Value 9, " + c1.Value);
            Console.WriteLine();
        }

        static void TestTruePropGetters()
        {
            Card c1 = new Card(3, 1);
            Card c2 = new Card(6, 2);
            Card c3 = new Card(7, 3);
            Card c4 = new Card(5, 4);
            Card c5 = new Card(12, 3);
            Card c6 = new Card(13, 2);
            Card c7 = new Card(1, 4);
           

            Console.WriteLine("Testing getters that return true:");
            Console.WriteLine("Card will be Clubs, expecting true,  " + c1.IsClub);
            Console.WriteLine("Card will be Diamonds, expecting true, " + c2.IsDiamond);
            Console.WriteLine("Card will be Hearts, expecting true, " + c3.IsHeart);
            Console.WriteLine("Card will be Spades, expecting true, " + c4.IsSpade);
            Console.WriteLine("Card will be a Face Card(King of Hearts), expecting true, " + c5.IsFaceCard);
            Console.WriteLine("Card will be Red(Diamonds), expecting true, " + c6.IsRed);
            Console.WriteLine("Card will be Black(Spades), expecting true, " + c7.IsBlack);
            Console.WriteLine();
        }

        static void TestFalsePropGetters()
        {
            Card c1 = new Card(10, 3);
            Card c2 = new Card(6, 1);
            Card c3 = new Card(4, 4);
            Card c4 = new Card(7, 2);
            Card c5 = new Card(2, 3);
            Card c6 = new Card(10, 1);
            Card c7 = new Card(3, 4);
            Card c8 = new Card(5, 2);

            Console.WriteLine("Testing getters that return false:");
            Console.WriteLine("Card will be Clubs, expecting false,  " + c1.IsClub);
            Console.WriteLine("Card will be Diamonds, expecting false, " + c2.IsDiamond);
            Console.WriteLine("Card will be Hearts, expecting false, " + c3.IsHeart);
            Console.WriteLine("Card will be Spades, expecting false, " + c4.IsSpade);
            Console.WriteLine("Card will be a Face Card, expecting false, " + c5.IsFaceCard);
            Console.WriteLine("Card will be Red, expecting false, " + c6.IsRed);
            Console.WriteLine("Card will be Black, expecting false, " + c7.IsBlack);
            Console.WriteLine();
        }

        static void TestDeckConstructor()
        {
            Deck d = new Deck();

            Console.WriteLine("Testing deck of cards default constructor");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("ToString.  Expect a ton of cards in order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckShuffle()
        {
            Deck d = new Deck();
            d.Shuffle();
            Console.WriteLine("Testing deck of cards shuffle");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
            Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckDeal()
        {
            Deck d = new Deck();
            Card c = d.Deal();

            Console.WriteLine("Testing deck of cards deal");
            Console.WriteLine("NumCards.  Expecting 51. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);

            // now let's deal them all and see what happens at the end
            for (int i = 1; i <= 51; i++)
                c = d.Deal();
            Console.WriteLine("Dealt all 52 cards");
            Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting true. " + d.IsEmpty);
            Console.WriteLine("Last Card should be King of Spades. " + c);
            Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));

            Console.WriteLine();
        }

        static void TestHandConstructor()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand();
            Hand h2 = new Hand(d1, 5);

            Console.WriteLine("Testing default constructor, expecting an empty hand " + h1.ToString());
            Console.WriteLine("Testing overleaded constructor, expecting a hand of 6 cards" + "\n" + h2.ToString());
            Console.WriteLine();
            Console.WriteLine();
        }

        static void TestAddCard()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 3);

            Console.WriteLine("Testing AddCard, before card is added, expecting 4 cards \n" + h1.ToString());
            h1.AddCard(d1.Deal());
            Console.WriteLine("Tesing AddCard, after a card is added, expecting 5 cards \n" + h1.ToString());
            Console.WriteLine();
        }

        static void TestDiscard()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 3);

            Console.WriteLine("Testing Discard, starting with a hand of 4 cards \n" + h1.ToString());
            h1.Discard(0);
            Console.WriteLine("The first card should be discarded \n" + h1.ToString());
            Console.WriteLine();
        }

        static void TestGetCard()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 3);

            Console.WriteLine("Testing GetCard, starting with a hand of 4 cards \n" + h1.ToString());
            Console.WriteLine("Lets get the card at index 0, expecting Ace of Clubs" );
            Console.WriteLine(h1.GetCard(0));
            Console.WriteLine();
        }

        static void TestHasCard()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 51);

            Console.WriteLine("Testing HasCard, looking for Ace of Spades, expecting true");
            Console.WriteLine(h1.HasCard(1,1));
            Console.WriteLine();
        }

        static void TestIndexOf()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 51);
            int theIndex = -1;

            Console.WriteLine("Finding the index of the Ace of Spades, value 1, suit 1");
            theIndex = h1.IndexOf(1, 1);
            Console.WriteLine("The index is " + theIndex);
            Console.WriteLine();
        }

        static void TestNumCardsProp()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 5);

            Console.WriteLine("Testing NumCards, expecting 6: " + h1.NumCards);
            Console.WriteLine();
        }

        static void TestHandToString()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 5);

            Console.WriteLine("Testing the ToString, here is our hand \n" + h1.ToString());
            Console.WriteLine();
        }

        static void TestBJHasAce()
        {
            Deck d1 = new Deck();
            BJHand bj1 = new BJHand(d1, 52);

            Console.WriteLine("Testing BJHand HasAce");
            Console.WriteLine("Expecting false: " + bj1.HasAce);
            Console.WriteLine();
        }

        static void TestBJIsBusted()
        {
            Deck d1 = new Deck();
            BJHand bj1 = new BJHand();

            Console.WriteLine("Testing IsBusted. Score less than 21 expecting false: " + bj1.IsBusted);

            for (int i = 0; i < 15; i++)
            {
                bj1.AddCard(d1.Deal());

            }
            
            Console.WriteLine("Testing IsBusted. Score less than 21 expecting true: " + bj1.IsBusted);
            Console.WriteLine();
        }

        static void TestBJScore()
        {
            Deck d1 = new Deck();
            BJHand bj1 = new BJHand(d1, 10);


            Console.WriteLine("Expecting 0, the score is: " + bj1.Score);
            for (int i = 0; i < 1; i++)
            {
                bj1.AddCard(d1.Deal());

            }
            Console.WriteLine("Expecting 11, the score is: " + bj1.Score);
            Console.WriteLine();
        }
    }
}
