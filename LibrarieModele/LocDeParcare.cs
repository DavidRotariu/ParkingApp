using System;

namespace LibrarieModele
{
    public class LocDeParcare
    {
        public int Loc { get; set; }
        public StareLoc Stare { get; private set; } = StareLoc.Liber;

        public LocDeParcare(int loc)
        {
            Loc = loc;
        }

        public LocDeParcare(int loc, StareLoc stare)
        {
            Loc = loc;
            Stare = stare;
        }

        public void Ocupare()
        {
            if (Stare == StareLoc.Liber)
            {
                Stare = StareLoc.Ocupat;
            }
        }

        public void Eliberare()
        {
            if (Stare == StareLoc.Ocupat)
            {
                Stare = StareLoc.Liber;
            }
        }

        public string GetInfo()
        {
            return $"Locul {Loc}: {(Stare == StareLoc.Ocupat ? "Ocupat" : "Liber")}";
        }
    }
}
