using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace ParkingApp_UI_WindowsForms
{
    public partial class FormElibereazaLoc : Form
    {
        private Parcare parcareSelectata;
        private AdministrareVehicule_FisierText adminVehicule;
        private AdministrareParcari_FisierText adminParcari;

        public FormElibereazaLoc(Parcare parcare, AdministrareVehicule_FisierText adminVehicule, AdministrareParcari_FisierText adminParcari)
        {
            InitializeComponent();
            this.parcareSelectata = parcare;
            this.adminVehicule = adminVehicule;
            this.adminParcari = adminParcari;

            // Initialize form
            lblNumeParcare.Text = parcareSelectata.Nume;

            // Populate combobox with occupied spots
            foreach (var loc in parcareSelectata.Locuri)
            {
                if (loc.Status.HasFlag(LocDeParcareStatus.Ocupat))
                {
                    // Find vehicles for this spot
                    int nrVehicule;
                    Vehicul[] vehicule = adminVehicule.FindVehiculeByLoc(loc.Loc, parcareSelectata.Nume, out nrVehicule);

                    string vehiculInfo = "";
                    if (nrVehicule > 0)
                    {
                        vehiculInfo = $" - {vehicule[0].NumarInmatriculare} ({vehicule[0].Tip})";
                    }

                    cmbLocuri.Items.Add(new KeyValuePair<int, string>(
                        loc.Loc,
                        $"Locul {loc.Loc}{vehiculInfo} - {loc.GetDetailedStatus()}"));
                }
            }

            if (cmbLocuri.Items.Count > 0)
            {
                cmbLocuri.DisplayMember = "Value";
                cmbLocuri.ValueMember = "Key";
                cmbLocuri.SelectedIndex = 0;
            }
        }

        private void btnElibereaza_Click(object sender, EventArgs e)
        {
            if (cmbLocuri.SelectedItem == null)
            {
                MessageBox.Show("Selectați un loc de parcare!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected location
            int locSelectat = ((KeyValuePair<int, string>)cmbLocuri.SelectedItem).Key;

            // Find vehicle for this spot
            int nrVehicule;
            Vehicul[] vehicule = adminVehicule.FindVehiculeByLoc(locSelectat, parcareSelectata.Nume, out nrVehicule);

            // Variables to store cost information
            decimal cost = 0;
            TimeSpan durataParcare = TimeSpan.Zero;

            if (nrVehicule > 0)
            {
                // Register vehicle exit
                Vehicul vehicul = vehicule[0];
                vehicul.InregistrareIesire();
                adminVehicule.UpdateVehicul(vehicul);

                // Calculate cost
                durataParcare = vehicul.CalculareDurataParcare();
                cost = vehicul.CalculareCost(parcareSelectata.TarifOra);
            }
            else
            {
                // No vehicle found, just free the spot
                MessageBox.Show("Nu s-a găsit niciun vehicul înregistrat pe acest loc. Locul va fi eliberat.",
                    "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Check if we want to preserve special statuses
            bool pastreazaStatus = chkPastreazaStatus.Checked;

            // Get current special statuses
            LocDeParcareStatus staturiSpeciale = parcareSelectata.Locuri[locSelectat - 1].Status &
                ~LocDeParcareStatus.Ocupat & ~LocDeParcareStatus.Liber;

            // Free the parking spot
            parcareSelectata.Locuri[locSelectat - 1].Eliberare();

            if (!pastreazaStatus)
            {
                // Reset all special statuses
                foreach (LocDeParcareStatus status in Enum.GetValues(typeof(LocDeParcareStatus)))
                {
                    if (status != LocDeParcareStatus.None && status != LocDeParcareStatus.Liber)
                    {
                        parcareSelectata.Locuri[locSelectat - 1].SetSpotStatus(status, false);
                    }
                }
                // Make sure Liber status is set
                parcareSelectata.Locuri[locSelectat - 1].SetSpotStatus(LocDeParcareStatus.Liber, true);
            }
            else if (staturiSpeciale != LocDeParcareStatus.None)
            {
                // Re-apply special statuses
                parcareSelectata.Locuri[locSelectat - 1].SetSpotStatus(staturiSpeciale, true);
            }

            // Save changes to the parking
            adminParcari.UpdateParcare(parcareSelectata);

            // Show confirmation with cost if a vehicle was found
            if (nrVehicule > 0)
            {
                Vehicul vehicul = vehicule[0];

                // Build message with formatted values
                string explicatieTarif = "";
                switch (vehicul.Tip)
                {
                    case TipVehicul.Motocicleta:
                        explicatieTarif = " (reducere 30% pentru motocicletă)";
                        break;
                    case TipVehicul.Camion:
                        explicatieTarif = " (majorare 50% pentru camion)";
                        break;
                    case TipVehicul.Electric:
                        explicatieTarif = " (reducere 20% pentru vehicul electric)";
                        break;
                }

                string mesaj = $"Vehiculul cu numărul {vehicul.NumarInmatriculare} (Tip: {vehicul.Tip}) a ieșit din parcare.\n\n" +
                    $"Ora de intrare: {vehicul.OraIntrare}\n" +
                    $"Ora de ieșire: {vehicul.OraIesire}\n" +
                    $"Durata parcării: {Math.Floor(durataParcare.TotalHours)} ore și {durataParcare.Minutes} minute\n" +
                    $"Tarif pe oră: {parcareSelectata.TarifOra} lei\n" +
                    $"Cost total: {cost:F2} lei{explicatieTarif}";

                MessageBox.Show(mesaj, "Ieșire vehicul", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Locul {locSelectat} a fost eliberat.",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbLocuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocuri.SelectedItem != null)
            {
                int locSelectat = ((KeyValuePair<int, string>)cmbLocuri.SelectedItem).Key;

                // Check for special statuses
                LocDeParcareStatus staturiSpeciale = parcareSelectata.Locuri[locSelectat - 1].Status &
                    ~LocDeParcareStatus.Ocupat & ~LocDeParcareStatus.Liber;

                // Enable "Keep statuses" checkbox only if there are special statuses
                chkPastreazaStatus.Enabled = staturiSpeciale != LocDeParcareStatus.None;

                if (staturiSpeciale != LocDeParcareStatus.None)
                {
                    chkPastreazaStatus.Text = $"Păstrează statusurile speciale: {parcareSelectata.Locuri[locSelectat - 1].GetDetailedStatus().Replace("Ocupat, ", "")}";
                }
                else
                {
                    chkPastreazaStatus.Text = "Păstrează statusurile speciale";
                }
            }
        }
    }
}