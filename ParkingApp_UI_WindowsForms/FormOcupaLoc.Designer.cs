namespace ParkingApp_UI_WindowsForms
{
    partial class FormOcupaLoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitlu = new System.Windows.Forms.Label();
            this.lblParcareSelectata = new System.Windows.Forms.Label();
            this.lblNumeParcare = new System.Windows.Forms.Label();
            this.lblSelectareLoc = new System.Windows.Forms.Label();
            this.cmbLocuri = new System.Windows.Forms.ComboBox();
            this.lblNumarInmatriculare = new System.Windows.Forms.Label();
            this.txtNumarInmatriculare = new System.Windows.Forms.TextBox();
            this.lblTipVehicul = new System.Windows.Forms.Label();
            this.cmbTipVehicul = new System.Windows.Forms.ComboBox();
            this.grpStatusuriSpeciale = new System.Windows.Forms.GroupBox();
            this.chkRezervat = new System.Windows.Forms.CheckBox();
            this.chkPentruElectrice = new System.Windows.Forms.CheckBox();
            this.chkPentruDizabilitati = new System.Windows.Forms.CheckBox();
            this.chkVIP = new System.Windows.Forms.CheckBox();
            this.btnOcupa = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.grpStatusuriSpeciale.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(12, 9);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(164, 20);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Ocupare loc parcare";
            // 
            // lblParcareSelectata
            // 
            this.lblParcareSelectata.AutoSize = true;
            this.lblParcareSelectata.Location = new System.Drawing.Point(13, 43);
            this.lblParcareSelectata.Name = "lblParcareSelectata";
            this.lblParcareSelectata.Size = new System.Drawing.Size(103, 13);
            this.lblParcareSelectata.TabIndex = 1;
            this.lblParcareSelectata.Text = "Parcare selectată:";
            // 
            // lblNumeParcare
            // 
            this.lblNumeParcare.AutoSize = true;
            this.lblNumeParcare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeParcare.Location = new System.Drawing.Point(122, 43);
            this.lblNumeParcare.Name = "lblNumeParcare";
            this.lblNumeParcare.Size = new System.Drawing.Size(100, 15);
            this.lblNumeParcare.TabIndex = 2;
            this.lblNumeParcare.Text = "[NumeParcare]";
            // 
            // lblSelectareLoc
            // 
            this.lblSelectareLoc.AutoSize = true;
            this.lblSelectareLoc.Location = new System.Drawing.Point(13, 75);
            this.lblSelectareLoc.Name = "lblSelectareLoc";
            this.lblSelectareLoc.Size = new System.Drawing.Size(126, 13);
            this.lblSelectareLoc.TabIndex = 3;
            this.lblSelectareLoc.Text = "Selectați locul de parcare:";
            // 
            // cmbLocuri
            // 
            this.cmbLocuri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocuri.FormattingEnabled = true;
            this.cmbLocuri.Location = new System.Drawing.Point(16, 91);
            this.cmbLocuri.Name = "cmbLocuri";
            this.cmbLocuri.Size = new System.Drawing.Size(356, 21);
            this.cmbLocuri.TabIndex = 4;
            // 
            // lblNumarInmatriculare
            // 
            this.lblNumarInmatriculare.AutoSize = true;
            this.lblNumarInmatriculare.Location = new System.Drawing.Point(13, 125);
            this.lblNumarInmatriculare.Name = "lblNumarInmatriculare";
            this.lblNumarInmatriculare.Size = new System.Drawing.Size(115, 13);
            this.lblNumarInmatriculare.TabIndex = 5;
            this.lblNumarInmatriculare.Text = "Număr de înmatriculare:";
            // 
            // txtNumarInmatriculare
            // 
            this.txtNumarInmatriculare.Location = new System.Drawing.Point(16, 141);
            this.txtNumarInmatriculare.Name = "txtNumarInmatriculare";
            this.txtNumarInmatriculare.Size = new System.Drawing.Size(173, 20);
            this.txtNumarInmatriculare.TabIndex = 6;
            // 
            // lblTipVehicul
            // 
            this.lblTipVehicul.AutoSize = true;
            this.lblTipVehicul.Location = new System.Drawing.Point(205, 125);
            this.lblTipVehicul.Name = "lblTipVehicul";
            this.lblTipVehicul.Size = new System.Drawing.Size(64, 13);
            this.lblTipVehicul.TabIndex = 7;
            this.lblTipVehicul.Text = "Tip vehicul:";
            // 
            // cmbTipVehicul
            // 
            this.cmbTipVehicul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipVehicul.FormattingEnabled = true;
            this.cmbTipVehicul.Location = new System.Drawing.Point(208, 141);
            this.cmbTipVehicul.Name = "cmbTipVehicul";
            this.cmbTipVehicul.Size = new System.Drawing.Size(164, 21);
            this.cmbTipVehicul.TabIndex = 8;
            this.cmbTipVehicul.SelectedIndexChanged += new System.EventHandler(this.cmbTipVehicul_SelectedIndexChanged);
            // 
            // grpStatusuriSpeciale
            // 
            this.grpStatusuriSpeciale.Controls.Add(this.chkVIP);
            this.grpStatusuriSpeciale.Controls.Add(this.chkPentruDizabilitati);
            this.grpStatusuriSpeciale.Controls.Add(this.chkPentruElectrice);
            this.grpStatusuriSpeciale.Controls.Add(this.chkRezervat);
            this.grpStatusuriSpeciale.Location = new System.Drawing.Point(16, 177);
            this.grpStatusuriSpeciale.Name = "grpStatusuriSpeciale";
            this.grpStatusuriSpeciale.Size = new System.Drawing.Size(356, 100);
            this.grpStatusuriSpeciale.TabIndex = 9;
            this.grpStatusuriSpeciale.TabStop = false;
            this.grpStatusuriSpeciale.Text = "Statusuri speciale";
            // 
            // chkRezervat
            // 
            this.chkRezervat.AutoSize = true;
            this.chkRezervat.Location = new System.Drawing.Point(15, 30);
            this.chkRezervat.Name = "chkRezervat";
            this.chkRezervat.Size = new System.Drawing.Size(70, 17);
            this.chkRezervat.TabIndex = 0;
            this.chkRezervat.Text = "Rezervat";
            this.chkRezervat.UseVisualStyleBackColor = true;
            // 
            // chkPentruElectrice
            // 
            this.chkPentruElectrice.AutoSize = true;
            this.chkPentruElectrice.Enabled = false;
            this.chkPentruElectrice.Location = new System.Drawing.Point(15, 53);
            this.chkPentruElectrice.Name = "chkPentruElectrice";
            this.chkPentruElectrice.Size = new System.Drawing.Size(145, 17);
            this.chkPentruElectrice.TabIndex = 1;
            this.chkPentruElectrice.Text = "Pentru vehicule electrice";
            this.chkPentruElectrice.UseVisualStyleBackColor = true;
            // 
            // chkPentruDizabilitati
            // 
            this.chkPentruDizabilitati.AutoSize = true;
            this.chkPentruDizabilitati.Location = new System.Drawing.Point(192, 30);
            this.chkPentruDizabilitati.Name = "chkPentruDizabilitati";
            this.chkPentruDizabilitati.Size = new System.Drawing.Size(158, 17);
            this.chkPentruDizabilitati.TabIndex = 2;
            this.chkPentruDizabilitati.Text = "Pentru persoane cu dizabilități";
            this.chkPentruDizabilitati.UseVisualStyleBackColor = true;
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.Location = new System.Drawing.Point(192, 53);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(43, 17);
            this.chkVIP.TabIndex = 3;
            this.chkVIP.Text = "VIP";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // btnOcupa
            // 
            this.btnOcupa.Location = new System.Drawing.Point(216, 296);
            this.btnOcupa.Name = "btnOcupa";
            this.btnOcupa.Size = new System.Drawing.Size(75, 23);
            this.btnOcupa.TabIndex = 10;
            this.btnOcupa.Text = "Ocupă";
            this.btnOcupa.UseVisualStyleBackColor = true;
            this.btnOcupa.Click += new System.EventHandler(this.btnOcupa_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Location = new System.Drawing.Point(297, 296);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(75, 23);
            this.btnAnuleaza.TabIndex = 11;
            this.btnAnuleaza.Text = "Anulează";
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // FormOcupaLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 331);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnOcupa);
            this.Controls.Add(this.grpStatusuriSpeciale);
            this.Controls.Add(this.cmbTipVehicul);
            this.Controls.Add(this.lblTipVehicul);
            this.Controls.Add(this.txtNumarInmatriculare);
            this.Controls.Add(this.lblNumarInmatriculare);
            this.Controls.Add(this.cmbLocuri);
            this.Controls.Add(this.lblSelectareLoc);
            this.Controls.Add(this.lblNumeParcare);
            this.Controls.Add(this.lblParcareSelectata);
            this.Controls.Add(this.lblTitlu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOcupaLoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ocupare loc parcare";
            this.grpStatusuriSpeciale.ResumeLayout(false);
            this.grpStatusuriSpeciale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Label lblParcareSelectata;
        private System.Windows.Forms.Label lblNumeParcare;
        private System.Windows.Forms.Label lblSelectareLoc;
        private System.Windows.Forms.ComboBox cmbLocuri;
        private System.Windows.Forms.Label lblNumarInmatriculare;
        private System.Windows.Forms.TextBox txtNumarInmatriculare;
        private System.Windows.Forms.Label lblTipVehicul;
        private System.Windows.Forms.ComboBox cmbTipVehicul;
        private System.Windows.Forms.GroupBox grpStatusuriSpeciale;
        private System.Windows.Forms.CheckBox chkVIP;
        private System.Windows.Forms.CheckBox chkPentruDizabilitati;
        private System.Windows.Forms.CheckBox chkPentruElectrice;
        private System.Windows.Forms.CheckBox chkRezervat;
        private System.Windows.Forms.Button btnOcupa;
        private System.Windows.Forms.Button btnAnuleaza;
    }
}