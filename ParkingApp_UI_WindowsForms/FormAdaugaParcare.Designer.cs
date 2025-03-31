namespace ParkingApp_UI_WindowsForms
{
    partial class FormAdaugaParcare
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
            this.lblNumeParcare = new System.Windows.Forms.Label();
            this.txtNumeParcare = new System.Windows.Forms.TextBox();
            this.lblNumarLocuri = new System.Windows.Forms.Label();
            this.txtNumarLocuri = new System.Windows.Forms.TextBox();
            this.lblTarifOra = new System.Windows.Forms.Label();
            this.txtTarifOra = new System.Windows.Forms.TextBox();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(12, 9);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(153, 20);
            this.lblTitlu.TabIndex = 0;
            this.lblTitlu.Text = "Adăugare parcare";
            // 
            // lblNumeParcare
            // 
            this.lblNumeParcare.AutoSize = true;
            this.lblNumeParcare.Location = new System.Drawing.Point(13, 43);
            this.lblNumeParcare.Name = "lblNumeParcare";
            this.lblNumeParcare.Size = new System.Drawing.Size(80, 13);
            this.lblNumeParcare.TabIndex = 1;
            this.lblNumeParcare.Text = "Nume parcare:";
            // 
            // txtNumeParcare
            // 
            this.txtNumeParcare.Location = new System.Drawing.Point(16, 59);
            this.txtNumeParcare.Name = "txtNumeParcare";
            this.txtNumeParcare.Size = new System.Drawing.Size(356, 20);
            this.txtNumeParcare.TabIndex = 2;
            // 
            // lblNumarLocuri
            // 
            this.lblNumarLocuri.AutoSize = true;
            this.lblNumarLocuri.Location = new System.Drawing.Point(13, 91);
            this.lblNumarLocuri.Name = "lblNumarLocuri";
            this.lblNumarLocuri.Size = new System.Drawing.Size(70, 13);
            this.lblNumarLocuri.TabIndex = 3;
            this.lblNumarLocuri.Text = "Număr locuri:";
            // 
            // txtNumarLocuri
            // 
            this.txtNumarLocuri.Location = new System.Drawing.Point(16, 107);
            this.txtNumarLocuri.Name = "txtNumarLocuri";
            this.txtNumarLocuri.Size = new System.Drawing.Size(100, 20);
            this.txtNumarLocuri.TabIndex = 4;
            // 
            // lblTarifOra
            // 
            this.lblTarifOra.AutoSize = true;
            this.lblTarifOra.Location = new System.Drawing.Point(13, 139);
            this.lblTarifOra.Name = "lblTarifOra";
            this.lblTarifOra.Size = new System.Drawing.Size(97, 13);
            this.lblTarifOra.TabIndex = 5;
            this.lblTarifOra.Text = "Tarif orar (lei/oră):";
            // 
            // txtTarifOra
            // 
            this.txtTarifOra.Location = new System.Drawing.Point(16, 155);
            this.txtTarifOra.Name = "txtTarifOra";
            this.txtTarifOra.Size = new System.Drawing.Size(100, 20);
            this.txtTarifOra.TabIndex = 6;
            this.txtTarifOra.Text = "5.00";
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(216, 199);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(75, 23);
            this.btnSalveaza.TabIndex = 7;
            this.btnSalveaza.Text = "Salvează";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Location = new System.Drawing.Point(297, 199);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(75, 23);
            this.btnAnuleaza.TabIndex = 8;
            this.btnAnuleaza.Text = "Anulează";
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // FormAdaugaParcare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 234);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.txtTarifOra);
            this.Controls.Add(this.lblTarifOra);
            this.Controls.Add(this.txtNumarLocuri);
            this.Controls.Add(this.lblNumarLocuri);
            this.Controls.Add(this.txtNumeParcare);
            this.Controls.Add(this.lblNumeParcare);
            this.Controls.Add(this.lblTitlu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdaugaParcare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adăugare parcare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Label lblNumeParcare;
        private System.Windows.Forms.TextBox txtNumeParcare;
        private System.Windows.Forms.Label lblNumarLocuri;
        private System.Windows.Forms.TextBox txtNumarLocuri;
        private System.Windows.Forms.Label lblTarifOra;
        private System.Windows.Forms.TextBox txtTarifOra;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Button btnAnuleaza;
    }
}