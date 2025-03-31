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

        public bool AddParcare(Parcare parcare)
        {
            if (nrParcari < NR_MAX_PARCARI)
            {
                parcari[nrParcari] = parcare;
                nrParcari++;
            }
            else
            {
                // Capacity reached, returning false instead of writing to console
                return false;
            }
            return true;
        }

        public Parcare[] GetParcari(out int nrParcari)
        {
            nrParcari = this.nrParcari;
            return parcari;
        }

        public Parcare FindParcareByNume(string numeParcare)
        {
            for (int i = 0; i < nrParcari; i++)
            {
                if (parcari[i].Nume.Equals(numeParcare, StringComparison.OrdinalIgnoreCase))
                {
                    return parcari[i];
                }
            }

            return null;
        }

        public bool UpdateParcare(Parcare parcareDeActualizat)
        {
            for (int i = 0; i < nrParcari; i++)
            {
                if (parcari[i].Nume.Equals(parcareDeActualizat.Nume, StringComparison.OrdinalIgnoreCase))
                {
                    parcari[i] = parcareDeActualizat;
                    return true;
                }
            }

            return false;
        }
    }
}