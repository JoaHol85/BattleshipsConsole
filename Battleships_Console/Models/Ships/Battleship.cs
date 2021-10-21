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
        public List<BoatCoordiante> ListOfCoordinates { get; set; }
        public string VisualString { get; set; } = "\u2588\u2588\u2588";
        public bool PositionHorizontally { get; set; }
        public Battleship(Player player)
        {
            Player = player;
            PositionHorizontally = false;
            ListOfCoordinates = new List<BoatCoordiante>()
            {
                new BoatCoordiante(1, 1),
                new BoatCoordiante(1, 2),
                new BoatCoordiante(1, 3),
                new BoatCoordiante(1, 4)
            };
        }

        public override void SetShipToBattlefieldCoordinates()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].VisualString = VisualString;
            //    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].Ship = this;
            //}
            Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].VisualString = VisualString;
            Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].Ship = this;
            Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].VisualString = VisualString;
            Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].Ship = this;
            Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].VisualString = VisualString;
            Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].Ship = this;
            Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].VisualString = VisualString;
            Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].Ship = this;
        }

        public override void RemoveShipFromBattlefieldCoordiantes()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].RemoveShip();
            //}
            Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].RemoveShip();
            Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].RemoveShip();
            Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].RemoveShip();
            Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].RemoveShip();
        }

        public override void RotateShip()
        {
            if (!PositionHorizontally)
            {
                //for (int i = 1; i < 3; i++)
                //{
                //    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].RemoveShip();
                //    ListOfCoordinates[i].YPosition -= i;
                //    ListOfCoordinates[i].XPosition -= i;
                //}
                Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].RemoveShip();
                Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].RemoveShip();
                Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].RemoveShip();
                ListOfCoordinates[1].YPosition -= 1;
                ListOfCoordinates[1].XPosition -= 1;
                ListOfCoordinates[2].YPosition -= 2;
                ListOfCoordinates[2].XPosition -= 2;
                ListOfCoordinates[3].YPosition -= 3;
                ListOfCoordinates[3].XPosition -= 3;
                bool works = Check(true);
                if (works)
                {
                    PositionHorizontally = true;
                    SetShipToBattlefieldCoordinates();
                }
                else
                {
                    //for (int i = 1; i < 3; i++)
                    //{
                    //    ListOfCoordinates[i].YPosition += i;
                    //    ListOfCoordinates[i].XPosition += i;
                    //}
                    ListOfCoordinates[1].YPosition += 1;
                    ListOfCoordinates[1].XPosition += 1;
                    ListOfCoordinates[2].YPosition += 2;
                    ListOfCoordinates[2].XPosition += 2;
                    ListOfCoordinates[3].YPosition += 3;
                    ListOfCoordinates[3].XPosition += 3;
                    SetShipToBattlefieldCoordinates();
                }
            }
            else if (PositionHorizontally)
            {
                //for (int i = 1; i < 3; i++)
                //{
                //    Player.Battlefield.Coordinates[ListOfCoordinates[i].YPosition, ListOfCoordinates[i].XPosition].RemoveShip();
                //    ListOfCoordinates[i].YPosition += i;
                //    ListOfCoordinates[i].XPosition += i;
                //}
                Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].RemoveShip();
                Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].RemoveShip();
                Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].RemoveShip();
                ListOfCoordinates[1].YPosition += 1;
                ListOfCoordinates[1].XPosition += 1;
                ListOfCoordinates[2].YPosition += 2;
                ListOfCoordinates[2].XPosition += 2;
                ListOfCoordinates[3].YPosition += 3;
                ListOfCoordinates[3].XPosition += 3;
                bool works = Check(true);
                if (works)
                {
                    PositionHorizontally = false;
                    SetShipToBattlefieldCoordinates();
                }
                else
                {
                    //for (int i = 1; i < 3; i++)
                    //{
                    //    ListOfCoordinates[i].YPosition -= i;
                    //    ListOfCoordinates[i].XPosition -= i;
                    //}
                    ListOfCoordinates[1].YPosition -= 1;
                    ListOfCoordinates[1].XPosition -= 1;
                    ListOfCoordinates[2].YPosition -= 2;
                    ListOfCoordinates[2].XPosition -= 2;
                    ListOfCoordinates[3].YPosition -= 3;
                    ListOfCoordinates[3].XPosition -= 3;
                    SetShipToBattlefieldCoordinates();
                }
            }

        }

        public override void MoveShipUp()
        {
            RemoveShipFromBattlefieldCoordiantes();
            ListOfCoordinates[0].YPosition -= 1;
            ListOfCoordinates[1].YPosition -= 1;
            ListOfCoordinates[2].YPosition -= 1;
            ListOfCoordinates[3].YPosition -= 1;
            bool works = Check(false);
            if (works)
                SetShipToBattlefieldCoordinates();
            else
            {
                ListOfCoordinates[0].YPosition += 1;
                ListOfCoordinates[1].YPosition += 1;
                ListOfCoordinates[2].YPosition += 1;
                ListOfCoordinates[3].YPosition += 1;
                SetShipToBattlefieldCoordinates();
            }
        }

        public override void MoveShipDown()
        {
            RemoveShipFromBattlefieldCoordiantes();
            ListOfCoordinates[0].YPosition += 1;
            ListOfCoordinates[1].YPosition += 1;
            ListOfCoordinates[2].YPosition += 1;
            ListOfCoordinates[3].YPosition += 1;
            bool works = Check(false);
            if (works)
                SetShipToBattlefieldCoordinates();
            else
            {
                ListOfCoordinates[0].YPosition -= 1;
                ListOfCoordinates[1].YPosition -= 1;
                ListOfCoordinates[2].YPosition -= 1;
                ListOfCoordinates[3].YPosition -= 1;
                SetShipToBattlefieldCoordinates();
            }
        }

        public override void MoveShipLeft()
        {
            RemoveShipFromBattlefieldCoordiantes();
            ListOfCoordinates[0].XPosition -= 1;
            ListOfCoordinates[1].XPosition -= 1;
            ListOfCoordinates[2].XPosition -= 1;
            ListOfCoordinates[3].XPosition -= 1;
            bool works = Check(false);
            if (works)
                SetShipToBattlefieldCoordinates();
            else
            {
                ListOfCoordinates[0].XPosition += 1;
                ListOfCoordinates[1].XPosition += 1;
                ListOfCoordinates[2].XPosition += 1;
                ListOfCoordinates[3].XPosition += 1;
                SetShipToBattlefieldCoordinates();
            }
        }

        public override void MoveShipRight()
        {
            RemoveShipFromBattlefieldCoordiantes();
            ListOfCoordinates[0].XPosition += 1;
            ListOfCoordinates[1].XPosition += 1;
            ListOfCoordinates[2].XPosition += 1;
            ListOfCoordinates[3].XPosition += 1;
            bool works = Check(false);
            if (works)
                SetShipToBattlefieldCoordinates();
            else
            {
                ListOfCoordinates[0].XPosition -= 1;
                ListOfCoordinates[1].XPosition -= 1;
                ListOfCoordinates[2].XPosition -= 1;
                ListOfCoordinates[3].XPosition -= 1;
                SetShipToBattlefieldCoordinates();
            }
        }

        private bool Check(bool rotatingShip)
        {
            if (ListOfCoordinates[0].YPosition <= 0 ||
                ListOfCoordinates[1].YPosition <= 0 ||
                ListOfCoordinates[2].YPosition <= 0 ||
                ListOfCoordinates[3].YPosition <= 0 ||
                ListOfCoordinates[0].XPosition <= 0 ||
                ListOfCoordinates[1].XPosition <= 0 ||
                ListOfCoordinates[2].XPosition <= 0 ||
                ListOfCoordinates[3].XPosition <= 0 ||
                ListOfCoordinates[0].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[1].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[2].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[3].YPosition >= Player.Battlefield.Coordinates.GetLength(0) - 1 ||
                ListOfCoordinates[0].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[1].YPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[2].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1 ||
                ListOfCoordinates[3].XPosition >= Player.Battlefield.Coordinates.GetLength(1) - 1)
                return false;
            if (!rotatingShip)
            {
                if (Player.Battlefield.Coordinates[ListOfCoordinates[0].YPosition, ListOfCoordinates[0].XPosition].Ship != null ||
                    Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].Ship != null ||
                    Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].Ship != null ||
                    Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].Ship != null)
                    return false;
            }
            else
            {
                if (Player.Battlefield.Coordinates[ListOfCoordinates[1].YPosition, ListOfCoordinates[1].XPosition].Ship != null ||
                    Player.Battlefield.Coordinates[ListOfCoordinates[2].YPosition, ListOfCoordinates[2].XPosition].Ship != null ||
                    Player.Battlefield.Coordinates[ListOfCoordinates[3].YPosition, ListOfCoordinates[3].XPosition].Ship != null)
                    return false;
            }


            return true;
        }

    }
}
