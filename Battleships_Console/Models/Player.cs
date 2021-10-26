using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Battlefield Battlefield { get; set; }
        public Destroyer Destroyer { get; set; }
        public Cruiser Cruiser { get; set; }
        public Battleship Battleship { get; set; }
        public Carrier Carrier { get; set; }
        public List<Ship> ListOfShips { get; set; }

        public Player(bool cpuPlayer)
        {
            Name = cpuPlayer == true ? "CPU" : SetPlayerName();
            Battlefield = new Battlefield(this);
            Destroyer = new Destroyer(this);
            Cruiser = new Cruiser(this);
            Battleship = new Battleship(this);
            Carrier = new Carrier(this);
            ListOfShips = new List<Ship>()
            {
                Battleship,
                Carrier,
                Destroyer,
                Cruiser
            };
        }

        private static string SetPlayerName()
        {
            Console.Write("Type your name: ");
            return Console.ReadLine();
        }

        public void PrintPlayerBar()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\u2588");
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Name);
            Console.ResetColor();
            for (int i = 0; i < (29 - Name.Length); i++)
            {
                Console.Write("\u2588");
            }
            Console.WriteLine();
        }

        public bool AllShipsSunk()
        {
            foreach (var ship in ListOfShips)
            {
                if (ship.ShipSunk == false)
                    return false;
            }
            return true;
        }
    }
}
