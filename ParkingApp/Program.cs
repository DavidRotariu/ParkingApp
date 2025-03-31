using System;
using NivelStocareDate;
using LibrarieModele;

namespace ParkingApp
{
    class Program
    {
        static void Main()
        {
            string numeFisierParcari = "parcari.txt";
            string numeFisierVehicule = "vehicule.txt";
            AdministrareParcari_FisierText adminParcari = new AdministrareParcari_FisierText(numeFisierParcari);
            AdministrareVehicule_FisierText adminVehicule = new AdministrareVehicule_FisierText(numeFisierVehicule);

            string optiune;
            do
            {
                Console.WriteLine("\nMeniu Administrare Parcari:");
                Console.WriteLine("A. Afiseaza toate parcarile din fisier");
                Console.WriteLine("N. Adauga o noua parcare");
                Console.WriteLine("O. Ocupa un loc de parcare");
                Console.WriteLine("L. Elibereaza un loc de parcare");
                Console.WriteLine("S. Statusuri speciale pentru locuri");
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
                        OcupaLocSiInregistreazaVehicul(adminParcari, adminVehicule);
                        break;
                    case "L":
                        ElibereazaLocSiInregistreazaIesire(adminParcari, adminVehicule);
                        break;
                    case "S":
                        ModificaStatusuriSpeciale(adminParcari);
                        break;
                    case "X":
                        Console.WriteLine("Iesire din aplicatie...");
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
            Console.Write($"Introduceti tariful pe ora pentru {numeParcare} (lei): ");
            decimal tarifOra = decimal.Parse(Console.ReadLine());

            Parcare parcareNoua = new Parcare(numeParcare, numarLocuri, tarifOra);
            adminParcari.AddParcare(parcareNoua);
            Console.WriteLine("Parcarea a fost adaugata si salvata in fisier.");
        }

        static void OcupaLocSiInregistreazaVehicul(AdministrareParcari_FisierText adminParcari, AdministrareVehicule_FisierText adminVehicule)
        {
            // Selectare parcare
            Console.Write("Introduceti numele parcarii: ");
            string numeParcare = Console.ReadLine();
            Parcare parcareSelectata = adminParcari.FindParcareByNume(numeParcare);

            if (parcareSelectata == null)
            {
                Console.WriteLine("Parcarea nu a fost gasita!");
                return;
            }

            // Verificare daca exista locuri libere
            bool existaLocLiber = false;
            foreach (var loc in parcareSelectata.Locuri)
            {
                if (loc.Status.HasFlag(LocDeParcareStatus.Liber))
                {
                    existaLocLiber = true;
                    break;
                }
            }

            if (!existaLocLiber)
            {
                Console.WriteLine($"Nu exista locuri libere in parcarea {numeParcare}!");
                return;
            }

            // Afisare locuri libere
            Console.WriteLine("\nLocuri libere disponibile:");
            foreach (var loc in parcareSelectata.Locuri)
            {
                if (loc.Status.HasFlag(LocDeParcareStatus.Liber))
                {
                    Console.WriteLine($"Locul {loc.Loc} - Status: {loc.GetDetailedStatus()}");
                }
            }

            // Selectare loc
            Console.Write("\nIntroduceti numarul locului de parcare: ");
            int numarLoc = int.Parse(Console.ReadLine());

            // Verificare validitate loc
            if (numarLoc < 1 || numarLoc > parcareSelectata.Locuri.Count)
            {
                Console.WriteLine("Numar de loc invalid!");
                return;
            }

            // Verificare daca locul este liber
            if (!parcareSelectata.Locuri[numarLoc - 1].Status.HasFlag(LocDeParcareStatus.Liber))
            {
                Console.WriteLine($"Locul {numarLoc} nu este liber! Status actual: {parcareSelectata.Locuri[numarLoc - 1].GetDetailedStatus()}");
                return;
            }

            // Introducere numar de inmatriculare
            Console.Write("Introduceti numarul de inmatriculare: ");
            string numarInmatriculare = Console.ReadLine();

            // Verificare daca vehiculul este deja inregistrat
            Vehicul vehiculExistent = adminVehicule.FindVehiculByNumarInmatriculare(numarInmatriculare);
            if (vehiculExistent != null && vehiculExistent.OraIesire == null)
            {
                Console.WriteLine($"Vehiculul cu numarul {numarInmatriculare} este deja inregistrat in parcare!");
                return;
            }

            // Selectare tip vehicul
            Console.WriteLine("\nSelectati tipul vehiculului:");
            Console.WriteLine("1. Autoturism");
            Console.WriteLine("2. Motocicleta");
            Console.WriteLine("3. Camion");
            Console.WriteLine("4. Duba");
            Console.WriteLine("5. Vehicul Electric");
            Console.Write("Introduceti optiunea (1-5): ");
            int optiuneTip = int.Parse(Console.ReadLine());

            TipVehicul tipVehicul;
            switch (optiuneTip)
            {
                case 1:
                    tipVehicul = TipVehicul.Autoturism;
                    break;
                case 2:
                    tipVehicul = TipVehicul.Motocicleta;
                    break;
                case 3:
                    tipVehicul = TipVehicul.Camion;
                    break;
                case 4:
                    tipVehicul = TipVehicul.Duba;
                    break;
                case 5:
                    tipVehicul = TipVehicul.Electric;
                    break;
                default:
                    tipVehicul = TipVehicul.Autoturism;
                    break;
            }

            // Verificare daca trebuie adaugate flag-uri speciale pentru locul de parcare
            LocDeParcareStatus statusSpecial = LocDeParcareStatus.None;
            if (tipVehicul == TipVehicul.Electric)
            {
                // Intreaba daca locul ar trebui marcat pentru vehicule electrice
                Console.Write("Doriti sa marcati acest loc pentru vehicule electrice? (D/N): ");
                if (Console.ReadLine().ToUpper() == "D")
                {
                    statusSpecial |= LocDeParcareStatus.PentruElectrice;
                }
            }

            // Intreaba daca locul ar trebui rezervat
            Console.Write("Doriti sa rezervati acest loc? (D/N): ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                statusSpecial |= LocDeParcareStatus.Rezervat;
            }

            // Creare si salvare vehicul
            Vehicul vehiculNou = new Vehicul(numarInmatriculare, numarLoc, numeParcare, tipVehicul);
            adminVehicule.AddVehicul(vehiculNou);

            // Marcare loc ca ocupat cu eventuale flag-uri suplimentare
            parcareSelectata.Locuri[numarLoc - 1].Ocupare();
            if (statusSpecial != LocDeParcareStatus.None)
            {
                parcareSelectata.Locuri[numarLoc - 1].SetSpotStatus(statusSpecial, true);
            }
            adminParcari.UpdateParcare(parcareSelectata);

            Console.WriteLine($"Vehiculul cu numarul {numarInmatriculare} (Tip: {tipVehicul}) a fost inregistrat pe locul {numarLoc} in parcarea {numeParcare}.");
            Console.WriteLine($"Ora de intrare: {vehiculNou.OraIntrare}");

            // Afiseaza statusul actualizat al locului
            Console.WriteLine($"Status actualizat al locului: {parcareSelectata.Locuri[numarLoc - 1].GetDetailedStatus()}");

            // Afiseaza costul estimat bazat pe tariful orar și tipul vehiculului
            Console.WriteLine($"Tarif pe ora: {parcareSelectata.TarifOra} lei");
            Console.WriteLine($"Tipul vehiculului poate influenta tariful: ");
            switch (tipVehicul)
            {
                case TipVehicul.Motocicleta:
                    Console.WriteLine("  - Motociclete beneficiază de 30% reducere");
                    break;
                case TipVehicul.Camion:
                    Console.WriteLine("  - Camioanele au un tarif majorat cu 50%");
                    break;
                case TipVehicul.Electric:
                    Console.WriteLine("  - Vehiculele electrice beneficiază de 20% reducere");
                    break;
            }
        }

        static void ElibereazaLocSiInregistreazaIesire(AdministrareParcari_FisierText adminParcari, AdministrareVehicule_FisierText adminVehicule)
        {
            // Selectare parcare
            Console.Write("Introduceti numele parcarii: ");
            string numeParcare = Console.ReadLine();
            Parcare parcareSelectata = adminParcari.FindParcareByNume(numeParcare);

            if (parcareSelectata == null)
            {
                Console.WriteLine("Parcarea nu a fost gasita!");
                return;
            }

            // Afișarea locurilor ocupate
            Console.WriteLine("\nLocuri ocupate în parcarea " + numeParcare + ":");
            bool existaLocuriOcupate = false;
            foreach (var loc in parcareSelectata.Locuri)
            {
                if (loc.Status.HasFlag(LocDeParcareStatus.Ocupat))
                {
                    Console.WriteLine($"Locul {loc.Loc} - Status: {loc.GetDetailedStatus()}");
                    existaLocuriOcupate = true;
                }
            }

            if (!existaLocuriOcupate)
            {
                Console.WriteLine("Nu există locuri ocupate în această parcare!");
                return;
            }

            // Selectare loc
            Console.Write("Introduceti numarul locului de eliberat: ");
            int numarLoc = int.Parse(Console.ReadLine());

            // Verificare validitate loc
            if (numarLoc < 1 || numarLoc > parcareSelectata.Locuri.Count)
            {
                Console.WriteLine("Numar de loc invalid!");
                return;
            }

            // Verificare daca locul este ocupat
            if (!parcareSelectata.Locuri[numarLoc - 1].Status.HasFlag(LocDeParcareStatus.Ocupat))
            {
                Console.WriteLine($"Locul {numarLoc} este deja liber!");
                return;
            }

            // Gasirea vehiculului parcat pe acest loc
            int nrVehicule;
            Vehicul[] vehicule = adminVehicule.FindVehiculeByLoc(numarLoc, numeParcare, out nrVehicule);

            if (nrVehicule == 0)
            {
                Console.WriteLine("Nu s-a gasit niciun vehicul inregistrat pe acest loc!");
                // Întreabă dacă să elibereze locul oricum
                Console.Write("Doriți să eliberați locul oricum? (D/N): ");
                if (Console.ReadLine().ToUpper() == "D")
                {
                    // Resetam toate statusurile speciale
                    parcareSelectata.Locuri[numarLoc - 1].SetSpotStatus(LocDeParcareStatus.Liber, true);
                    adminParcari.UpdateParcare(parcareSelectata);
                    Console.WriteLine($"Locul {numarLoc} a fost eliberat.");
                }
                return;
            }

            Vehicul vehicul = vehicule[0]; // Luam primul vehicul gasit pe acest loc

            // Inregistrare iesire vehicul
            vehicul.InregistrareIesire();
            adminVehicule.UpdateVehicul(vehicul);

            // Calculare cost
            TimeSpan durataParcare = vehicul.CalculareDurataParcare();
            decimal cost = vehicul.CalculareCost(parcareSelectata.TarifOra);

            // Întreabă dacă să păstreze statutul special
            bool pastreazaStatus = false;
            if (parcareSelectata.Locuri[numarLoc - 1].Status.HasFlag(LocDeParcareStatus.Rezervat) ||
                parcareSelectata.Locuri[numarLoc - 1].Status.HasFlag(LocDeParcareStatus.PentruElectrice) ||
                parcareSelectata.Locuri[numarLoc - 1].Status.HasFlag(LocDeParcareStatus.PentruDizabilitati) ||
                parcareSelectata.Locuri[numarLoc - 1].Status.HasFlag(LocDeParcareStatus.VIP))
            {
                Console.Write($"Locul are statusuri speciale: {parcareSelectata.Locuri[numarLoc - 1].GetDetailedStatus()}. Doriți să le păstrați? (D/N): ");
                pastreazaStatus = Console.ReadLine().ToUpper() == "D";
            }

            // Eliberare loc de parcare
            LocDeParcareStatus staturiSpeciale = parcareSelectata.Locuri[numarLoc - 1].Status &
                ~LocDeParcareStatus.Ocupat & ~LocDeParcareStatus.Liber;

            parcareSelectata.Locuri[numarLoc - 1].Eliberare();

            if (!pastreazaStatus)
            {
                // Resetam toate statusurile speciale folosind SetSpotStatus
                foreach (LocDeParcareStatus status in Enum.GetValues(typeof(LocDeParcareStatus)))
                {
                    if (status != LocDeParcareStatus.None && status != LocDeParcareStatus.Liber)
                    {
                        parcareSelectata.Locuri[numarLoc - 1].SetSpotStatus(status, false);
                    }
                }
                // Asigurăm că statusul Liber este setat
                parcareSelectata.Locuri[numarLoc - 1].SetSpotStatus(LocDeParcareStatus.Liber, true);
            }
            else if (staturiSpeciale != LocDeParcareStatus.None)
            {
                // Adăugăm înapoi statusurile speciale
                parcareSelectata.Locuri[numarLoc - 1].SetSpotStatus(staturiSpeciale, true);
            }

            adminParcari.UpdateParcare(parcareSelectata);

            Console.WriteLine($"\nVehiculul cu numarul {vehicul.NumarInmatriculare} (Tip: {vehicul.Tip}) a iesit din parcare.");
            Console.WriteLine($"Ora de intrare: {vehicul.OraIntrare}");
            Console.WriteLine($"Ora de iesire: {vehicul.OraIesire}");
            Console.WriteLine($"Durata parcarii: {Math.Floor(durataParcare.TotalHours)} ore si {durataParcare.Minutes} minute");
            Console.WriteLine($"Tarif pe ora: {parcareSelectata.TarifOra} lei");

            // Afișează detalii despre tariful aplicat în funcție de tipul vehiculului
            string explicatieTarif = "";
            switch (vehicul.Tip)
            {
                case TipVehicul.Motocicleta:
                    explicatieTarif = " (reducere 30% pentru motocicleta)";
                    break;
                case TipVehicul.Camion:
                    explicatieTarif = " (majorare 50% pentru camion)";
                    break;
                case TipVehicul.Electric:
                    explicatieTarif = " (reducere 20% pentru vehicul electric)";
                    break;
            }

            Console.WriteLine($"Cost total: {cost:F2} lei{explicatieTarif}");
            Console.WriteLine($"Status actualizat al locului: {parcareSelectata.Locuri[numarLoc - 1].GetDetailedStatus()}");
        }

        static void ModificaStatusuriSpeciale(AdministrareParcari_FisierText adminParcari)
        {
            // Selectare parcare
            Console.Write("Introduceti numele parcarii: ");
            string numeParcare = Console.ReadLine();
            Parcare parcareSelectata = adminParcari.FindParcareByNume(numeParcare);

            if (parcareSelectata == null)
            {
                Console.WriteLine("Parcarea nu a fost gasita!");
                return;
            }

            // Afisare toate locurile
            Console.WriteLine("\nToate locurile din parcarea " + numeParcare + ":");
            foreach (var loc in parcareSelectata.Locuri)
            {
                Console.WriteLine($"Locul {loc.Loc} - Status: {loc.GetDetailedStatus()}");
            }

            // Selectare loc
            Console.Write("\nIntroduceti numarul locului pentru a modifica statusurile: ");
            int numarLoc = int.Parse(Console.ReadLine());

            // Verificare validitate loc
            if (numarLoc < 1 || numarLoc > parcareSelectata.Locuri.Count)
            {
                Console.WriteLine("Numar de loc invalid!");
                return;
            }

            LocDeParcare locSelectat = parcareSelectata.Locuri[numarLoc - 1];
            Console.WriteLine($"Status actual al locului {numarLoc}: {locSelectat.GetDetailedStatus()}");

            // Meniu pentru modificare statusuri
            bool continuaModificari = true;
            while (continuaModificari)
            {
                Console.WriteLine("\nOpțiuni pentru modificarea statusurilor:");
                Console.WriteLine("1. Activare/Dezactivare status Rezervat");
                Console.WriteLine("2. Activare/Dezactivare status Pentru persoane cu dizabilități");
                Console.WriteLine("3. Activare/Dezactivare status În mentenanță");
                Console.WriteLine("4. Activare/Dezactivare status Pentru vehicule electrice");
                Console.WriteLine("5. Activare/Dezactivare status VIP");
                Console.WriteLine("6. Activare/Dezactivare status Temporar");
                Console.WriteLine("7. Resetează toate statusurile (setează ca Liber sau Ocupat)");
                Console.WriteLine("0. Înapoi la meniul principal");
                Console.Write("Selectați o opțiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        ToggleStatus(locSelectat, LocDeParcareStatus.Rezervat);
                        break;
                    case "2":
                        ToggleStatus(locSelectat, LocDeParcareStatus.PentruDizabilitati);
                        break;
                    case "3":
                        ToggleStatus(locSelectat, LocDeParcareStatus.InMentenanta);
                        break;
                    case "4":
                        ToggleStatus(locSelectat, LocDeParcareStatus.PentruElectrice);
                        break;
                    case "5":
                        ToggleStatus(locSelectat, LocDeParcareStatus.VIP);
                        break;
                    case "6":
                        ToggleStatus(locSelectat, LocDeParcareStatus.Temporar);
                        break;
                    case "7":
                        ResetToBaseStatus(locSelectat);
                        break;
                    case "0":
                        continuaModificari = false;
                        break;
                    default:
                        Console.WriteLine("Opțiune invalidă!");
                        break;
                }

                if (continuaModificari)
                {
                    Console.WriteLine($"Status actualizat al locului {numarLoc}: {locSelectat.GetDetailedStatus()}");
                }
            }

            // Actualizează parcarea în fișier
            adminParcari.UpdateParcare(parcareSelectata);
            Console.WriteLine("Statusurile au fost actualizate și salvate.");
        }

        private static void ToggleStatus(LocDeParcare loc, LocDeParcareStatus status)
        {
            bool hasStatus = loc.Status.HasFlag(status);
            Console.WriteLine($"Status {status} este: {(hasStatus ? "Activ" : "Inactiv")}");
            Console.Write($"Doriți să {(hasStatus ? "dezactivați" : "activați")} acest status? (D/N): ");

            if (Console.ReadLine().ToUpper() == "D")
            {
                loc.SetSpotStatus(status, !hasStatus);
                Console.WriteLine($"Status {status} a fost {(hasStatus ? "dezactivat" : "activat")}.");
            }
        }

        private static void ResetToBaseStatus(LocDeParcare loc)
        {
            Console.Write("Doriți să resetați toate statusurile? (D/N): ");
            if (Console.ReadLine().ToUpper() == "D")
            {
                // Păstrează doar statusurile de bază
                bool esteOcupat = loc.Status.HasFlag(LocDeParcareStatus.Ocupat);
                // Folosim SetSpotStatus pentru a reseta statusul
                // Mai întâi setăm toate statusurile la None
                foreach (LocDeParcareStatus status in Enum.GetValues(typeof(LocDeParcareStatus)))
                {
                    if (status != LocDeParcareStatus.None)
                    {
                        loc.SetSpotStatus(status, false);
                    }
                }
                // Apoi setăm statusul de bază (Liber sau Ocupat)
                loc.SetSpotStatus(esteOcupat ? LocDeParcareStatus.Ocupat : LocDeParcareStatus.Liber, true);
                Console.WriteLine("Toate statusurile au fost resetate.");
            }
        }
    }
}