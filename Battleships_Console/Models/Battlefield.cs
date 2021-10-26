using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            for (int y = 0; y < Coordinates.GetLength(0); y++)
            {
                for (int x = 0; x < Coordinates.GetLength(1); x++)
                {
                    
                    BattlefieldColors(Coordinates[y, x]);
                }
                Console.WriteLine();
                if (y != 0 && y != Coordinates.GetLength(0) - 1)
                {
                    for (int x = 0; x < Coordinates.GetLength(1); x++)
                    {
                        BattlefieldColors(Coordinates[y, x]);
                    }
                    Console.WriteLine();
                }
            }
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


    }
}
