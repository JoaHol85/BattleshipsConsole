using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models
{
    public class BoatCoordiante
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public BoatCoordiante(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}
