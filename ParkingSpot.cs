using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParkingApp
{
    public class LocDeParcare
    {
        public int SpotNumber { get; set; }
        public bool IsOccupied { get; set; }

        public LocDeParcare(int spotNumber)
        {
            SpotNumber = spotNumber;
            IsOccupied = false;
        }

        public void ParkCar()
        {
            if (!IsOccupied)
            {
                IsOccupied = true;
                Console.WriteLine($"Masina parcata in locul {SpotNumber}.");
            }
            else
            {
                Console.WriteLine($"Locul {SpotNumber} este deja ocupata.");
            }
        }

        public void FreeSpot()
        {
            if (IsOccupied)
            {
                IsOccupied = false;
                Console.WriteLine($"Locul {SpotNumber} s-a eliberat.");
            }
            else
            {
                Console.WriteLine($"Locul {SpotNumber} este deja liber.");
            }
        }

        public string GetInfo()
        {
            return $"Locul {SpotNumber}: {(IsOccupied ? "Ocupat" : "Liber")}";
        }
    }
}
