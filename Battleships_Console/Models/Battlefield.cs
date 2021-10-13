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
            Coordinates = new Coordinate[11, 11];
            MakeBFFrame();
        }




        //U+2588 = Block
        private void MakeBFFrame()
        {
            for (int y = 0; y < Coordinates.GetLength(0); y++)
            {
                for (int x = 0; x < Coordinates.GetLength(1); x++)
                {
                    if (y == 0 && x == 0)
                        Coordinates[y, x] = new Coordinate() { VisualString = "" };
                    else if (y == Coordinates.GetLength(0) - 1 && x == Coordinates.GetLength(1) - 1)
                        Coordinates[y, x] = new Coordinate() { VisualString = "" };
                    else if (y == 0 || y == Coordinates.GetLength(0) - 1)
                        Coordinates[y, x] = new Coordinate() { VisualString = "\u2588\u2588\u2588\u2588" };
                    else if (x == 0 || x == Coordinates.GetLength(1) - 1)
                        Coordinates[y, x] = new Coordinate() { VisualString = "\u2588\u2588" };
                    else
                        Coordinates[y, x] = new Coordinate() { VisualString = "~~~~" };
                }
            }
        }

        public void PrintBattlefield()
        {
            for (int y = 0; y < Coordinates.GetLength(0); y++)
            {
                for (int x = 0; x < Coordinates.GetLength(1); x++)
                {
                    Console.Write(Coordinates[y, x].VisualString);
                }
                Console.WriteLine();
                if (y != 0 || y != Coordinates.GetLength(0) - 1)
                {
                    for (int x = 0; x < Coordinates.GetLength(1); x++)
                    {
                        Console.Write(Coordinates[y, x].VisualString);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
