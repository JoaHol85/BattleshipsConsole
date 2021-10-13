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

        public Player(bool cpuPlayer)
        {
            Name = cpuPlayer == true ? "CPU" : SetPlayerName();
            Battlefield = new Battlefield(this);
            Destroyer = new Destroyer(this);
            Cruiser = new Cruiser(this);
            Battleship = new Battleship(this);
            Carrier = new Carrier(this);
        }

        private static string SetPlayerName()
        {
            Console.Write("Type your name: ");
            return Console.ReadLine();
        }
    
    
    }

    
}
