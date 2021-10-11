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
    }
}
