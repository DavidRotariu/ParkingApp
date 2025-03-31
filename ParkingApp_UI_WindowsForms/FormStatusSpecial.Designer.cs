namespace ParkingApp_UI_WindowsForms
{
    partial class FormStatusSpecial
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
            this.lblStatusCurent = new System.Windows.Forms.Label();
            this.grpStatusuri = new System.Windows.Forms.GroupBox();
            this.chkRezervat = new System.Windows.Forms.CheckBox();
            this.chkPentruDizabilitati = new System.Windows.Forms.CheckBox();
            this.chkInMentenanta = new System.Windows.Forms.CheckBox();
            this.chkPentruElectrice = new System.Windows.Forms.CheckBox();
            this.chkVIP = new System.Windows.Forms.CheckBox();
            this.chkTemporar = new System.Windows.Forms.CheckBox();
            this.grpStatusBaza = new System.Windows.Forms.GroupBox();
            this.chkLiber = new System.Windows.Forms.CheckBox();
            this.chkOcupat = new System.Windows.Forms.CheckBox();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.btnReseteaza = new System.Windows.Forms.Button();
            this.grpStatusuri.SuspendLayout();
            this.grpStatusBaza.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(12, 9);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(173, 20);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Statusuri loc parcare";
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
            this.lblSelectareLoc.Location = new System.Drawing.Point(13, 72);
            this.lblSelectareLoc.Name = "lblSelectareLoc";
            this.lblSelectareLoc.Size = new System.Drawing.Size(67, 13);
            this.lblSelectareLoc.TabIndex = 3;
            this.lblSelectareLoc.Text = "Selectați loc:";
            // 
            // cmbLocuri
            // 
            this.cmbLocuri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocuri.FormattingEnabled = true;
            this.cmbLocuri.Location = new System.Drawing.Point(16, 88);
            this.cmbLocuri.Name = "cmbLocuri";
            this.cmbLocuri.Size = new System.Drawing.Size(356, 21);
            this.cmbLocuri.TabIndex = 4;
            this.cmbLocuri.SelectedIndexChanged += new System.EventHandler(this.cmbLocuri_SelectedIndexChanged);
            // 
            // lblStatusCurent
            // 
            this.lblStatusCurent.AutoSize = true;
            this.lblStatusCurent.Location = new System.Drawing.Point(13, 121);
            this.lblStatusCurent.Name = "lblStatusCurent";
            this.lblStatusCurent.Size = new System.Drawing.Size(81, 13);
            this.lblStatusCurent.TabIndex = 5;
            this.lblStatusCurent.Text = "Status curent: -";
            // 
            // grpStatusuri
            // 
            this.grpStatusuri.Controls.Add(this.chkTemporar);
            this.grpStatusuri.Controls.Add(this.chkVIP);
            this.grpStatusuri.Controls.Add(this.chkPentruElectrice);
            this.grpStatusuri.Controls.Add(this.chkInMentenanta);
            this.grpStatusuri.Controls.Add(this.chkPentruDizabilitati);
            this.grpStatusuri.Controls.Add(this.chkRezervat);
            this.grpStatusuri.Location = new System.Drawing.Point(16, 195);
            this.grpStatusuri.Name = "grpStatusuri";
            this.grpStatusuri.Size = new System.Drawing.Size(356, 123);
            this.grpStatusuri.TabIndex = 6;
            this.grpStatusuri.TabStop = false;
            this.grpStatusuri.Text = "Statusuri speciale";
            // 
            // chkRezervat
            // 
            this.chkRezervat.AutoSize = true;
            this.chkRezervat.Location = new System.Drawing.Point(17, 29);
            this.chkRezervat.Name = "chkRezervat";
            this.chkRezervat.Size = new System.Drawing.Size(70, 17);
            this.chkRezervat.TabIndex = 0;
            this.chkRezervat.Text = "Rezervat";
            this.chkRezervat.UseVisualStyleBackColor = true;
            // 
            // chkPentruDizabilitati
            // 
            this.chkPentruDizabilitati.AutoSize = true;
            this.chkPentruDizabilitati.Location = new System.Drawing.Point(17, 52);
            this.chkPentruDizabilitati.Name = "chkPentruDizabilitati";
            this.chkPentruDizabilitati.Size = new System.Drawing.Size(158, 17);
            this.chkPentruDizabilitati.TabIndex = 1;
            this.chkPentruDizabilitati.Text = "Pentru persoane cu dizabilități";
            this.chkPentruDizabilitati.UseVisualStyleBackColor = true;
            // 
            // chkInMentenanta
            // 
            this.chkInMentenanta.AutoSize = true;
            this.chkInMentenanta.Location = new System.Drawing.Point(17, 75);
            this.chkInMentenanta.Name = "chkInMentenanta";
            this.chkInMentenanta.Size = new System.Drawing.Size(92, 17);
            this.chkInMentenanta.TabIndex = 2;
            this.chkInMentenanta.Text = "În mentenanță";
            this.chkInMentenanta.UseVisualStyleBackColor = true;
            this.chkInMentenanta.CheckedChanged += new System.EventHandler(this.chkInMentenanta_CheckedChanged);
            // 
            // chkPentruElectrice
            // 
            this.chkPentruElectrice.AutoSize = true;
            this.chkPentruElectrice.Location = new System.Drawing.Point(193, 29);
            this.chkPentruElectrice.Name = "chkPentruElectrice";
            this.chkPentruElectrice.Size = new System.Drawing.Size(145, 17);
            this.chkPentruElectrice.TabIndex = 3;
            this.chkPentruElectrice.Text = "Pentru vehicule electrice";
            this.chkPentruElectrice.UseVisualStyleBackColor = true;
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.Location = new System.Drawing.Point(193, 52);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(43, 17);
            this.chkVIP.TabIndex = 4;
            this.chkVIP.Text = "VIP";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // chkTemporar
            // 
            this.chkTemporar.AutoSize = true;
            this.chkTemporar.Location = new System.Drawing.Point(193, 75);
            this.chkTemporar.Name = "chkTemporar";
            this.chkTemporar.Size = new System.Drawing.Size(73, 17);
            this.chkTemporar.TabIndex = 5;
            this.chkTemporar.Text = "Temporar";
            this.chkTemporar.UseVisualStyleBackColor = true;
            // 
            // grpStatusBaza
            // 
            this.grpStatusBaza.Controls.Add(this.chkOcupat);
            this.grpStatusBaza.Controls.Add(this.chkLiber);
            this.grpStatusBaza.Location = new System.Drawing.Point(16, 146);
            this.grpStatusBaza.Name = "grpStatusBaza";
            this.grpStatusBaza.Size = new System.Drawing.Size(356, 43);
            this.grpStatusBaza.TabIndex = 7;
            this.grpStatusBaza.TabStop = false;
            this.grpStatusBaza.Text = "Status de bază";
            // 
            // chkLiber
            // 
            this.chkLiber.AutoSize = true;
            this.chkLiber.Location = new System.Drawing.Point(193, 19);
            this.chkLiber.Name = "chkLiber";
            this.chkLiber.Size = new System.Drawing.Size(49, 17);
            this.chkLiber.TabIndex = 0;
            this.chkLiber.Text = "Liber";
            this.chkLiber.UseVisualStyleBackColor = true;
            this.chkLiber.CheckedChanged += new System.EventHandler(this.chkLiber_CheckedChanged);
            // 
            // chkOcupat
            // 
            this.chkOcupat.AutoSize = true;
            this.chkOcupat.Location = new System.Drawing.Point(17, 19);
            this.chkOcupat.Name = "chkOcupat";
            this.chkOcupat.Size = new System.Drawing.Size(62, 17);
            this.chkOcupat.TabIndex = 1;
            this.chkOcupat.Text = "Ocupat";
            this.chkOcupat.UseVisualStyleBackColor = true;
            this.chkOcupat.CheckedChanged += new System.EventHandler(this.chkOcupat_CheckedChanged);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(216, 335);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(75, 23);
            this.btnSalveaza.TabIndex = 8;
            this.btnSalveaza.Text = "Salvează";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Location = new System.Drawing.Point(297, 335);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(75, 23);
            this.btnAnuleaza.TabIndex = 9;
            this.btnAnuleaza.Text = "Anulează";
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // btnReseteaza
            // 
            this.btnReseteaza.Location = new System.Drawing.Point(16, 335);
            this.btnReseteaza.Name = "btnReseteaza";
            this.btnReseteaza.Size = new System.Drawing.Size(75, 23);
            this.btnReseteaza.TabIndex = 10;
            this.btnReseteaza.Text = "Resetează";
            this.btnReseteaza.UseVisualStyleBackColor = true;
            this.btnReseteaza.Click += new System.EventHandler(this.btnReseteaza_Click);
            // 
            // FormStatusSpecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 371);
            this.Controls.Add(this.btnReseteaza);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.grpStatusBaza);
            this.Controls.Add(this.grpStatusuri);
            this.Controls.Add(this.lblStatusCurent);
            this.Controls.Add(this.cmbLocuri);
            this.Controls.Add(this.lblSelectareLoc);
            this.Controls.Add(this.lblNumeParcare);
            this.Controls.Add(this.lblParcareSelectata);
            this.Controls.Add(this.lblTitlu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatusSpecial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificare statusuri loc parcare";
            this.grpStatusuri.ResumeLayout(false);
            this.grpStatusuri.PerformLayout();
            this.grpStatusBaza.ResumeLayout(false);
            this.grpStatusBaza.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Label lblParcareSelectata;
        private System.Windows.Forms.Label lblNumeParcare;
        private System.Windows.Forms.Label lblSelectareLoc;
        private System.Windows.Forms.ComboBox cmbLocuri;
        private System.Windows.Forms.Label lblStatusCurent;
        private System.Windows.Forms.GroupBox grpStatusuri;
        private System.Windows.Forms.CheckBox chkTemporar;
        private System.Windows.Forms.CheckBox chkVIP;
        private System.Windows.Forms.CheckBox chkPentruElectrice;
        private System.Windows.Forms.CheckBox chkInMentenanta;
        private System.Windows.Forms.CheckBox chkPentruDizabilitati;
        private System.Windows.Forms.CheckBox chkRezervat;
        private System.Windows.Forms.GroupBox grpStatusBaza;
        private System.Windows.Forms.CheckBox chkOcupat;
        private System.Windows.Forms.CheckBox chkLiber;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Button btnAnuleaza;
        private System.Windows.Forms.Button btnReseteaza;
    }
}