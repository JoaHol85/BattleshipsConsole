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
            Player1 = new Player(false);
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

            //Placera skepp på spelplan.
            PlaceShips(Player1);
            if (!singleplayer)
                PlaceShips(Player2);
            else
                PlaceShips(Player2); // AUTOMATISERAT SPELARE CPU
        }

        private static void PlaceShips(Player player)
        {
            foreach (var ship in player.ListOfShips)
            {
                bool shipPlaced = false;
                while (!shipPlaced)
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
                        shipPlaced = true;
                    }
                }
            }
        }
    }
}
