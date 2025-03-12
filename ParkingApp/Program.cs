using System;
using System.Collections.Generic;

namespace ParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Parcare> parcari = new List<Parcare>();

            // Read data from keyboard
            Console.Write("Introduceti numarul de parcari: ");
            int numarParcari = int.Parse(Console.ReadLine());

            for (int i = 0; i < numarParcari; i++)
            {
                Console.Write($"Introduceti numele parcarii {i + 1}: ");
                string numeParcare = Console.ReadLine();

                Console.Write($"Introduceti numarul de locuri pentru {numeParcare}: ");
                int numarLocuri = int.Parse(Console.ReadLine());

                parcari.Add(new Parcare(numeParcare, numarLocuri));
            }

            while (true)
            {
                Console.WriteLine("\nMeniu:");
                Console.WriteLine("1. Afiseaza toate parcarile");
                Console.WriteLine("2. Ocupa un loc de parcare");
                Console.WriteLine("3. Elibereaza un loc de parcare");
                Console.WriteLine("4. Iesire");
                Console.Write("Alege o optiune: ");

                int optiune = int.Parse(Console.ReadLine());

                if (optiune == 4)
                    break;

                switch (optiune)
                {
                    case 1:
                        Console.WriteLine("\n--- Starea actuala a parcarilor ---");
                        foreach (var parcare in parcari)
                        {
                            Console.WriteLine(parcare.GetStatusParcare());
                        }
                        break;

                    case 2:
                        Console.Write("Introduceti numele parcarii: ");
                        string numeParcareOcupare = Console.ReadLine();

                        // cautare dupa nume
                        Parcare parcareSelectataOcupare = parcari.Find(p => p.Nume == numeParcareOcupare);

                        if (parcareSelectataOcupare != null)
                        {
                            Console.Write("Introduceti numarul locului de ocupat: ");
                            int locOcupare = int.Parse(Console.ReadLine());
                            parcareSelectataOcupare.OcupareLoc(locOcupare);
                        }
                        else
                        {
                            Console.WriteLine("Parcarea nu a fost gasita!");
                        }
                        break;

                    case 3:
                        Console.Write("Introduceti numele parcarii: ");
                        string numeParcareEliberare = Console.ReadLine();

                        // cautare dupa nume

                        Parcare parcareSelectataEliberare = parcari.Find(p => p.Nume == numeParcareEliberare);

                        if (parcareSelectataEliberare != null)
                        {
                            Console.Write("Introduceti numarul locului de eliberat: ");
                            int locEliberare = int.Parse(Console.ReadLine());
                            parcareSelectataEliberare.EliberareLoc(locEliberare);
                        }
                        else
                        {
                            Console.WriteLine("Parcarea nu a fost gasita!");
                        }
                        break;

                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
        }
    }
}
