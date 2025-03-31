using System;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareVehicule_FisierText
    {
        private const int NR_MAX_VEHICULE = 500;
        private string numeFisier;

        public AdministrareVehicule_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddVehicul(Vehicul vehicul)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, true))
            {
                writer.WriteLine(vehicul.ConversieLaSir_PentruFisier());
            }
        }

        public Vehicul[] GetVehicule(out int nrVehicule)
        {
            Vehicul[] vehicule = new Vehicul[NR_MAX_VEHICULE];
            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string line;
                nrVehicule = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    vehicule[nrVehicule++] = new Vehicul(line);
                }
            }
            return vehicule;
        }

        public Vehicul FindVehiculByNumarInmatriculare(string numarInmatriculare)
        {
            int nrVehicule;
            Vehicul[] vehicule = GetVehicule(out nrVehicule);

            for (int i = 0; i < nrVehicule; i++)
            {
                if (vehicule[i].NumarInmatriculare.Equals(numarInmatriculare, StringComparison.OrdinalIgnoreCase))
                {
                    return vehicule[i];
                }
            }

            return null;
        }

        public Vehicul[] FindVehiculeByLoc(int locParcare, string numeParcare, out int nrVehicule)
        {
            int totalVehicule;
            Vehicul[] toateVehiculele = GetVehicule(out totalVehicule);
            Vehicul[] vehiculeLoc = new Vehicul[NR_MAX_VEHICULE];

            nrVehicule = 0;
            for (int i = 0; i < totalVehicule; i++)
            {
                if (toateVehiculele[i].LocOcupat == locParcare &&
                    toateVehiculele[i].ParcareNume.Equals(numeParcare, StringComparison.OrdinalIgnoreCase) &&
                    !toateVehiculele[i].OraIesire.HasValue)
                {
                    vehiculeLoc[nrVehicule++] = toateVehiculele[i];
                }
            }

            return vehiculeLoc;
        }

        public bool UpdateVehicul(Vehicul vehiculDeActualizat)
        {
            int nrVehicule;
            Vehicul[] vehicule = GetVehicule(out nrVehicule);
            bool actualizat = false;

            for (int i = 0; i < nrVehicule; i++)
            {
                if (vehicule[i].NumarInmatriculare.Equals(vehiculDeActualizat.NumarInmatriculare, StringComparison.OrdinalIgnoreCase))
                {
                    vehicule[i] = vehiculDeActualizat;
                    actualizat = true;
                    break;
                }
            }

            if (actualizat)
            {
                UpdateVehicule(vehicule, nrVehicule);
            }

            return actualizat;
        }

        private void UpdateVehicule(Vehicul[] vehicule, int nrVehicule)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, false))
            {
                for (int i = 0; i < nrVehicule; i++)
                {
                    writer.WriteLine(vehicule[i].ConversieLaSir_PentruFisier());
                }
            }
        }
    }
}