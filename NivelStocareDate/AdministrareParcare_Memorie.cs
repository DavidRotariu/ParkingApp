using System;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareParcare_Memorie
    {
        private const int NR_MAX_PARCARI = 50;
        private Parcare[] parcari;
        private int nrParcari;

        public AdministrareParcare_Memorie()
        {
            parcari = new Parcare[NR_MAX_PARCARI];
            nrParcari = 0;
        }

        public void AddParcare(Parcare parcare)
        {
            if (nrParcari < NR_MAX_PARCARI)
            {
                parcari[nrParcari] = parcare;
                nrParcari++;
            }
            else
            {
                Console.WriteLine("Capacitate maxima atinsa!");
            }
        }

        public Parcare[] GetParcari(out int nrParcari)
        {
            nrParcari = this.nrParcari;
            return parcari;
        }
    }
}
