using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models
{
    public class Coordinate
    {
        public bool HasBeenHit { get; set; }
        public Ship Ship { get; set; }
        public int ShipCoordinatePosition { get; set; }

    }
}
