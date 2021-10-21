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
        public List<BoatCoordiante> ListOfCoordinates { get; set; }
        public string VisualString { get; set; } = "\u2588\u2588\u2588";
        public bool PositionHorizontally { get; set; }
        public Destroyer(Player player)
        {
            Player = player;
            PositionHorizontally = false;
            ListOfCoordinates = new List<BoatCoordiante>()
            {
                new BoatCoordiante(1, 1),
                new BoatCoordiante(1, 2)
            };
        }

        public override void SetShipToBattlefieldCoordinates()
        {
            Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].VisualString = VisualString;
            Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].Ship = this;
            Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].VisualString = VisualString;
            Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].Ship = this;
        }

        public override void RemoveShipFromBattlefieldCoordiantes()
        {
            Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].RemoveShip();
            Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].RemoveShip();
        }

        public override void RotateShipCordinates()
        {
            if (PositionHorizontally)
            {
                ListOfCoordinates[1].YPosition -= 1;
                ListOfCoordinates[1].XPosition -= 1;
                PositionHorizontally = true;
            }
            else if (PositionHorizontally)
            {
                ListOfCoordinates[1].YPosition += 1;
                ListOfCoordinates[1].XPosition += 1;
                PositionHorizontally = false;
            }
        }


    }
}
