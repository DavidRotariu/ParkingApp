using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParkingApp
{
    public class ParkingLot
    {
        public string Name { get; set; }
        public List<ParkingSpot> Spots { get; set; }

        public ParkingLot(string name, int totalSpots)
        {
            Name = name;
            Spots = new List<ParkingSpot>();

            for (int i = 1; i <= totalSpots; i++)
            {
                Spots.Add(new ParkingSpot(i));
            }
        }

        public void DisplayParkingStatus()
        {
            Console.WriteLine($"Parcarea: {Name}");
            foreach (var spot in Spots)
            {
                Console.WriteLine(spot.GetInfo());
            }
        }
    }
}
