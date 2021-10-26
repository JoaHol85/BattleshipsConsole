using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models.Ships
{
    public class Ship
    {
        public string VisualString { get; set; } = "\u2588\u2588\u2588";
        public bool HasBeenPlacedOnBattlefield { get; set; } = false;
        public bool Placeable { get; set; }



        //Checks if ship can be placed on coordinates
        public virtual bool TrySetShipToBattlefieldCoordinates()
        {
            return false;
        }
        public bool TrySetShipToBattlefieldCoordinatesMethod(List<BoatCoordiante> listOfBoatCoordinates, Player player)
        {
            foreach (var coordiante in listOfBoatCoordinates)
            {
                if (player.Battlefield.Coordinates[coordiante.YPosition, coordiante.XPosition].Ship != null)
                {
                    return false;
                }
            }
            return true;
        }



        // Sets the ship to coordinates on the battlefield.
        public virtual void SetShipToBattlefieldCoordinates()
        {
        }
        public void SetShipToBattlefieldCoordinatesMethod(Player player, List<BoatCoordiante> listOfBoatCoordinates)
        {
            for (int i = 0; i < listOfBoatCoordinates.Count; i++)
            {
                player.Battlefield.Coordinates[listOfBoatCoordinates[i].YPosition, listOfBoatCoordinates[i].XPosition].VisualString = VisualString;
                player.Battlefield.Coordinates[listOfBoatCoordinates[i].YPosition, listOfBoatCoordinates[i].XPosition].Ship = this;
            }
        }


        // Removes ship from coordinates on the battlefield.
        public virtual void RemoveShipFromBattlefieldCoordiantes()
        {
        }
        public void RemoveShipFromBattlefieldCoordiantesMethod(Player player, List<BoatCoordiante> listOfBoatCoordinates)
        {
            for (int i = 0; i < listOfBoatCoordinates.Count; i++)
            {
                player.Battlefield.Coordinates[listOfBoatCoordinates[i].YPosition, listOfBoatCoordinates[i].XPosition].RemoveShip();
            }
        }


        public virtual void RotateShip()
        {
        }


        // Moves ship up the battlefield.
        public virtual void MoveShipUp()
        {
        }
        public void MoveShipUpMethod(List<BoatCoordiante> listOfBoatCoordinates)
        {
            for (int i = 0; i < listOfBoatCoordinates.Count; i++)
            {
                listOfBoatCoordinates[i].YPosition -= 1;
            }
        }


        // Moves ship down the battlefield.
        public virtual void MoveShipDown()
        {
        }
        public void MoveShipDownMethod(List<BoatCoordiante> listOfBoatCoordinates)
        {
            for (int i = 0; i < listOfBoatCoordinates.Count; i++)
            {
                listOfBoatCoordinates[i].YPosition += 1;
            }
        }


        // Moves ship left on the battlefield.
        public virtual void MoveShipLeft()
        {
        }
        public void MoveShipLeftMethod(List<BoatCoordiante> listOfBoatCoordinates)
        {
            for (int i = 0; i < listOfBoatCoordinates.Count; i++)
            {
                listOfBoatCoordinates[i].XPosition -= 1;
            }
        }


        // Moves ship right on the battlefield.
        public virtual void MoveShipRight()
        {
        }
        public void MoveShipRightMethod(List<BoatCoordiante> listOfBoatCoordinates)
        {
            for (int i = 0; i < listOfBoatCoordinates.Count; i++)
            {
                listOfBoatCoordinates[i].XPosition += 1;
            }
        }

    }
}
