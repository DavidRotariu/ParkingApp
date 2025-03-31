using System;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace ParkingApp_UI_WindowsForms
{
    public partial class FormStatusSpecial : Form
    {
        private Parcare parcareSelectata;
        private AdministrareParcari_FisierText adminParcari;
        private LocDeParcare locSelectat;

        public FormStatusSpecial(Parcare parcare, AdministrareParcari_FisierText adminParcari)
        {
            InitializeComponent();
            this.parcareSelectata = parcare;
            this.adminParcari = adminParcari;

            // Initialize form
            lblNumeParcare.Text = parcareSelectata.Nume;

            // Populate combobox with all spots
            foreach (var loc in parcareSelectata.Locuri)
            {
                cmbLocuri.Items.Add(new Tuple<int, string>(
                    loc.Loc,
                    $"Locul {loc.Loc} - {loc.GetDetailedStatus()}"));
            }

            if (cmbLocuri.Items.Count > 0)
            {
                cmbLocuri.DisplayMember = "Item2";
                cmbLocuri.ValueMember = "Item1";
                cmbLocuri.SelectedIndex = 0;
            }
        }

        private void cmbLocuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocuri.SelectedItem != null)
            {
                int locId = ((Tuple<int, string>)cmbLocuri.SelectedItem).Item1;
                locSelectat = parcareSelectata.Locuri[locId - 1];

                // Update checkboxes to reflect current status
                chkRezervat.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.Rezervat);
                chkPentruDizabilitati.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.PentruDizabilitati);
                chkInMentenanta.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.InMentenanta);
                chkPentruElectrice.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.PentruElectrice);
                chkVIP.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.VIP);
                chkTemporar.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.Temporar);

                // If the spot is in maintenance, it shouldn't be marked as occupied
                if (locSelectat.Status.HasFlag(LocDeParcareStatus.InMentenanta))
                {
                    chkOcupat.Enabled = false;
                }
                else
                {
                    chkOcupat.Enabled = true;
                }

                // Update occupied/free status
                chkOcupat.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.Ocupat);
                chkLiber.Checked = locSelectat.Status.HasFlag(LocDeParcareStatus.Liber);

                // Update label with current statuses
                lblStatusCurent.Text = $"Status curent: {locSelectat.GetDetailedStatus()}";
            }
        }

        private void chkOcupat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcupat.Checked)
            {
                chkLiber.Checked = false;
            }
            else if (!chkLiber.Checked)
            {
                chkLiber.Checked = true;
            }
        }

        private void chkLiber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLiber.Checked)
            {
                chkOcupat.Checked = false;
            }
            else if (!chkOcupat.Checked)
            {
                chkOcupat.Checked = true;
            }
        }

        private void chkInMentenanta_CheckedChanged(object sender, EventArgs e)
        {
            // If maintenance is checked, disable the occupied checkbox
            if (chkInMentenanta.Checked)
            {
                chkOcupat.Enabled = false;
                chkOcupat.Checked = false;
                chkLiber.Checked = true;
            }
            else
            {
                chkOcupat.Enabled = true;
            }
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (locSelectat == null)
            {
                MessageBox.Show("Selectați un loc de parcare!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Reset all statuses first
            foreach (LocDeParcareStatus status in Enum.GetValues(typeof(LocDeParcareStatus)))
            {
                if (status != LocDeParcareStatus.None)
                {
                    locSelectat.SetSpotStatus(status, false);
                }
            }

            // Set base status (occupied or free)
            if (chkOcupat.Checked)
            {
                locSelectat.SetSpotStatus(LocDeParcareStatus.Ocupat, true);
            }
            else
            {
                locSelectat.SetSpotStatus(LocDeParcareStatus.Liber, true);
            }

            // Set special statuses
            if (chkRezervat.Checked)
                locSelectat.SetSpotStatus(LocDeParcareStatus.Rezervat, true);

            if (chkPentruDizabilitati.Checked)
                locSelectat.SetSpotStatus(LocDeParcareStatus.PentruDizabilitati, true);

            if (chkInMentenanta.Checked)
                locSelectat.SetSpotStatus(LocDeParcareStatus.InMentenanta, true);

            if (chkPentruElectrice.Checked)
                locSelectat.SetSpotStatus(LocDeParcareStatus.PentruElectrice, true);

            if (chkVIP.Checked)
                locSelectat.SetSpotStatus(LocDeParcareStatus.VIP, true);

            if (chkTemporar.Checked)
                locSelectat.SetSpotStatus(LocDeParcareStatus.Temporar, true);

            // Save changes to the parking
            adminParcari.UpdateParcare(parcareSelectata);

            // Show confirmation
            MessageBox.Show($"Statusurile pentru locul {locSelectat.Loc} au fost actualizate cu succes.",
                "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnReseteaza_Click(object sender, EventArgs e)
        {
            if (locSelectat == null)
            {
                MessageBox.Show("Selectați un loc de parcare!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                $"Doriți să resetați toate statusurile locului {locSelectat.Loc} și să-l marcați ca liber?",
                "Confirmare resetare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Reset all statuses
                foreach (LocDeParcareStatus status in Enum.GetValues(typeof(LocDeParcareStatus)))
                {
                    if (status != LocDeParcareStatus.None && status != LocDeParcareStatus.Liber)
                    {
                        locSelectat.SetSpotStatus(status, false);
                    }
                }

                // Set as free
                locSelectat.SetSpotStatus(LocDeParcareStatus.Liber, true);

                // Update UI
                chkRezervat.Checked = false;
                chkPentruDizabilitati.Checked = false;
                chkInMentenanta.Checked = false;
                chkPentruElectrice.Checked = false;
                chkVIP.Checked = false;
                chkTemporar.Checked = false;
                chkOcupat.Checked = false;
                chkLiber.Checked = true;

                // Update label
                lblStatusCurent.Text = $"Status curent: {locSelectat.GetDetailedStatus()}";

                // Update the combo box display
                cmbLocuri.Items[cmbLocuri.SelectedIndex] = new Tuple<int, string>(
                    locSelectat.Loc,
                    $"Locul {locSelectat.Loc} - {locSelectat.GetDetailedStatus()}");
            }
        }
    }
}