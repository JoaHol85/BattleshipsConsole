using Battleships_Console.Models;
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
            Run();
        }

        public static void Run()
        {
            EnteringScreen();
            MainMenu();
        }

        public static void PlaceShips(Player player)
        {
            
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
                    PlaceShips();
                    break;
                case 1:
                    //2 players
                    CreatePlayers(false);
                    PlaceShips();
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


        
    }
}
