using System;
using NivelStocareDate;
using LibrarieModele;

namespace ParkingApp
{
    class Program
    {
        static void Main()
        {
            string numeFisier = "parcari.txt";
            AdministrareParcari_FisierText adminParcari = new AdministrareParcari_FisierText(numeFisier);

            string optiune;
            do
            {
                Console.WriteLine("\nMeniu:");
                Console.WriteLine("A. Afiseaza toate parcarile din fisier");
                Console.WriteLine("N. Adauga o noua parcare");
                Console.WriteLine("O. Ocupa un loc de parcare");
                Console.WriteLine("L. Elibereaza un loc de parcare");
                Console.WriteLine("X. Iesire");
                Console.Write("Alegeti o optiune: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "A":
                        AfiseazaParcari(adminParcari);
                        break;
                    case "N":
                        AdaugaParcare(adminParcari);
                        break;
                    case "O":
                        OcupaLoc(adminParcari);
                        break;
                    case "L":
                        ElibereazaLoc(adminParcari);
                        break;
                    case "X":
                        Console.WriteLine("Iesire...");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            } while (optiune.ToUpper() != "X");
        }

        static void AfiseazaParcari(AdministrareParcari_FisierText adminParcari)
        {
            int nrParcari;
            Parcare[] parcari = adminParcari.GetParcari(out nrParcari);
            Console.WriteLine("\n--- Starea actuala a parcarilor ---");
            for (int i = 0; i < nrParcari; i++)
            {
                Console.WriteLine(parcari[i].GetStatusParcare());
            }
        }

        static void AdaugaParcare(AdministrareParcari_FisierText adminParcari)
        {
            Console.Write("Introduceti numele parcarii: ");
            string numeParcare = Console.ReadLine();
            Console.Write($"Introduceti numarul de locuri pentru {numeParcare}: ");
            int numarLocuri = int.Parse(Console.ReadLine());

            Parcare parcareNoua = new Parcare(numeParcare, numarLocuri);
            adminParcari.AddParcare(parcareNoua);
            Console.WriteLine("Parcarea a fost adaugata si salvata in fisier.");
        }

        static void OcupaLoc(AdministrareParcari_FisierText adminParcari)
        {
            int nrParcari;
            Parcare[] parcari = adminParcari.GetParcari(out nrParcari);
            Console.Write("Introduceti numele parcarii: ");
            string numeParcare = Console.ReadLine();

            Parcare parcareSelectata = null;
            for (int i = 0; i < nrParcari; i++)
            {
                if (parcari[i].Nume.Equals(numeParcare, StringComparison.OrdinalIgnoreCase))
                {
                    parcareSelectata = parcari[i];
                    break;
                }
            }
            if (parcareSelectata != null)
            {
                Console.Write("Introduceti numarul locului de ocupat: ");
                int numarLoc = int.Parse(Console.ReadLine());
                parcareSelectata.OcupareLoc(numarLoc);
                adminParcari.UpdateParcari(parcari, nrParcari);
            }
            else
            {
                Console.WriteLine("Parcarea nu a fost gasita!");
            }
        }

        static void ElibereazaLoc(AdministrareParcari_FisierText adminParcari)
        {
            int nrParcari;
            Parcare[] parcari = adminParcari.GetParcari(out nrParcari);
            Console.Write("Introduceti numele parcarii: ");
            string numeParcare = Console.ReadLine();

            Parcare parcareSelectata = null;
            for (int i = 0; i < nrParcari; i++)
            {
                if (parcari[i].Nume.Equals(numeParcare, StringComparison.OrdinalIgnoreCase))
                {
                    parcareSelectata = parcari[i];
                    break;
                }
            }
            if (parcareSelectata != null)
            {
                Console.Write("Introduceti numarul locului de eliberat: ");
                int numarLoc = int.Parse(Console.ReadLine());
                parcareSelectata.EliberareLoc(numarLoc);
                adminParcari.UpdateParcari(parcari, nrParcari);
            }
            else
            {
                Console.WriteLine("Parcarea nu a fost gasita!");
            }
        }
    }
}
