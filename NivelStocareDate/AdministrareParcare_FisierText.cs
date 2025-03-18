using LibrarieModele;
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
