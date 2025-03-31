using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace ParkingApp_UI_WindowsForms
{
    public partial class FormOcupaLoc : Form
    {
        private Parcare parcareSelectata;
        private AdministrareVehicule_FisierText adminVehicule;
        private AdministrareParcari_FisierText adminParcari;
        private readonly string numeFisierParcari = "parcari.txt";

        public FormOcupaLoc(Parcare parcare, AdministrareVehicule_FisierText adminVehicule)
        {
            InitializeComponent();
            this.parcareSelectata = parcare;
            this.adminVehicule = adminVehicule;
            this.adminParcari = new AdministrareParcari_FisierText(numeFisierParcari);

            // Initialize form
            lblNumeParcare.Text = parcareSelectata.Nume;

            // Populate combobox with free spots
            foreach (var loc in parcareSelectata.Locuri)
            {
                if (loc.Status.HasFlag(LocDeParcareStatus.Liber))
                {
                    string statusText = loc.GetDetailedStatus();
                    cmbLocuri.Items.Add(new KeyValuePair<int, string>(loc.Loc, $"Locul {loc.Loc} - {statusText}"));
                }
            }

            if (cmbLocuri.Items.Count > 0)
            {
                cmbLocuri.DisplayMember = "Value";
                cmbLocuri.ValueMember = "Key";
                cmbLocuri.SelectedIndex = 0;
            }

            // Populate vehicle types
            foreach (TipVehicul tip in Enum.GetValues(typeof(TipVehicul)))
            {
                cmbTipVehicul.Items.Add(tip);
            }
            cmbTipVehicul.SelectedIndex = 0;
        }

        private void btnOcupa_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtNumarInmatriculare.Text))
            {
                MessageBox.Show("Introduceți numărul de înmatriculare!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbLocuri.SelectedItem == null)
            {
                MessageBox.Show("Selectați un loc de parcare!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTipVehicul.SelectedItem == null)
            {
                MessageBox.Show("Selectați tipul vehiculului!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected data
            string numarInmatriculare = txtNumarInmatriculare.Text.Trim();
            int locSelectat = ((KeyValuePair<int, string>)cmbLocuri.SelectedItem).Key;
            TipVehicul tipVehicul = (TipVehicul)cmbTipVehicul.SelectedItem;

            // Check if vehicle is already registered
            Vehicul vehiculExistent = adminVehicule.FindVehiculByNumarInmatriculare(numarInmatriculare);
            if (vehiculExistent != null && vehiculExistent.OraIesire == null)
            {
                MessageBox.Show($"Vehiculul cu numărul {numarInmatriculare} este deja înregistrat în parcare!",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Process selected additional statuses
            LocDeParcareStatus statusSpecial = LocDeParcareStatus.None;

            if (chkPentruElectrice.Checked)
                statusSpecial |= LocDeParcareStatus.PentruElectrice;

            if (chkRezervat.Checked)
                statusSpecial |= LocDeParcareStatus.Rezervat;

            if (chkPentruDizabilitati.Checked)
                statusSpecial |= LocDeParcareStatus.PentruDizabilitati;

            if (chkVIP.Checked)
                statusSpecial |= LocDeParcareStatus.VIP;

            // Register the vehicle
            Vehicul vehiculNou = new Vehicul(numarInmatriculare, locSelectat, parcareSelectata.Nume, tipVehicul);
            adminVehicule.AddVehicul(vehiculNou);

            // Update the parking spot status
            parcareSelectata.Locuri[locSelectat - 1].Ocupare();

            // Apply additional statuses if selected
            if (statusSpecial != LocDeParcareStatus.None)
            {
                parcareSelectata.Locuri[locSelectat - 1].SetSpotStatus(statusSpecial, true);
            }

            // Save changes to the parking
            adminParcari.UpdateParcare(parcareSelectata);

            // Show confirmation
            MessageBox.Show($"Vehiculul cu numărul {numarInmatriculare} (Tip: {tipVehicul}) a fost înregistrat " +
                $"pe locul {locSelectat} în parcarea {parcareSelectata.Nume}.",
                "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbTipVehicul_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable electric vehicle checkbox only for electric vehicles
            if (cmbTipVehicul.SelectedItem != null && (TipVehicul)cmbTipVehicul.SelectedItem == TipVehicul.Electric)
            {
                chkPentruElectrice.Enabled = true;
                chkPentruElectrice.Checked = true;
            }
            else
            {
                chkPentruElectrice.Enabled = false;
                chkPentruElectrice.Checked = false;
            }
        }
    }
}