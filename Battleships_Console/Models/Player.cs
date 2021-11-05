﻿using Battleships_Console.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Console.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Battlefield Battlefield { get; set; }
        public Destroyer Destroyer { get; set; }
        public Cruiser Cruiser { get; set; }
        public Battleship Battleship { get; set; }
        public Carrier Carrier { get; set; }
        public List<Ship> ListOfShips { get; set; }
        public bool FirstPlayer { get; set; }

        public Player(bool cpuPlayer, bool firstPlayer)
        {
            Name = cpuPlayer == true ? "CPU" : SetPlayerName();
            FirstPlayer = firstPlayer;
            Battlefield = new Battlefield(this);
            Destroyer = new Destroyer(this);
            Cruiser = new Cruiser(this);
            Battleship = new Battleship(this);
            Carrier = new Carrier(this);
            ListOfShips = new List<Ship>()
            {
                Battleship,
                Carrier,
                Destroyer,
                Cruiser
            };
        }

        private static string SetPlayerName()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Type your name: ");
                string name = Console.ReadLine();
                if (name != "")
                {
                    if (name.Length < 30 && name.Length > 0)
                        return name;
                    else
                    {
                        Console.WriteLine("The name must be more than 0, and less then 30 characters long.");
                        Console.WriteLine("To try again, press any key!");
                        Console.ReadKey();
                    }

                }
            }
        }

        public void PrintPlayerBar()
        {
            int nameLength = Name.Length;
            int nameStart = (38 - Name.Length) / 2;

            if (FirstPlayer)
                Console.BackgroundColor = ConsoleColor.Blue;
            if (!FirstPlayer)
                Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 0; i < 38; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();

            for (int i = 0; i < nameStart; i++)
            {
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Name);

            if (FirstPlayer)
                Console.BackgroundColor = ConsoleColor.Blue;
            if (!FirstPlayer)
                Console.BackgroundColor = ConsoleColor.Red;

            for (int i = nameStart + nameLength; i < 38; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < 38; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public bool AllShipsSunk()
        {
            foreach (var ship in ListOfShips)
            {
                if (ship.ShipSunk == false)
                    return false;
            }
            return true;
        }
    }
}
