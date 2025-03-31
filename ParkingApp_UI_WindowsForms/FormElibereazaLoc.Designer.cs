namespace ParkingApp_UI_WindowsForms
{
    partial class FormElibereazaLoc
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
            this.chkPastreazaStatus = new System.Windows.Forms.CheckBox();
            this.btnElibereaza = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(12, 9);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(182, 20);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Eliberare loc parcare";
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
            this.lblSelectareLoc.Text = "Selectați locul de eliberat:";
            // 
            // cmbLocuri
            // 
            this.cmbLocuri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocuri.FormattingEnabled = true;
            this.cmbLocuri.Location = new System.Drawing.Point(16, 91);
            this.cmbLocuri.Name = "cmbLocuri";
            this.cmbLocuri.Size = new System.Drawing.Size(356, 21);
            this.cmbLocuri.TabIndex = 4;
            this.cmbLocuri.SelectedIndexChanged += new System.EventHandler(this.cmbLocuri_SelectedIndexChanged);
            // 
            // chkPastreazaStatus
            // 
            this.chkPastreazaStatus.AutoSize = true;
            this.chkPastreazaStatus.Enabled = false;
            this.chkPastreazaStatus.Location = new System.Drawing.Point(16, 128);
            this.chkPastreazaStatus.Name = "chkPastreazaStatus";
            this.chkPastreazaStatus.Size = new System.Drawing.Size(149, 17);
            this.chkPastreazaStatus.TabIndex = 5;
            this.chkPastreazaStatus.Text = "Păstrează statusurile speciale";
            this.chkPastreazaStatus.UseVisualStyleBackColor = true;
            // 
            // btnElibereaza
            // 
            this.btnElibereaza.Location = new System.Drawing.Point(207, 169);
            this.btnElibereaza.Name = "btnElibereaza";
            this.btnElibereaza.Size = new System.Drawing.Size(84, 23);
            this.btnElibereaza.TabIndex = 6;
            this.btnElibereaza.Text = "Eliberează";
            this.btnElibereaza.UseVisualStyleBackColor = true;
            this.btnElibereaza.Click += new System.EventHandler(this.btnElibereaza_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Location = new System.Drawing.Point(297, 169);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(75, 23);
            this.btnAnuleaza.TabIndex = 7;
            this.btnAnuleaza.Text = "Anulează";
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // FormElibereazaLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnElibereaza);
            this.Controls.Add(this.chkPastreazaStatus);
            this.Controls.Add(this.cmbLocuri);
            this.Controls.Add(this.lblSelectareLoc);
            this.Controls.Add(this.lblNumeParcare);
            this.Controls.Add(this.lblParcareSelectata);
            this.Controls.Add(this.lblTitlu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormElibereazaLoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eliberare loc parcare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Label lblParcareSelectata;
        private System.Windows.Forms.Label lblNumeParcare;
        private System.Windows.Forms.Label lblSelectareLoc;
        private System.Windows.Forms.ComboBox cmbLocuri;
        private System.Windows.Forms.CheckBox chkPastreazaStatus;
        private System.Windows.Forms.Button btnElibereaza;
        private System.Windows.Forms.Button btnAnuleaza;
    }
}