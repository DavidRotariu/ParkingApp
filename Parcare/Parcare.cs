using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp
{
    public class Parcare
    {
        public string Nume { get; set; }
        public List<LocDeParcare> Locuri { get; set; }

        public Parcare(string nume, int totalSpots)
        {
            Nume = nume;
            Locuri = new List<LocDeParcare>();

            for (int i = 1; i <= totalSpots; i++)
            {
                Locuri.Add(new LocDeParcare(i));
            }
        }

        public string GetStatusParcare()
        {
            StringBuilder status = new StringBuilder();
            status.AppendLine($"Parcarea: {Nume}");

            foreach (var spot in Locuri)
            {
                status.AppendLine(spot.GetInfo());
            }

            return status.ToString();
        }

        public void OcupareLoc(int numarLoc)
        {
            if (numarLoc >= 1 && numarLoc <= Locuri.Count)
            {
                Locuri[numarLoc - 1].Ocupare();
            }
            else
            {
                Console.WriteLine($"Locul {numarLoc} nu exista!");
            }
        }

        public void EliberareLoc(int numarLoc)
        {
            if (numarLoc >= 1 && numarLoc <= Locuri.Count)
            {
                Locuri[numarLoc - 1].Eliberare();
            }
            else
            {
                Console.WriteLine($"Locul {numarLoc} nu exista!");
            }
        }
    }
}
