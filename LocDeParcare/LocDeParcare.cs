using System;

namespace ParkingApp
{
    public class LocDeParcare
    {
        public int Loc { get; set; }
        public bool Ocupat { get; private set; } = false;

        public LocDeParcare(int spotNumber)
        {
            Loc = spotNumber;
        }

        public void Ocupare()
        {
            if (!Ocupat)
            {
                Ocupat = true;
                Console.WriteLine($"Locul {Loc} a fost ocupat.");
            }
            else
            {
                Console.WriteLine($"Locul {Loc} este deja ocupat!");
            }
        }

        public void Eliberare()
        {
            if (Ocupat)
            {
                Ocupat = false;
                Console.WriteLine($"Locul {Loc} a fost eliberat.");
            }
            else
            {
                Console.WriteLine($"Locul {Loc} este deja liber!");
            }
        }

        public string GetInfo()
        {
            return $"Locul {Loc}: {(Ocupat ? "Ocupat" : "Liber")}";
        }
    }
}
