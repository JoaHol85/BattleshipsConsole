using Battleships_Console.Models;
using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Battleships_Console
{
    class Program
    {
        public static Player Player2;
        public static Player Player1;
        static void Main(string[] args)
        {
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
                Console.SetCursorPosition(0,0);
                //Console.Clear();
                PrintGameName();
                Console.WriteLine("\n\n                                                    Main Menu");
                Console.WriteLine("                                                  \u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC\u25AC");
                int index = 0;
                foreach (var item in menuChoises)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        Console.Write(" ");
                    }
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
                Player1 = new Player(false, true);
                Player2 = new Player(false, false);
            }
            else
            {
                Player1 = new Player(false, true);
                Player2 = new Player(true, false);
            }
        }

        private static void EnteringScreen()
        {
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey(true);
            Console.ResetColor();
            Console.Clear();
        }

        private static void PrintGameName()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ███████████    █████████   ███████████ ███████████ █████       ██████████  █████████  █████   █████ █████ ███████████ ");
            Console.WriteLine("░░███░░░░░███  ███░░░░░███ ░█░░░███░░░█░█░░░███░░░█░░███       ░░███░░░░░█ ███░░░░░███░░███   ░░███ ░░███ ░░███░░░░░███");
            Console.WriteLine(" ░███    ░███ ░███    ░███ ░   ░███  ░ ░   ░███  ░  ░███        ░███  █ ░ ░███    ░░░  ░███    ░███  ░███  ░███    ░███");
            Console.WriteLine(" ░██████████  ░███████████     ░███        ░███     ░███        ░██████   ░░█████████  ░███████████  ░███  ░██████████ ");
            Console.WriteLine(" ░███░░░░░███ ░███░░░░░███     ░███        ░███     ░███        ░███░░█    ░░░░░░░░███ ░███░░░░░███  ░███  ░███░░░░░░  ");
            Console.WriteLine(" ░███    ░███ ░███    ░███     ░███        ░███     ░███      █ ░███ ░   █ ███    ░███ ░███    ░███  ░███  ░███        ");
            Console.WriteLine(" ███████████  █████   █████    █████       █████    ███████████ ██████████░░█████████  █████   █████ █████ █████       ");
            Console.WriteLine("░░░░░░░░░░░  ░░░░░   ░░░░░    ░░░░░       ░░░░░    ░░░░░░░░░░░ ░░░░░░░░░░  ░░░░░░░░░  ░░░░░   ░░░░░ ░░░░░ ░░░░░        ");
            Console.ResetColor();                                                                                                         
        }

        private static void RunGame(bool singleplayer)
        {
            Console.Clear();
            bool finished = false;
            PlaceShips(Player1);
            if (!singleplayer)
                PlaceShips(Player2);
            else
                PlaceShips(Player2); // AUTOMATISERAT SPELARE CPU
            while (!finished)
            {
                Console.Clear();
                Console.WriteLine($"Time for {Player1.Name} to fire a round at {Player2.Name}.\n" +
                                  $"Press any key to continue!");
                Console.ReadKey();
                Player2.Battlefield.FireAtShips(Player1);
                
                Console.Clear();
                Console.WriteLine($"Time for {Player2.Name} to fire a round at {Player1.Name}.\n" +
                                  $"Press any key to continue!");
                Console.ReadKey();
                Player1.Battlefield.FireAtShips(Player2);

                finished = CheckForWinner();
            }
        }

        private static bool CheckForWinner()
        {
            bool player1Won = false;
            bool player2Won = false;

            player1Won = Player2.AllShipsSunk();
            player2Won = Player1.AllShipsSunk();
            if (player1Won && player2Won)
            {
                Console.WriteLine("DRAW! You sunk your opponents last ship at the same time!");
                return true;
            }
            if (player1Won)
            {
                PrintWinner();
                if (Player2.Name == "CPU")
                {
                    Console.WriteLine($"{Player1.Name} WON, Congratulations!!!");
                    Console.WriteLine($"{Player1.Name}, you beat the CPU! Good, now challenge a real player!!!");
                }
                if (Player2.Name != "CPU")
                {
                    Console.WriteLine($"{Player1.Name} WON, Congratulations!!!");
                    Console.WriteLine($"{Player2.Name} you better go and practice some more before another game with {Player1.Name}");
                }
                return true;
            }
            if (player2Won)
            {
                PrintWinner();
                if (Player2.Name == "CPU")
                {
                    Console.WriteLine($"{Player2.Name} WON, Congratulations!!!" +
                                      $"{Player1.Name}! Practice more!! You lost against the computer...");
                }
                if (Player2.Name != "CPU")
                {
                    Console.WriteLine($"{Player2.Name} WON, Congratulations!!!");
                    Console.WriteLine($"{Player1.Name} you better go and practice some more before another game with {Player2.Name}");
                }
                return true;
            }
            return false;
        }

        private static void PrintWinner()
        {
            int x = 1;
            while (true)
            {
                Console.ForegroundColor = x == 1 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.WriteLine("█████   ███   █████ █████ ██████   █████ ██████   █████ ██████████ ███████████   ███ ███ ███ ");
                Console.WriteLine("░░███   ░███  ░░███ ░░███ ░░██████ ░░███ ░░██████ ░░███ ░░███░░░░░█░░███░░░░░███ ░███░███░███");
                Console.WriteLine(" ░███   ░███   ░███  ░███  ░███░███ ░███  ░███░███ ░███  ░███  █ ░  ░███    ░███ ░███░███░███");
                Console.WriteLine(" ░███   ░███   ░███  ░███  ░███░░███░███  ░███░░███░███  ░██████    ░██████████  ░███░███░███");
                Console.WriteLine(" ░░███  █████  ███   ░███  ░███ ░░██████  ░███ ░░██████  ░███░░█    ░███░░░░░███ ░███░███░███");
                Console.WriteLine("  ░░░█████░█████░    ░███  ░███  ░░█████  ░███  ░░█████  ░███ ░   █ ░███    ░███ ░░░ ░░░ ░░░ ");
                Console.WriteLine("    ░░███ ░░███      █████ █████  ░░█████ █████  ░░█████ ██████████ █████   █████ ███ ███ ███");
                Console.WriteLine("     ░░░   ░░░      ░░░░░ ░░░░░    ░░░░░ ░░░░░    ░░░░░ ░░░░░░░░░░ ░░░░░   ░░░░░ ░░░ ░░░ ░░░ ");
                Thread.Sleep(250);
                Console.SetCursorPosition(0, 0);
                x = x == 1 ? x = 2 : x = 1;
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
                    player.PrintPlayerBar();
                    player.Battlefield.PrintBattlefield();
                    Console.WriteLine($"Move your {ship.GetType().Name} into position and press 'ENTER'.");

                    ConsoleKeyInfo keyInput = Console.ReadKey(true);

                    switch(keyInput.Key)
                    {
                        case ConsoleKey.S:
                            ship.MoveShipDown();
                            break;
                        case ConsoleKey.D:
                            ship.MoveShipRight();
                            break;
                        case ConsoleKey.W:
                            ship.MoveShipUp();
                            break;
                        case ConsoleKey.A:
                            ship.MoveShipLeft();
                            break;
                        case ConsoleKey.Spacebar:
                            ship.RotateShip();
                            break;
                        case ConsoleKey.Enter:
                            if (ship.Placeable)
                                ship.HasBeenPlacedOnBattlefield = true;
                            break;
                    }
                }
            }
            foreach (var aShip in player.ListOfShips)
            {
                foreach (var coordinate in aShip.ListOfCoordinates)
                {
                    player.Battlefield.Coordinates[coordinate.YPosition, coordinate.XPosition].VisualString = "~~~";
                }
            }
        }
    }
}
