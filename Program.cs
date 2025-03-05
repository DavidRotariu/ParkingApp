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
            Parcare parcarea1 = new Parcare("Centru", 5);

            Console.WriteLine(parcarea1.GetStatusParcare());

            Console.WriteLine("\nParcam in locul 3...\n");
            parcarea1.Locuri[2].Ocupare();
            Console.WriteLine(parcarea1.GetStatusParcare());

            Console.WriteLine("\nEliberam locul 3...\n");
            parcarea1.Locuri[2].Eliberare();
            Console.WriteLine(parcarea1.GetStatusParcare());
        }
    }
}
