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
        //public List<BoatCoordiante> ListOfCoordinates { get; set; }
        public bool PositionHorizontally { get; set; }
        public Destroyer(Player player) /*: base(2)*/
        {
            ShipSunk = false;
            Player = player;
            PositionHorizontally = false;
            ListOfCoordinates = new List<BoatCoordiante>()
            {
                new BoatCoordiante(1, 1),
                new BoatCoordiante(1, 2)
            };
        }

        public override bool TrySetShipToBattlefieldCoordinates()
        {
            return TrySetShipToBattlefieldCoordinatesMethod(ListOfCoordinates, Player);
        }

        public override void SetShipToBattlefieldCoordinates()
        {
            SetShipToBattlefieldCoordinatesMethod(Player, ListOfCoordinates);
        }

        public override void RemoveShipFromBattlefieldCoordiantes()
        {
            RemoveShipFromBattlefieldCoordiantesMethod(Player, ListOfCoordinates);
        }

        public override void RotateShip()
        {
            if (!PositionHorizontally)
            {
                Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].RemoveShip();
                ListOfCoordinates[1].YPosition -= 1;
                ListOfCoordinates[1].XPosition -= 1;
                bool works = Check(true);
                if (works)
                {
                    PositionHorizontally = true;
                    SetShipToBattlefieldCoordinates();
                    Player.Battlefield.SetAllShipsToBattlefield();
                }
                else
                {
                    ListOfCoordinates[1].YPosition += 1;
                    ListOfCoordinates[1].XPosition += 1;
                    SetShipToBattlefieldCoordinates();
                }
            }
            else if (PositionHorizontally)
            {
                Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].RemoveShip();
                ListOfCoordinates[1].YPosition += 1;
                ListOfCoordinates[1].XPosition += 1;
                bool works = Check(true);
                if (works)
                {
                    PositionHorizontally = false;
                    SetShipToBattlefieldCoordinates();
                    Player.Battlefield.SetAllShipsToBattlefield();
                }
                else
                {
                    ListOfCoordinates[1].YPosition -= 1;
                    ListOfCoordinates[1].XPosition -= 1;
                    SetShipToBattlefieldCoordinates();
                }
            }
        }

        public override void MoveShipUp()
        {
            Placeable = false;

            RemoveShipFromBattlefieldCoordiantes();
            MoveShipUpMethod(ListOfCoordinates);
            bool works = Check(false);
            if(works)
            {
                Player.Battlefield.SetAllShipsToBattlefield();
                Placeable = TrySetShipToBattlefieldCoordinatesMethod(ListOfCoordinates, Player);

                SetShipToBattlefieldCoordinates();
            }
            else
            {
                MoveShipDownMethod(ListOfCoordinates);
                SetShipToBattlefieldCoordinates();
            }
        }

        public override void MoveShipDown()
        {
            Placeable = false;

            RemoveShipFromBattlefieldCoordiantes();
            MoveShipDownMethod(ListOfCoordinates);
            bool works = Check(false);
            if (works)
            {
                Player.Battlefield.SetAllShipsToBattlefield();
                Placeable = TrySetShipToBattlefieldCoordinatesMethod(ListOfCoordinates, Player);

                SetShipToBattlefieldCoordinates();
            }
            else
            {
                MoveShipUpMethod(ListOfCoordinates);
                SetShipToBattlefieldCoordinates();
            }
        }

        public override void MoveShipLeft()
        {
            Placeable = false;

            RemoveShipFromBattlefieldCoordiantes();
            MoveShipLeftMethod(ListOfCoordinates);
            bool works = Check(false);
            if (works)
            {
                Player.Battlefield.SetAllShipsToBattlefield();
                Placeable = TrySetShipToBattlefieldCoordinatesMethod(ListOfCoordinates, Player);

                SetShipToBattlefieldCoordinates();
            }
            else
            {
                MoveShipRightMethod(ListOfCoordinates);
                SetShipToBattlefieldCoordinates();
            }
        }

        public override void MoveShipRight()
        {
            Placeable = false;

            RemoveShipFromBattlefieldCoordiantes();
            MoveShipRightMethod(ListOfCoordinates);
            bool works = Check(false);
            if (works)
            {
                Player.Battlefield.SetAllShipsToBattlefield();
                Placeable = TrySetShipToBattlefieldCoordinatesMethod(ListOfCoordinates, Player);
                SetShipToBattlefieldCoordinates();
            }
            else
            {
                MoveShipLeftMethod(ListOfCoordinates);
                SetShipToBattlefieldCoordinates();
            }
        }

        private bool Check(bool rotatingShip)
        {
            if (ListOfCoordinates[0].YPosition <= 0 ||
                ListOfCoordinates[1].YPosition <= 0 ||
                ListOfCoordinates[0].XPosition <= 0 ||
                ListOfCoordinates[1].XPosition <= 0 ||
                ListOfCoordinates[0].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[1].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[0].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[1].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1)
                return false;
            return true;
        }

    }
}
