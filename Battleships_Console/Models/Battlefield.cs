using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleships_Console.Models
{
    public class Battlefield
    {
        public Player Player { get; set; }
        public Coordinate[,] Coordinates { get; set; }
        public Battlefield(Player player)
        {
            Player = player;
            Coordinates = new Coordinate[12, 12];
            CreateBattlefield();
        }

        private void CreateBattlefield()
        {
            for (int y = 0; y < Coordinates.GetLength(0); y++)
            {
                for (int x = 0; x < Coordinates.GetLength(1); x++)
                {
                    if (y == 0 && x == 0)
                        Coordinates[y, x] = new Coordinate() { VisualString = "\u2588", Border = true };
                    else if (y == Coordinates.GetLength(0) - 1 && x == Coordinates.GetLength(1) - 1)
                        Coordinates[y, x] = new Coordinate() { VisualString = "\u2588", Border = true };
                    else if (y == 0 || y == Coordinates.GetLength(0) - 1)
                        Coordinates[y, x] = new Coordinate() { VisualString = "\u2588\u2588\u2588", Border = true };
                    else if (x == 0 || x == Coordinates.GetLength(1) - 1)
                        Coordinates[y, x] = new Coordinate() { VisualString = "\u2588\u2588", Border = true };
                    else
                        Coordinates[y, x] = new Coordinate() { VisualString = "~~~", Border = false };
                }
            }
        }

        public void PrintBattlefield()
        {
            //PrintLetterCoordinates();
            for (int y = 0; y < Coordinates.GetLength(0); y++)
            {
                //PrintNumberCoordinates(y, true);
                for (int x = 0; x < Coordinates.GetLength(1); x++)
                {
                    BattlefieldColors(Coordinates[y, x]);
                }
                //PrintNumberCoordinates(y, false);
                Console.WriteLine();
                if (y != 0 && y != Coordinates.GetLength(0) - 1)
                {
                    //PrintNumberCoordinates(y, true);
                    for (int x = 0; x < Coordinates.GetLength(1); x++)
                    {
                        BattlefieldColors(Coordinates[y, x]);
                    }
                    //PrintNumberCoordinates(y, false);
                    Console.WriteLine();
                }
            }
            //PrintLetterCoordinates();

        }

        private void PrintNumberCoordinates(int number, bool cordinatesToTheLeft)
        {
            if (number != 0 && number != 11)
            {
                if (number == 10)
                    Console.Write(number);
                else
                {
                    if (cordinatesToTheLeft)
                        Console.Write($"{number} ");
                    else
                        Console.Write($" {number}");
                }
            }
        }

        private void PrintLetterCoordinates()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  \u2588\u2588 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("A  B  C  D  E  F  G  H  I  J");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" \u2588\u2588");
            Console.ResetColor();
        }

        private void BattlefieldColors(Coordinate coordinate)
        {
            switch (coordinate.VisualString)
            {
                case "~~~":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(coordinate.VisualString);
                    Console.ResetColor();
                    break;

                case "\u2588":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(coordinate.VisualString);
                    Console.ResetColor();
                    break;

                case "\u2588\u2588":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(coordinate.VisualString);
                    Console.ResetColor();
                    break;

                //case "\u2588\u2588\u2588\u2588\u2588":
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    Console.Write(coordinate.VisualString);
                //    Console.ResetColor();
                //    break;

                case "\u2588\u2588\u2588":
                    if (coordinate.Ship is Destroyer)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (coordinate.Ship is Cruiser)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (coordinate.Ship is Battleship)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (coordinate.Ship is Carrier)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(coordinate.VisualString);
                    Console.ResetColor();
                    break;

                default:
                    Console.Write(coordinate.VisualString);
                    break;
                    
            }
        }

        public void SetAllShipsToBattlefield()
        {
            foreach (var ship in Player.ListOfShips)
            {
                if (ship.HasBeenPlacedOnBattlefield)
                {
                    ship.SetShipToBattlefieldCoordinates();
                }
            }   
        }

        public void FireAtShips(Player player)
        {
            bool fire = false;
            int yCoordinate = 1;
            int xCoordinate = 1;
            while (!fire)
            {
                try
                {
                    bool targetAquired = false;
                    while (!targetAquired)
                    {
                        Console.SetCursorPosition(0, 0);
                        player.PrintPlayerBar();
                        Coordinates[yCoordinate, xCoordinate].VisualString = "XXX";
                        PrintBattlefield();
                        Coordinates[yCoordinate, xCoordinate].VisualString = "~~~";
                        if (Coordinates[yCoordinate, xCoordinate].HasBeenHit)
                        {
                            Coordinates[yCoordinate, xCoordinate].VisualString = "\u2591\u2591\u2591";
                            if (Coordinates[yCoordinate, xCoordinate].Ship != null)
                                Coordinates[yCoordinate, xCoordinate].VisualString = "\u2588\u2588\u2588";
                        }
                        Console.WriteLine("Choose a coordinate to fire at: ");
                        (yCoordinate, xCoordinate, targetAquired) = MoveToFire(yCoordinate, xCoordinate);

                        if (yCoordinate < 1)
                            yCoordinate = 1;
                        if (yCoordinate > 10)
                            yCoordinate = 10;
                        if (xCoordinate < 1)
                            xCoordinate = 1;
                        if (xCoordinate > 10)
                            xCoordinate = 10;
                    }

                    if (yCoordinate < 11 && yCoordinate > 0 && xCoordinate < 11 && xCoordinate > 0)
                    {
                        if (Coordinates[yCoordinate, xCoordinate].HasBeenHit == true)
                            throw new Exception("This coordinate has already been hit!!");
                        Coordinates[yCoordinate, xCoordinate].HasBeenHit = true;
                        if (Coordinates[yCoordinate, xCoordinate].Ship != null)
                        {
                            var ship = Coordinates[yCoordinate, xCoordinate].Ship;
                            Coordinates[yCoordinate, xCoordinate].VisualString = "\u2588\u2588\u2588";
                            var q = ship.ListOfCoordinates
                                .FirstOrDefault(q => q.YPosition == yCoordinate && q.XPosition == xCoordinate)
                                .ShipHasBeenHit = true;

                            ship.CheckIfShipSunk();
                            Console.Clear();
                            PrintHit();
                            Thread.Sleep(1000);
                            Console.Clear();
                            player.PrintPlayerBar();
                            PrintBattlefield();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You hit an enemy ship!");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Coordinates[yCoordinate, xCoordinate].VisualString = "\u2591\u2591\u2591";
                            Console.Clear();
                            PrintMiss();
                            Thread.Sleep(1000);
                            Console.Clear();
                            player.PrintPlayerBar();
                            PrintBattlefield();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You missed your shot!");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                        }
                        fire = true;
                        break;
                    }
                }
                catch
                {
                    fire = false;
                }
            }
        }

        private int GetCoordinateForLetter(string coordinateLetter)
        {
            switch (coordinateLetter.ToUpper())
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                default:
                    return 0;
            }
        }

        private static void PrintMiss()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ██████   ██████ █████  █████████   █████████ ");
            Console.WriteLine("░░██████ ██████ ░░███  ███░░░░░███ ███░░░░░███");
            Console.WriteLine(" ░███░█████░███  ░███ ░███    ░░░ ░███    ░░░ ");
            Console.WriteLine(" ░███░░███ ░███  ░███ ░░█████████ ░░█████████ ");
            Console.WriteLine(" ░███ ░░░  ░███  ░███  ░░░░░░░░███ ░░░░░░░░███");
            Console.WriteLine(" ░███      ░███  ░███  ███    ░███ ███    ░███");
            Console.WriteLine(" █████     █████ █████░░█████████ ░░█████████ ");
            Console.WriteLine("░░░░░     ░░░░░ ░░░░░  ░░░░░░░░░   ░░░░░░░░░  ");
            Console.ResetColor();
        }

        private static void PrintHit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" █████   █████ █████ ███████████");
            Console.WriteLine("░░███   ░░███ ░░███ ░█░░░███░░░█");
            Console.WriteLine(" ░███    ░███  ░███ ░   ░███  ░ ");
            Console.WriteLine(" ░███████████  ░███     ░███    ");
            Console.WriteLine(" ░███░░░░░███  ░███     ░███    ");
            Console.WriteLine(" ░███    ░███  ░███     ░███    ");
            Console.WriteLine(" █████   █████ █████    █████   ");
            Console.WriteLine("░░░░░   ░░░░░ ░░░░░    ░░░░░    ");
            Console.ResetColor();
        }

        private (int, int, bool) MoveToFire(int yCoordinate, int xCoordinate)
        {
            ConsoleKeyInfo keyInput = Console.ReadKey(true);

            switch (keyInput.Key)
            {
                case ConsoleKey.S:
                    return (yCoordinate += 1, xCoordinate, false);
                case ConsoleKey.D:
                    return (yCoordinate, xCoordinate += 1, false);
                case ConsoleKey.W:
                    return (yCoordinate -= 1, xCoordinate, false);
                case ConsoleKey.A:
                    return (yCoordinate, xCoordinate -= 1, false);
                case ConsoleKey.Enter:
                    return (yCoordinate, xCoordinate, true);
            }
            return (yCoordinate, xCoordinate, false);
        }
    }
}
