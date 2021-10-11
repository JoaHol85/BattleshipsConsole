using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models.Ships
{
    public class Destroyer : Ship
    {
        public Player Player { get; set; }
        public BoatCoordiante Position1 { get; set; }
        public BoatCoordiante Position2 { get; set; }
        public Destroyer(Player player)
        {
            Player = player;
        }
    }
}
