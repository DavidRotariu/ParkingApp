using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parcarea1 = new ParkingLot("Centru", 5);

            parcarea1.DisplayParkingStatus();

            Console.WriteLine("\nParcam in locul 3...");
            parcarea1.Spots[2].ParkCar();

            Console.WriteLine("\nParcarea:");
            parcarea1.DisplayParkingStatus();

            Console.WriteLine("\nEliberam locul 3...");
            parcarea1.Spots[2].FreeSpot();

            Console.WriteLine("\nParcarea:");
            parcarea1.DisplayParkingStatus();
        }
    }
}
