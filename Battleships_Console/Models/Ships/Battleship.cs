using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models.Ships
{
    public class Battleship : Ship
    {
        public Player Player { get; set; }
        public BoatCoordiante Position1 { get; set; }
        public BoatCoordiante Position2 { get; set; }
        public BoatCoordiante Position3 { get; set; }
        public BoatCoordiante Position4 { get; set; }
    

        public Battleship(Player player)
        {
            Player = player;
        }

    }
}
