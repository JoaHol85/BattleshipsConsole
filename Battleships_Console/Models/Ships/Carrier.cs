using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models.Ships
{
    public class Carrier : Ship
    {
        public Player Player { get; set; }
        //public List<BoatCoordiante> ListOfCoordinates { get; set; }
        public bool PositionHorizontally { get; set; }

        public Carrier(Player player) /*: base (5)*/
        {
            ShipSunk = false;
            Player = player;
            PositionHorizontally = false;
            ListOfCoordinates = new List<BoatCoordiante>()
            {
                new BoatCoordiante(1, 1),
                new BoatCoordiante(1, 2),
                new BoatCoordiante(1, 3),
                new BoatCoordiante(1, 4),
                new BoatCoordiante(1, 5)
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
                for (int i = 1; i < 5; i++)
                {
                    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].RemoveShip();
                    ListOfCoordinates[i].YPosition -= i;
                    ListOfCoordinates[i].XPosition -= i;
                }
                bool works = Check(true);
                if (works)
                {
                    PositionHorizontally = true;
                    SetShipToBattlefieldCoordinates();
                    Player.Battlefield.SetAllShipsToBattlefield();
                }
                else
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ListOfCoordinates[i].YPosition += i;
                        ListOfCoordinates[i].XPosition += i;
                    }
                    SetShipToBattlefieldCoordinates();
                }
            }
            else if (PositionHorizontally)
            {
                for (int i = 1; i < 5; i++)
                {
                    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].RemoveShip();
                    ListOfCoordinates[i].YPosition += i;
                    ListOfCoordinates[i].XPosition += i;
                }
                bool works = Check(true);
                if (works)
                {
                    PositionHorizontally = false;
                    SetShipToBattlefieldCoordinates();
                    Player.Battlefield.SetAllShipsToBattlefield();
                }
                else
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ListOfCoordinates[i].YPosition -= i;
                        ListOfCoordinates[i].XPosition -= i;
                    }
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
            if (works)
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
                ListOfCoordinates[2].YPosition <= 0 ||
                ListOfCoordinates[3].YPosition <= 0 ||
                ListOfCoordinates[4].YPosition <= 0 ||
                ListOfCoordinates[0].XPosition <= 0 ||
                ListOfCoordinates[1].XPosition <= 0 ||
                ListOfCoordinates[2].XPosition <= 0 ||
                ListOfCoordinates[3].XPosition <= 0 ||
                ListOfCoordinates[4].XPosition <= 0 ||
                ListOfCoordinates[0].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[1].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[2].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[3].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[4].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[0].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[1].YPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[2].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[3].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[4].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1)
                return false;
            return true;
        }

    }
}
