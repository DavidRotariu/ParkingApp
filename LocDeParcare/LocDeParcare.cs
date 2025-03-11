using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParkingApp
{
    public class LocDeParcare
    {
        public int Loc { get; set; }
        public bool Ocupat { get; set; }

        public LocDeParcare(int spotNumber)
        {
            Loc = spotNumber;
            Ocupat = false;
        }

        public void Ocupare()
        {
            if (!Ocupat)
            {
                Ocupat = true;
            }
        }

        public void Eliberare()
        {
            if (Ocupat)
            {
                Ocupat = false;
            }
        }

        public string GetInfo()
        {
            return $"Locul {Loc}: {(Ocupat ? "Ocupat" : "Liber")}";
        }
    }
}
