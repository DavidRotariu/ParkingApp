using System;

namespace LibrarieModele
{
    public class Vehicul
    {
        private const char SEPARATOR = ';';

        public string NumarInmatriculare { get; set; }
        public DateTime OraIntrare { get; private set; }
        public DateTime? OraIesire { get; private set; }
        public int LocOcupat { get; set; }
        public string ParcareNume { get; set; }
        public TipVehicul Tip { get; set; }

        // Constructor pentru creare vehicul nou
        public Vehicul(string numarInmatriculare, int locOcupat, string parcareNume, TipVehicul tip = TipVehicul.Autoturism)
        {
            NumarInmatriculare = numarInmatriculare;
            OraIntrare = DateTime.Now;
            OraIesire = null;
            LocOcupat = locOcupat;
            ParcareNume = parcareNume;
            Tip = tip;
        }

        // Constructor pentru creare din fisier
        public Vehicul(string linieFisier)
        {
            string[] tokens = linieFisier.Split(SEPARATOR);
            NumarInmatriculare = tokens[0];
            OraIntrare = DateTime.Parse(tokens[1]);
            OraIesire = tokens[2] == "null" ? null : (DateTime?)DateTime.Parse(tokens[2]);
            LocOcupat = int.Parse(tokens[3]);
            ParcareNume = tokens[4];

            // Add backwards compatibility for files without vehicle type
            if (tokens.Length > 5)
            {
                Tip = (TipVehicul)Enum.Parse(typeof(TipVehicul), tokens[5]);
            }
            else
            {
                Tip = TipVehicul.Autoturism; // Default value
            }
        }

        // Metoda pentru inregistrarea iesirii vehiculului
        public void InregistrareIesire()
        {
            if (!OraIesire.HasValue)
            {
                OraIesire = DateTime.Now;
            }
        }

        // Metoda pentru calcularea duratei de parcare
        public TimeSpan CalculareDurataParcare()
        {
            DateTime oraFinala = OraIesire ?? DateTime.Now;
            return oraFinala - OraIntrare;
        }

        // Metoda pentru calcularea costului
        public decimal CalculareCost(decimal tarifOra)
        {
            TimeSpan durata = CalculareDurataParcare();
            // Rotunjirea la ora sau fracțiune de oră, minim 1 oră
            double ore = Math.Ceiling(durata.TotalHours);
            ore = Math.Max(1, ore); // Minim 1 oră

            // Apply discounts or surcharges based on vehicle type
            decimal multiplier = 1.0m;
            switch (Tip)
            {
                case TipVehicul.Motocicleta:
                    multiplier = 0.7m; // 30% discount for motorcycles
                    break;
                case TipVehicul.Camion:
                    multiplier = 1.5m; // 50% surcharge for trucks
                    break;
                case TipVehicul.Electric:
                    multiplier = 0.8m; // 20% discount for electric vehicles
                    break;
                default:
                    multiplier = 1.0m;
                    break;
            }

            return (decimal)ore * tarifOra * multiplier;
        }

        // Metoda pentru obtinerea starii vehiculului
        public string GetInfo()
        {
            string stare = OraIesire.HasValue ? "Ieșit" : "Parcat";
            TimeSpan durata = CalculareDurataParcare();

            return $"Vehicul cu număr {NumarInmatriculare}\n" +
                   $"Tip: {Tip}\n" +
                   $"Stare: {stare}\n" +
                   $"Locul: {LocOcupat} în parcarea {ParcareNume}\n" +
                   $"Ora intrare: {OraIntrare}\n" +
                   $"Ora ieșire: {(OraIesire.HasValue ? OraIesire.Value.ToString() : "Încă parcat")}\n" +
                   $"Durata: {Math.Floor(durata.TotalHours)}h {durata.Minutes}m";
        }

        // Metoda pentru conversia vehiculului in format pentru fisier
        public string ConversieLaSir_PentruFisier()
        {
            string oraIesireStr = OraIesire.HasValue ? OraIesire.Value.ToString() : "null";

            return $"{NumarInmatriculare}{SEPARATOR}" +
                   $"{OraIntrare}{SEPARATOR}" +
                   $"{oraIesireStr}{SEPARATOR}" +
                   $"{LocOcupat}{SEPARATOR}" +
                   $"{ParcareNume}{SEPARATOR}" +
                   $"{Tip}";
        }
    }
}