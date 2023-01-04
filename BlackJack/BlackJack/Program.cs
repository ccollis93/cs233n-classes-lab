using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initializing these outside the loop so they stay constant 
            int playerWin = 0;
            int dealerWin = 0;
            bool playing = true;

            while (playing)
            {
                
                
                    //object instantiations for the deck, player and dealer hands, and cards
                    Card c = new Card();
                    Deck deck1 = new Deck();
                    BJHand dealer = new BJHand(deck1, 2);
                    BJHand player = new BJHand(deck1, 2);

                    Console.WriteLine("Welcome to Blackjack! Press enter to shuffle the deck, and deal the cards");
                    Console.ReadLine();
                    //shuffles the deck
                    deck1.Shuffle();

                    //deals 2 cards to the dealer
                    for (int i = 0; i < 2; i++)
                    {
                        dealer.AddCard(deck1.Deal());

                    }

                    //deals 2 cards to the player
                    for (int i = 0; i < 2; i++)
                    {

                        player.AddCard(deck1.Deal());

                    }

                    //forces the dealer to hit untill their score is at least 16
                    while (dealer.Score <= 16)
                    {
                        dealer.AddCard(deck1.Deal());
                    }

                bool valid = true;
                while (valid)
                {

                    //shows player's hand using ToString
                    Console.WriteLine("Your hand is ");
                    Console.WriteLine(player.ToString());
                    Console.WriteLine("Your score is " + player.Score);
                    Console.WriteLine();

                    int playerAns = 0;
                    Console.WriteLine("Do you want to HIT or STAND?");
                    Console.WriteLine("Enter 1 for HIT, 2 for STAND");
                    playerAns = int.Parse(Console.ReadLine());

                    if (playerAns == 1 && !player.IsBusted)
                    {
                        //if a player hits and doesnt bust, a card is added
                        player.AddCard(deck1.Deal());
                        //Console.WriteLine("Your score is " + player.Score);
                       
                       
                       
                        //if a player busts the loop ends 
                        if (player.IsBusted)
                        {
                            Console.WriteLine("Oops! You busted!");
                            valid = false;
                        }
                        else
                            valid = true;
                        
                    }
                    //if a player stays, and doesnt bust the loop ends
                    else if (playerAns == 2 && !player.IsBusted)
                    {

                        valid = false;
                    }
                    //simple integer based input validation
                    else if (playerAns != 1 && playerAns != 2)
                    {
                        Console.WriteLine("Error! Bad input, must be 1 for HIT or 2 for STAND");
                        valid = true;
                    }
                    //forces the dealer to hit if the scores are tied and the player hasnt busted
                    while (dealer.Score == player.Score && !dealer.IsBusted)
                    {
                        dealer.AddCard(deck1.Deal());
                        
                    }
                    if (dealer.IsBusted)
                    {
                        Console.WriteLine("The dealer busted!");
                        valid = false;
                    }


                    bool scoreBoard = true;
                    //this is the "scoreboard loop" shows the player and dealer's scores, as well as their win counts
                    //uses simple input validation
                    //player answers either start a new game, or termiante the program 
                    while (!valid && scoreBoard)
                    {
                        Console.WriteLine("Your score is " + player.Score);

                        if(!dealer.IsBusted)
                        Console.WriteLine("The Dealer's score is " + dealer.Score);

                        if (dealer.Score > player.Score && !dealer.IsBusted || player.IsBusted )
                        {
                            Console.WriteLine("Sorry, the Dealer wins");
                            dealerWin++;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Dealer Wins: " + dealerWin);
                            Console.WriteLine("Player Wins: " + playerWin);
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Play Again? 1 for yes and 2 for no");
                            playerAns = int.Parse(Console.ReadLine());
                            if (playerAns == 1)
                            {
                                scoreBoard = false;
                                playing = true;
                            }
                            else if (playerAns == 2)
                            {
                                
                                playing = false;
                            }
                            else if (playerAns != 1 && playerAns != 2)
                            {
                                Console.WriteLine("Error! Bad input, must be 1 for YES or 2 for NO");
                                playing = true;
                            }

                        }
                        else if (dealer.Score < player.Score || dealer.IsBusted)
                        {

                            if (player.Score == 21)
                                Console.WriteLine("BLACKJACK!");

                            Console.WriteLine("You win!");
                            playerWin++;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Dealer Wins: " + dealerWin);
                            Console.WriteLine("Player Wins: " + playerWin);
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Play Again? 1 for yes and 2 for no");
                            playerAns = int.Parse(Console.ReadLine());
                            if (playerAns == 1)
                            {
                                scoreBoard = false;
                                playing = true;
                            }
                            else if (playerAns == 2)
                            {
                                valid = true;
                                playing = false;
                            }
                            else if (playerAns != 1 && playerAns != 2)
                            {
                                Console.WriteLine("Error! Bad input, must be 1 for YES or 2 for NO");
                                playing = true;
                            }
                        }
                    }


                }
            }


            Console.ReadLine();
        }
    }
}
