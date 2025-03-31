using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarieModele
{
    public class Parcare
    {
        private const char SEPARATOR = ';';
        public string Nume { get; set; }
        public List<LocDeParcare> Locuri { get; set; }
        public decimal TarifOra { get; set; }

        public Parcare(string nume, int totalSpots, decimal tarifOra = 5.0m)
        {
            Nume = nume;
            TarifOra = tarifOra;
            Locuri = new List<LocDeParcare>();
            for (int i = 1; i <= totalSpots; i++)
            {
                Locuri.Add(new LocDeParcare(i));
            }
        }

        public Parcare(string linieFisier)
        {
            string[] tokens = linieFisier.Split(SEPARATOR);
            Nume = tokens[0];

            // Extrage tariful (adaugat la finalul liniei)
            TarifOra = tokens.Length > 2 ? decimal.Parse(tokens[tokens.Length - 1]) : 5.0m;

            int totalSpots = int.Parse(tokens[1]);
            Locuri = new List<LocDeParcare>();

            // Citirea statusului fiecarui loc (ocupat/liber)
            for (int i = 0; i < totalSpots; i++)
            {
                bool ocupat = false;
                if (tokens.Length > 3 + i) // +1 pentru indexul shifted din cauza tarifului adaugat la final
                {
                    ocupat = tokens[2 + i] == "1";
                }
                Locuri.Add(new LocDeParcare(i + 1, ocupat));
            }
        }

        public string GetStatusParcare()
        {
            StringBuilder status = new StringBuilder();
            status.AppendLine($"Parcarea: {Nume} (Tarif: {TarifOra} lei/ora)");
            foreach (var spot in Locuri)
            {
                status.AppendLine(spot.GetInfo());
            }
            return status.ToString();
        }

        public bool OcupareLoc(int numarLoc)
        {
            if (numarLoc >= 1 && numarLoc <= Locuri.Count)
            {
                Locuri[numarLoc - 1].Ocupare();
                return true;
            }

            return false;
        }

        public bool EliberareLoc(int numarLoc)
        {
            if (numarLoc >= 1 && numarLoc <= Locuri.Count)
            {
                Locuri[numarLoc - 1].Eliberare();
                return true;
            }

            return false;
        }

        public string ConversieLaSir_PentruFisier()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nume).Append(SEPARATOR).Append(Locuri.Count);
            foreach (var spot in Locuri)
            {
                sb.Append(SEPARATOR).Append(spot.Ocupat ? "1" : "0");
            }
            // Adaugam tariful la finalul liniei
            sb.Append(SEPARATOR).Append(TarifOra);
            return sb.ToString();

            // Va adauga in fisiere: ParkingName;10;0;1;0;0;1;1;0;0;0;0;5.5
        }
    }
}