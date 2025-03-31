using System.Windows.Forms;
using LibrarieModele;

namespace ParkingApp_UI_WindowsForms
{
    partial class Form1
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabParcari = new System.Windows.Forms.TabPage();
            this.tabVehicule = new System.Windows.Forms.TabPage();
            this.tabStatistici = new System.Windows.Forms.TabPage();

            // ParkingList Components
            this.lblParcari = new System.Windows.Forms.Label();
            this.lvParcari = new System.Windows.Forms.ListView();
            this.colNumeParcare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocuriTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocuriOcupate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocuriLibere = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTarif = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnActualizareParcari = new System.Windows.Forms.Button();
            this.btnAdaugaParcare = new System.Windows.Forms.Button();

            // Parking Details Components
            this.lblDetaliiParcare = new System.Windows.Forms.Label();
            this.pnlDetaliiParcare = new System.Windows.Forms.Panel();
            this.lblNumeParcare = new System.Windows.Forms.Label();
            this.flpLocuriParcare = new System.Windows.Forms.FlowLayoutPanel();

            // Parcare Actions
            this.grpActiuniParcare = new System.Windows.Forms.GroupBox();
            this.btnOcupaLoc = new System.Windows.Forms.Button();
            this.btnElibereazaLoc = new System.Windows.Forms.Button();
            this.btnStatusSpecial = new System.Windows.Forms.Button();

            // Vehicule Components
            this.lblVehicule = new System.Windows.Forms.Label();
            this.lvVehicule = new System.Windows.Forms.ListView();
            this.colNumarInmatriculare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipVehicul = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOraIntrare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOraIesire = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocOcupat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParcareNume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnActualizareVehicule = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabParcari.SuspendLayout();
            this.tabVehicule.SuspendLayout();
            this.pnlDetaliiParcare.SuspendLayout();
            this.grpActiuniParcare.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabParcari);
            this.tabControl.Controls.Add(this.tabVehicule);
            this.tabControl.Controls.Add(this.tabStatistici);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1060, 637);
            this.tabControl.TabIndex = 0;

            // tabParcari
            this.tabParcari.Controls.Add(this.lblParcari);
            this.tabParcari.Controls.Add(this.lvParcari);
            this.tabParcari.Controls.Add(this.btnActualizareParcari);
            this.tabParcari.Controls.Add(this.btnAdaugaParcare);
            this.tabParcari.Controls.Add(this.lblDetaliiParcare);
            this.tabParcari.Controls.Add(this.pnlDetaliiParcare);
            this.tabParcari.Controls.Add(this.grpActiuniParcare);
            this.tabParcari.Location = new System.Drawing.Point(4, 22);
            this.tabParcari.Name = "tabParcari";
            this.tabParcari.Padding = new System.Windows.Forms.Padding(3);
            this.tabParcari.Size = new System.Drawing.Size(1052, 611);
            this.tabParcari.TabIndex = 0;
            this.tabParcari.Text = "Parcări";
            this.tabParcari.UseVisualStyleBackColor = true;

            // lblParcari
            this.lblParcari.AutoSize = true;
            this.lblParcari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcari.Location = new System.Drawing.Point(6, 13);
            this.lblParcari.Name = "lblParcari";
            this.lblParcari.Size = new System.Drawing.Size(147, 16);
            this.lblParcari.TabIndex = 0;
            this.lblParcari.Text = "Parcări disponibile:";

            // lvParcari
            this.lvParcari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvParcari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumeParcare,
            this.colLocuriTotal,
            this.colLocuriOcupate,
            this.colLocuriLibere,
            this.colTarif});
            this.lvParcari.FullRowSelect = true;
            this.lvParcari.HideSelection = false;
            this.lvParcari.Location = new System.Drawing.Point(9, 32);
            this.lvParcari.MultiSelect = false;
            this.lvParcari.Name = "lvParcari";
            this.lvParcari.Size = new System.Drawing.Size(1037, 150);
            this.lvParcari.TabIndex = 1;
            this.lvParcari.UseCompatibleStateImageBehavior = false;
            this.lvParcari.View = System.Windows.Forms.View.Details;
            this.lvParcari.SelectedIndexChanged += new System.EventHandler(this.lvParcari_SelectedIndexChanged);

            // colNumeParcare
            this.colNumeParcare.Text = "Nume parcare";
            this.colNumeParcare.Width = 250;

            // colLocuriTotal
            this.colLocuriTotal.Text = "Total locuri";
            this.colLocuriTotal.Width = 100;

            // colLocuriOcupate
            this.colLocuriOcupate.Text = "Locuri ocupate";
            this.colLocuriOcupate.Width = 100;

            // colLocuriLibere
            this.colLocuriLibere.Text = "Locuri libere";
            this.colLocuriLibere.Width = 100;

            // colTarif
            this.colTarif.Text = "Tarif (lei/oră)";
            this.colTarif.Width = 100;

            // btnActualizareParcari
            this.btnActualizareParcari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizareParcari.Location = new System.Drawing.Point(846, 188);
            this.btnActualizareParcari.Name = "btnActualizareParcari";
            this.btnActualizareParcari.Size = new System.Drawing.Size(97, 23);
            this.btnActualizareParcari.TabIndex = 2;
            this.btnActualizareParcari.Text = "Actualizare listă";
            this.btnActualizareParcari.UseVisualStyleBackColor = true;
            this.btnActualizareParcari.Click += new System.EventHandler(this.btnActualizareParcari_Click);

            // btnAdaugaParcare
            this.btnAdaugaParcare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdaugaParcare.Location = new System.Drawing.Point(949, 188);
            this.btnAdaugaParcare.Name = "btnAdaugaParcare";
            this.btnAdaugaParcare.Size = new System.Drawing.Size(97, 23);
            this.btnAdaugaParcare.TabIndex = 3;
            this.btnAdaugaParcare.Text = "Adaugă parcare";
            this.btnAdaugaParcare.UseVisualStyleBackColor = true;
            this.btnAdaugaParcare.Click += new System.EventHandler(this.btnAdaugaParcare_Click);

            // lblDetaliiParcare
            this.lblDetaliiParcare.AutoSize = true;
            this.lblDetaliiParcare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaliiParcare.Location = new System.Drawing.Point(6, 226);
            this.lblDetaliiParcare.Name = "lblDetaliiParcare";
            this.lblDetaliiParcare.Size = new System.Drawing.Size(114, 16);
            this.lblDetaliiParcare.TabIndex = 4;
            this.lblDetaliiParcare.Text = "Detalii parcare:";

            // pnlDetaliiParcare
            this.pnlDetaliiParcare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetaliiParcare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetaliiParcare.Controls.Add(this.lblNumeParcare);
            this.pnlDetaliiParcare.Controls.Add(this.flpLocuriParcare);
            this.pnlDetaliiParcare.Location = new System.Drawing.Point(9, 245);
            this.pnlDetaliiParcare.Name = "pnlDetaliiParcare";
            this.pnlDetaliiParcare.Size = new System.Drawing.Size(789, 360);
            this.pnlDetaliiParcare.TabIndex = 5;

            // lblNumeParcare
            this.lblNumeParcare.AutoSize = true;
            this.lblNumeParcare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeParcare.Location = new System.Drawing.Point(3, 10);
            this.lblNumeParcare.Name = "lblNumeParcare";
            this.lblNumeParcare.Size = new System.Drawing.Size(160, 20);
            this.lblNumeParcare.TabIndex = 0;
            this.lblNumeParcare.Text = "Selectați o parcare";

            // flpLocuriParcare
            this.flpLocuriParcare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpLocuriParcare.AutoScroll = true;
            this.flpLocuriParcare.Location = new System.Drawing.Point(3, 33);
            this.flpLocuriParcare.Name = "flpLocuriParcare";
            this.flpLocuriParcare.Size = new System.Drawing.Size(781, 322);
            this.flpLocuriParcare.TabIndex = 1;

            // grpActiuniParcare
            this.grpActiuniParcare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActiuniParcare.Controls.Add(this.btnOcupaLoc);
            this.grpActiuniParcare.Controls.Add(this.btnElibereazaLoc);
            this.grpActiuniParcare.Controls.Add(this.btnStatusSpecial);
            this.grpActiuniParcare.Location = new System.Drawing.Point(804, 245);
            this.grpActiuniParcare.Name = "grpActiuniParcare";
            this.grpActiuniParcare.Size = new System.Drawing.Size(242, 360);
            this.grpActiuniParcare.TabIndex = 6;
            this.grpActiuniParcare.TabStop = false;
            this.grpActiuniParcare.Text = "Acțiuni";

            // btnOcupaLoc
            this.btnOcupaLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcupaLoc.Location = new System.Drawing.Point(18, 30);
            this.btnOcupaLoc.Name = "btnOcupaLoc";
            this.btnOcupaLoc.Size = new System.Drawing.Size(208, 30);
            this.btnOcupaLoc.TabIndex = 0;
            this.btnOcupaLoc.Text = "Ocupă loc parcare";
            this.btnOcupaLoc.UseVisualStyleBackColor = true;
            this.btnOcupaLoc.Click += new System.EventHandler(this.btnOcupaLoc_Click);

            // btnElibereazaLoc
            this.btnElibereazaLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElibereazaLoc.Location = new System.Drawing.Point(18, 66);
            this.btnElibereazaLoc.Name = "btnElibereazaLoc";
            this.btnElibereazaLoc.Size = new System.Drawing.Size(208, 30);
            this.btnElibereazaLoc.TabIndex = 1;
            this.btnElibereazaLoc.Text = "Eliberează loc parcare";
            this.btnElibereazaLoc.UseVisualStyleBackColor = true;
            this.btnElibereazaLoc.Click += new System.EventHandler(this.btnElibereazaLoc_Click);

            // btnStatusSpecial
            this.btnStatusSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusSpecial.Location = new System.Drawing.Point(18, 102);
            this.btnStatusSpecial.Name = "btnStatusSpecial";
            this.btnStatusSpecial.Size = new System.Drawing.Size(208, 30);
            this.btnStatusSpecial.TabIndex = 2;
            this.btnStatusSpecial.Text = "Modifică status special";
            this.btnStatusSpecial.UseVisualStyleBackColor = true;
            this.btnStatusSpecial.Click += new System.EventHandler(this.btnStatusSpecial_Click);

            // tabVehicule
            this.tabVehicule.Controls.Add(this.lblVehicule);
            this.tabVehicule.Controls.Add(this.lvVehicule);
            this.tabVehicule.Controls.Add(this.btnActualizareVehicule);
            this.tabVehicule.Location = new System.Drawing.Point(4, 22);
            this.tabVehicule.Name = "tabVehicule";
            this.tabVehicule.Padding = new System.Windows.Forms.Padding(3);
            this.tabVehicule.Size = new System.Drawing.Size(1052, 611);
            this.tabVehicule.TabIndex = 1;
            this.tabVehicule.Text = "Vehicule";
            this.tabVehicule.UseVisualStyleBackColor = true;

            // lblVehicule
            this.lblVehicule.AutoSize = true;
            this.lblVehicule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicule.Location = new System.Drawing.Point(6, 13);
            this.lblVehicule.Name = "lblVehicule";
            this.lblVehicule.Size = new System.Drawing.Size(166, 16);
            this.lblVehicule.TabIndex = 0;
            this.lblVehicule.Text = "Vehicule înregistrate:";

            // lvVehicule
            this.lvVehicule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVehicule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumarInmatriculare,
            this.colTipVehicul,
            this.colOraIntrare,
            this.colOraIesire,
            this.colLocOcupat,
            this.colParcareNume});
            this.lvVehicule.FullRowSelect = true;
            this.lvVehicule.HideSelection = false;
            this.lvVehicule.Location = new System.Drawing.Point(9, 32);
            this.lvVehicule.Name = "lvVehicule";
            this.lvVehicule.Size = new System.Drawing.Size(1037, 543);
            this.lvVehicule.TabIndex = 1;
            this.lvVehicule.UseCompatibleStateImageBehavior = false;
            this.lvVehicule.View = System.Windows.Forms.View.Details;

            // colNumarInmatriculare
            this.colNumarInmatriculare.Text = "Număr înmatriculare";
            this.colNumarInmatriculare.Width = 150;

            // colTipVehicul
            this.colTipVehicul.Text = "Tip vehicul";
            this.colTipVehicul.Width = 100;

            // colOraIntrare
            this.colOraIntrare.Text = "Ora intrare";
            this.colOraIntrare.Width = 150;

            // colOraIesire
            this.colOraIesire.Text = "Ora ieșire";
            this.colOraIesire.Width = 150;

            // colLocOcupat
            this.colLocOcupat.Text = "Loc ocupat";
            this.colLocOcupat.Width = 80;

            // colParcareNume
            this.colParcareNume.Text = "Parcare";
            this.colParcareNume.Width = 200;

            // btnActualizareVehicule
            this.btnActualizareVehicule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizareVehicule.Location = new System.Drawing.Point(926, 581);
            this.btnActualizareVehicule.Name = "btnActualizareVehicule";
            this.btnActualizareVehicule.Size = new System.Drawing.Size(120, 23);
            this.btnActualizareVehicule.TabIndex = 2;
            this.btnActualizareVehicule.Text = "Actualizare listă";
            this.btnActualizareVehicule.UseVisualStyleBackColor = true;
            this.btnActualizareVehicule.Click += new System.EventHandler(this.btnActualizareVehicule_Click);

            // tabStatistici
            this.tabStatistici.Location = new System.Drawing.Point(4, 22);
            this.tabStatistici.Name = "tabStatistici";
            this.tabStatistici.Size = new System.Drawing.Size(1052, 611);
            this.tabStatistici.TabIndex = 2;
            this.tabStatistici.Text = "Statistici";
            this.tabStatistici.UseVisualStyleBackColor = true;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicație management parcări";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabParcari.ResumeLayout(false);
            this.tabParcari.PerformLayout();
            this.tabVehicule.ResumeLayout(false);
            this.tabVehicule.PerformLayout();
            this.pnlDetaliiParcare.ResumeLayout(false);
            this.pnlDetaliiParcare.PerformLayout();
            this.grpActiuniParcare.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabParcari;
        private System.Windows.Forms.TabPage tabVehicule;
        private System.Windows.Forms.TabPage tabStatistici;

        private System.Windows.Forms.Label lblParcari;
        private System.Windows.Forms.ListView lvParcari;
        private System.Windows.Forms.ColumnHeader colNumeParcare;
        private System.Windows.Forms.ColumnHeader colLocuriTotal;
        private System.Windows.Forms.ColumnHeader colLocuriOcupate;
        private System.Windows.Forms.ColumnHeader colLocuriLibere;
        private System.Windows.Forms.ColumnHeader colTarif;
        private System.Windows.Forms.Button btnActualizareParcari;
        private System.Windows.Forms.Button btnAdaugaParcare;

        private System.Windows.Forms.Label lblDetaliiParcare;
        private System.Windows.Forms.Panel pnlDetaliiParcare;
        private System.Windows.Forms.Label lblNumeParcare;
        private System.Windows.Forms.FlowLayoutPanel flpLocuriParcare;

        private System.Windows.Forms.GroupBox grpActiuniParcare;
        private System.Windows.Forms.Button btnOcupaLoc;
        private System.Windows.Forms.Button btnElibereazaLoc;
        private System.Windows.Forms.Button btnStatusSpecial;

        private System.Windows.Forms.Label lblVehicule;
        private System.Windows.Forms.ListView lvVehicule;
        private System.Windows.Forms.ColumnHeader colNumarInmatriculare;
        private System.Windows.Forms.ColumnHeader colTipVehicul;
        private System.Windows.Forms.ColumnHeader colOraIntrare;
        private System.Windows.Forms.ColumnHeader colOraIesire;
        private System.Windows.Forms.ColumnHeader colLocOcupat;
        private System.Windows.Forms.ColumnHeader colParcareNume;
        private System.Windows.Forms.Button btnActualizareVehicule;
    }
}