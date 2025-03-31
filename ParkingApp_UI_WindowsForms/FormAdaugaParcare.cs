using System;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace ParkingApp_UI_WindowsForms
{
    public partial class FormAdaugaParcare : Form
    {
        private readonly string numeFisierParcari = "parcari.txt";
        private AdministrareParcari_FisierText adminParcari;

        public FormAdaugaParcare()
        {
            InitializeComponent();
            adminParcari = new AdministrareParcari_FisierText(numeFisierParcari);
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtNumeParcare.Text))
            {
                MessageBox.Show("Introduceți numele parcării!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtNumarLocuri.Text, out int numarLocuri) || numarLocuri <= 0)
            {
                MessageBox.Show("Numărul de locuri trebuie să fie un număr pozitiv!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtTarifOra.Text, out decimal tarifOra) || tarifOra <= 0)
            {
                MessageBox.Show("Tariful pe oră trebuie să fie un număr pozitiv!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if parking with the same name already exists
            Parcare existingParcare = adminParcari.FindParcareByNume(txtNumeParcare.Text);
            if (existingParcare != null)
            {
                MessageBox.Show($"O parcare cu numele '{txtNumeParcare.Text}' există deja!", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create and save the new parking
            Parcare parcareNoua = new Parcare(txtNumeParcare.Text, numarLocuri, tarifOra);
            adminParcari.AddParcare(parcareNoua);

            MessageBox.Show($"Parcarea '{txtNumeParcare.Text}' a fost adăugată cu succes!", "Succes",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}