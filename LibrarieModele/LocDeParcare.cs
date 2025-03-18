using System;

namespace LibrarieModele
{
    public class LocDeParcare
    {
        public int Loc { get; set; }
        public bool Ocupat { get; private set; } = false;

        public LocDeParcare(int loc)
        {
            Loc = loc;
        }

        public LocDeParcare(int loc, bool ocupat)
        {
            Loc = loc;
            Ocupat = ocupat;
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
