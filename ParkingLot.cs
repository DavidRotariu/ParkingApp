using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParkingApp
{
    public class Parcare
    {
        public string Name { get; set; }
        public List<LocDeParcare> Spots { get; set; }

        public Parcare(string name, int totalSpots)
        {
            Name = name;
            Spots = new List<LocDeParcare>();

            for (int i = 1; i <= totalSpots; i++)
            {
                Spots.Add(new LocDeParcare(i));
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
