using Battleships_Console.Models;
using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;

namespace Battleships_Console
{
    class Program
    {
        public static Player Player2;
        public static Player Player1;
        static void Main(string[] args)
        {
            //Player1 = new Player(false);
            //var player = new Player(false);
            //player.PrintPlayerBar();
            //player.Battlefield.PrintBattlefield();
            Run();

        }

        public static void Run()
        {
            EnteringScreen();
            MainMenu();
            
        }

        private static void MainMenu()
        {
            bool choiceMade = false;
            int menuPosition = 0;
            var menuChoises = new List<string> { "1 Player", "2 Players", "End Game" };
            while(!choiceMade)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("BATTLESHIP");
                Console.WriteLine("Main Menu");
                int index = 0;
                foreach (var item in menuChoises)
                {
                    if(index == menuPosition)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(item);
                    Console.ResetColor();
                    index++;
                }

                ConsoleKeyInfo keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    menuPosition++;
                    if (menuPosition >= 3)
                        menuPosition = 2;
                }

                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    menuPosition--;
                    if (menuPosition < 0)
                        menuPosition = 0;
                }

                if (keyInput.Key == ConsoleKey.Enter)
                {
                    choiceMade = true;
                }
            }

            switch (menuPosition)
            {
                case 0:
                    //1 player
                    CreatePlayers(true);
                    RunGame(true);
                    break;
                case 1:
                    //2 players
                    CreatePlayers(false);
                    RunGame(false);
                    break;
                case 2:
                    //End program
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void CreatePlayers(bool singleplayer)
        {
            if (!singleplayer)
            {
                Player1 = new Player(false);
                Player2 = new Player(false);
            }
            else
            {
                Player1 = new Player(false);
                Player2 = new Player(true);
            }
        }

        private static void EnteringScreen()
        {
            Console.WriteLine("BATTLESHIP");
            Console.WriteLine("Press any button to continue!");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void RunGame(bool singleplayer)
        {
            bool player1Won = false;
            bool player2Won = false;
            bool finished = false;
            //Placera skepp på spelplan.
            PlaceShips(Player1);
            if (!singleplayer)
                PlaceShips(Player2);
            else
                PlaceShips(Player2); // AUTOMATISERAT SPELARE CPU
            while (!finished)
            {
                Console.WriteLine($"Time for {Player1.Name} to fire a round at {Player2.Name}.\n" +
                                  $"Press any key to continue!");
                Console.ReadKey();

                //FIRE AT SHIPS!!!





                Console.WriteLine($"Time for {Player2.Name} to fire a round at {Player1.Name}.\n" +
                  $"Press any key to continue!");
                Console.ReadKey();
                //FIRE AT SHIPS!!!
                player1Won = Player1.AllShipsSunk();
                player2Won = Player2.AllShipsSunk();
                if (player1Won && player2Won)
                {
                    Console.WriteLine("DRAW! You sunk your opponents last ship at the same time!");
                    finished = true;
                    break;
                }
                if (player1Won)
                {
                    Console.WriteLine($"{Player1.Name} WON, Congratulations!!!" +
                                      $"{Player2.Name} you better go and practice some more before another game with {Player1.Name}");
                    finished = true;
                    break;
                }
                if (player2Won)
                {
                    Console.WriteLine($"{Player2.Name} WON, Congratulations!!!" +
                                      $"{Player1.Name} you better go and practice some more before another game with {Player2.Name}");
                    finished = true;
                    break;
                }
            }
        }

        private static void PlaceShips(Player player)
        {
            foreach (var ship in player.ListOfShips)
            {
                while (!ship.HasBeenPlacedOnBattlefield)
                {
                    Console.SetCursorPosition(0, 0);
                    ship.SetShipToBattlefieldCoordinates();

                    player.Battlefield.PrintBattlefield();
                    Console.WriteLine($"Move your {ship.GetType().Name} into position and press 'ENTER'.");

                    ConsoleKeyInfo keyInput = Console.ReadKey(true);

                    if (keyInput.Key == ConsoleKey.S)
                    {
                        ship.MoveShipDown();
                    }

                    if (keyInput.Key == ConsoleKey.D)
                    {
                        ship.MoveShipRight();
                    }

                    if (keyInput.Key == ConsoleKey.A)
                    {
                        ship.MoveShipLeft();
                    }

                    if (keyInput.Key == ConsoleKey.W)
                    {
                        ship.MoveShipUp();
                    }

                    if (keyInput.Key == ConsoleKey.Spacebar)
                    {
                        ship.RotateShip();
                    }

                    if (keyInput.Key == ConsoleKey.Enter)
                    {
                        if(ship.Placeable)
                            ship.HasBeenPlacedOnBattlefield = true;
                    }
                }
            }
        }
    }
}
