using LibrarieModele;
using System;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareParcari_FisierText
    {
        private const int NR_MAX_PARCARI = 50;
        private string numeFisier;
        private const char SEPARATOR = ';';

        public AdministrareParcari_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddParcare(Parcare parcare)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, true))
            {
                writer.WriteLine(parcare.ConversieLaSir_PentruFisier());
            }
        }

        public Parcare[] GetParcari(out int nrParcari)
        {
            Parcare[] parcari = new Parcare[NR_MAX_PARCARI];
            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string line;
                nrParcari = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    parcari[nrParcari++] = new Parcare(line);
                }
            }
            return parcari;
        }

        // Cautare dupa nume
        public Parcare FindParcareByNume(string numeParcare)
        {
            int nrParcari;
            Parcare[] parcari = GetParcari(out nrParcari);

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
            int nrParcari;
            Parcare[] parcari = GetParcari(out nrParcari);
            bool actualizat = false;

            for (int i = 0; i < nrParcari; i++)
            {
                if (parcari[i].Nume.Equals(parcareDeActualizat.Nume, StringComparison.OrdinalIgnoreCase))
                {
                    parcari[i] = parcareDeActualizat;
                    actualizat = true;
                    break;
                }
            }

            if (actualizat)
            {
                UpdateParcari(parcari, nrParcari);
            }

            return actualizat;
        }

        public void UpdateParcari(Parcare[] parcari, int nrParcari)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, false))
            {
                for (int i = 0; i < nrParcari; i++)
                {
                    writer.WriteLine(parcari[i].ConversieLaSir_PentruFisier());
                }
            }
        }
    }
}