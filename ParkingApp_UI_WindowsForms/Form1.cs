using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace ParkingApp_UI_WindowsForms
{
    public partial class Form1 : Form
    {
        // File paths for storage
        private readonly string numeFisierParcari = "parcari.txt";
        private readonly string numeFisierVehicule = "vehicule.txt";

        // Data storage administrators
        private AdministrareParcari_FisierText adminParcari;
        private AdministrareVehicule_FisierText adminVehicule;

        // Currently selected parking
        private Parcare parcareSelectata;
        private Dictionary<int, Button> butonLocuri;

        public Form1()
        {
            InitializeComponent();

            // Initialize data administrators
            adminParcari = new AdministrareParcari_FisierText(numeFisierParcari);
            adminVehicule = new AdministrareVehicule_FisierText(numeFisierVehicule);

            // Initialize the dictionary for parking spot buttons
            butonLocuri = new Dictionary<int, Button>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load data on form load
            IncarcaParcari();
            IncarcaVehicule();
        }

        #region Parking List Methods

        private void IncarcaParcari()
        {
            // Clear existing items
            lvParcari.Items.Clear();

            // Get parking lots from file
            int nrParcari;
            Parcare[] parcari = adminParcari.GetParcari(out nrParcari);

            // Add each parking to the list
            for (int i = 0; i < nrParcari; i++)
            {
                Parcare parcare = parcari[i];

                // Count occupied and free spots
                int ocupate = 0;
                int libere = 0;

                foreach (var loc in parcare.Locuri)
                {
                    if (loc.Status.HasFlag(LocDeParcareStatus.Ocupat))
                        ocupate++;
                    else if (loc.Status.HasFlag(LocDeParcareStatus.Liber))
                        libere++;
                }

                // Create list item
                ListViewItem lvi = new ListViewItem(parcare.Nume);
                lvi.SubItems.Add(parcare.Locuri.Count.ToString());
                lvi.SubItems.Add(ocupate.ToString());
                lvi.SubItems.Add(libere.ToString());
                lvi.SubItems.Add(parcare.TarifOra.ToString("F2"));
                lvi.Tag = parcare; // Store the parking object

                lvParcari.Items.Add(lvi);
            }
        }

        private void btnActualizareParcari_Click(object sender, EventArgs e)
        {
            IncarcaParcari();

            // If a parking was selected, refresh its details
            if (parcareSelectata != null)
            {
                // Try to find the previously selected parking
                parcareSelectata = adminParcari.FindParcareByNume(parcareSelectata.Nume);
                if (parcareSelectata != null)
                {
                    AfiseazaDetaliiParcare(parcareSelectata);
                }
                else
                {
                    // Clear details if the parking wasn't found
                    ClearDetaliiParcare();
                }
            }
        }

        private void btnAdaugaParcare_Click(object sender, EventArgs e)
        {
            // We'll implement a dialog to add a new parking
            using (var formAdaugaParcare = new FormAdaugaParcare())
            {
                if (formAdaugaParcare.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the list to show the new parking
                    IncarcaParcari();
                }
            }
        }

        private void lvParcari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvParcari.SelectedItems.Count > 0)
            {
                // Get the selected parking from the Tag property
                parcareSelectata = (Parcare)lvParcari.SelectedItems[0].Tag;

                // Display the parking details
                AfiseazaDetaliiParcare(parcareSelectata);
            }
            else
            {
                ClearDetaliiParcare();
            }
        }

        #endregion

        #region Parking Details Methods

        private void AfiseazaDetaliiParcare(Parcare parcare)
        {
            // Update the selected parking (may have changed since loaded)
            parcareSelectata = adminParcari.FindParcareByNume(parcare.Nume);

            if (parcareSelectata == null)
            {
                ClearDetaliiParcare();
                return;
            }

            // Update the header with parking name and tariff
            lblNumeParcare.Text = $"{parcareSelectata.Nume} (Tarif: {parcareSelectata.TarifOra} lei/oră)";

            // Clear existing buttons
            flpLocuriParcare.Controls.Clear();
            butonLocuri.Clear();

            // Create buttons for each parking spot
            foreach (var loc in parcareSelectata.Locuri)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Margin = new Padding(5);
                btn.Text = loc.Loc.ToString();
                btn.Tag = loc;

                // Set button appearance based on spot status
                UpdateButtonAppearance(btn, loc);

                // Add click event
                btn.Click += (s, args) => LocParcare_Click(s, args, loc);

                // Add to flow layout
                flpLocuriParcare.Controls.Add(btn);

                // Add to dictionary for easy access
                butonLocuri[loc.Loc] = btn;
            }
        }

        private void UpdateButtonAppearance(Button btn, LocDeParcare loc)
        {
            // Reset button appearance
            btn.Text = loc.Loc.ToString();
            btn.ForeColor = Color.Black;

            // Apply status-based colors
            if (loc.Status.HasFlag(LocDeParcareStatus.Ocupat))
            {
                btn.BackColor = Color.IndianRed;
                btn.Text += "\nOcupat";
            }
            else if (loc.Status.HasFlag(LocDeParcareStatus.Liber))
            {
                btn.BackColor = Color.LightGreen;
                btn.Text += "\nLiber";
            }

            // Add icons or indicators for special statuses
            string additionalStatus = "";

            if (loc.Status.HasFlag(LocDeParcareStatus.Rezervat))
                additionalStatus += "R";

            if (loc.Status.HasFlag(LocDeParcareStatus.PentruDizabilitati))
                additionalStatus += "D";

            if (loc.Status.HasFlag(LocDeParcareStatus.InMentenanta))
            {
                additionalStatus += "M";
                btn.BackColor = Color.LightGray;
            }

            if (loc.Status.HasFlag(LocDeParcareStatus.PentruElectrice))
                additionalStatus += "E";

            if (loc.Status.HasFlag(LocDeParcareStatus.VIP))
                additionalStatus += "V";

            if (loc.Status.HasFlag(LocDeParcareStatus.Temporar))
                additionalStatus += "T";

            if (!string.IsNullOrEmpty(additionalStatus))
                btn.Text += $"\n[{additionalStatus}]";
        }

        private void ClearDetaliiParcare()
        {
            lblNumeParcare.Text = "Selectați o parcare";
            flpLocuriParcare.Controls.Clear();
            butonLocuri.Clear();
            parcareSelectata = null;
        }

        private void LocParcare_Click(object sender, EventArgs e, LocDeParcare loc)
        {
            // Show dialog with spot details and action options
            MessageBox.Show($"Locul {loc.Loc}\nStatus: {loc.GetDetailedStatus()}",
                "Detalii loc parcare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Parking Actions

        private void btnOcupaLoc_Click(object sender, EventArgs e)
        {
            if (parcareSelectata == null)
            {
                MessageBox.Show("Selectați mai întâi o parcare!", "Atenție",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if there are free spots
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
                MessageBox.Show($"Nu există locuri libere în parcarea {parcareSelectata.Nume}!",
                    "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // We'll implement a dialog to occupy a spot
            using (var formOcupaLoc = new FormOcupaLoc(parcareSelectata, adminVehicule))
            {
                if (formOcupaLoc.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the parking details to show the occupied spot
                    AfiseazaDetaliiParcare(parcareSelectata);
                    // Also refresh the vehicle list if that tab is visible
                    if (tabControl.SelectedTab == tabVehicule)
                    {
                        IncarcaVehicule();
                    }
                }
            }
        }

        private void btnElibereazaLoc_Click(object sender, EventArgs e)
        {
            if (parcareSelectata == null)
            {
                MessageBox.Show("Selectați mai întâi o parcare!", "Atenție",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if there are occupied spots
            bool existaLocOcupat = false;
            foreach (var loc in parcareSelectata.Locuri)
            {
                if (loc.Status.HasFlag(LocDeParcareStatus.Ocupat))
                {
                    existaLocOcupat = true;
                    break;
                }
            }

            if (!existaLocOcupat)
            {
                MessageBox.Show($"Nu există locuri ocupate în parcarea {parcareSelectata.Nume}!",
                    "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // We'll implement a dialog to free a spot
            using (var formElibereazaLoc = new FormElibereazaLoc(parcareSelectata, adminVehicule, adminParcari))
            {
                if (formElibereazaLoc.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the parking details to show the freed spot
                    AfiseazaDetaliiParcare(parcareSelectata);
                    // Also refresh the vehicle list if that tab is visible
                    if (tabControl.SelectedTab == tabVehicule)
                    {
                        IncarcaVehicule();
                    }
                }
            }
        }

        private void btnStatusSpecial_Click(object sender, EventArgs e)
        {
            if (parcareSelectata == null)
            {
                MessageBox.Show("Selectați mai întâi o parcare!", "Atenție",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // We'll implement a dialog to modify special statuses
            using (var formStatusSpecial = new FormStatusSpecial(parcareSelectata, adminParcari))
            {
                if (formStatusSpecial.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the parking details to show the updated statuses
                    AfiseazaDetaliiParcare(parcareSelectata);
                }
            }
        }

        #endregion

        #region Vehicle List Methods

        private void IncarcaVehicule()
        {
            // Clear existing items
            lvVehicule.Items.Clear();

            // Get vehicles from file
            int nrVehicule;
            Vehicul[] vehicule = adminVehicule.GetVehicule(out nrVehicule);

            // Add each vehicle to the list
            for (int i = 0; i < nrVehicule; i++)
            {
                Vehicul vehicul = vehicule[i];

                ListViewItem lvi = new ListViewItem(vehicul.NumarInmatriculare);
                lvi.SubItems.Add(vehicul.Tip.ToString());
                lvi.SubItems.Add(vehicul.OraIntrare.ToString());
                lvi.SubItems.Add(vehicul.OraIesire.HasValue ? vehicul.OraIesire.Value.ToString() : "Încă parcat");
                lvi.SubItems.Add(vehicul.LocOcupat.ToString());
                lvi.SubItems.Add(vehicul.ParcareNume);
                lvi.Tag = vehicul;

                // Highlight currently parked vehicles
                if (!vehicul.OraIesire.HasValue)
                {
                    lvi.BackColor = Color.LightGreen;
                }

                lvVehicule.Items.Add(lvi);
            }
        }

        private void btnActualizareVehicule_Click(object sender, EventArgs e)
        {
            IncarcaVehicule();
        }

        #endregion
    }
}