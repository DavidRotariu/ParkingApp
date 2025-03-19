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

        public Parcare(string nume, int totalSpots)
        {
            Nume = nume;
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
            int totalSpots = int.Parse(tokens[1]);
            Locuri = new List<LocDeParcare>();
            for (int i = 0; i < totalSpots; i++)
            {
                StareLoc stare = StareLoc.Liber;
                if (tokens.Length > 2 + i)
                {
                    stare = tokens[2 + i] == "1" ? StareLoc.Ocupat : StareLoc.Liber;
                }
                Locuri.Add(new LocDeParcare(i + 1, stare));
            }
        }

        public string GetStatusParcare()
        {
            StringBuilder status = new StringBuilder();
            status.AppendLine($"Parcarea: {Nume}");
            foreach (var spot in Locuri)
            {
                status.AppendLine(spot.GetInfo());
            }
            return status.ToString();
        }

        public void OcupareLoc(int numarLoc)
        {
            if (numarLoc >= 1 && numarLoc <= Locuri.Count)
            {
                Locuri[numarLoc - 1].Ocupare();
            }
            else
            {
                Console.WriteLine($"Locul {numarLoc} nu exista!");
            }
        }

        public void EliberareLoc(int numarLoc)
        {
            if (numarLoc >= 1 && numarLoc <= Locuri.Count)
            {
                Locuri[numarLoc - 1].Eliberare();
            }
            else
            {
                Console.WriteLine($"Locul {numarLoc} nu exista!");
            }
        }

        public string ConversieLaSir_PentruFisier()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nume).Append(SEPARATOR).Append(Locuri.Count);
            foreach (var spot in Locuri)
            {
                sb.Append(SEPARATOR).Append(spot.Stare == StareLoc.Ocupat ? "1" : "0");
            }
            return sb.ToString();
        }
    }
}
