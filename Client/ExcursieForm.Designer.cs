namespace clientAgentie
{
    partial class ExcursieForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obiectiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OraPlecare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locuri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRezervare = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtBilete = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCauta = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOra2 = new System.Windows.Forms.TextBox();
            this.txtOra1 = new System.Windows.Forms.TextBox();
            this.txtObiectiv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGridViewCauta = new System.Windows.Forms.DataGridView();
            this.IdExcursie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObiectivTuristic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirmaExcursie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PretExcursie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocuriExcursie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCauta)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.obiectiv,
            this.Firma,
            this.OraPlecare,
            this.Pret,
            this.Locuri});
            this.dataGridView.Location = new System.Drawing.Point(1, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(645, 196);
            this.dataGridView.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // obiectiv
            // 
            this.obiectiv.HeaderText = "Obiectiv Turistic";
            this.obiectiv.Name = "obiectiv";
            // 
            // Firma
            // 
            this.Firma.HeaderText = "Firma";
            this.Firma.Name = "Firma";
            // 
            // OraPlecare
            // 
            this.OraPlecare.HeaderText = "Ora plecare";
            this.OraPlecare.Name = "OraPlecare";
            // 
            // Pret
            // 
            this.Pret.HeaderText = "Pret";
            this.Pret.Name = "Pret";
            // 
            // Locuri
            // 
            this.Locuri.HeaderText = "Locuri";
            this.Locuri.Name = "Locuri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefon";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRezervare);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNume);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.txtBilete);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(652, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 186);
            this.panel1.TabIndex = 5;
            // 
            // btnRezervare
            // 
            this.btnRezervare.Location = new System.Drawing.Point(88, 151);
            this.btnRezervare.Name = "btnRezervare";
            this.btnRezervare.Size = new System.Drawing.Size(113, 23);
            this.btnRezervare.TabIndex = 9;
            this.btnRezervare.Text = "Rezerva";
            this.btnRezervare.UseVisualStyleBackColor = true;
            this.btnRezervare.Click += new System.EventHandler(this.btnRezervare_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bilete";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(154, 59);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(124, 20);
            this.txtNume.TabIndex = 7;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(154, 87);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(124, 20);
            this.txtTel.TabIndex = 6;
            // 
            // txtBilete
            // 
            this.txtBilete.Location = new System.Drawing.Point(154, 113);
            this.txtBilete.Name = "txtBilete";
            this.txtBilete.Size = new System.Drawing.Size(124, 20);
            this.txtBilete.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCauta);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtOra2);
            this.panel2.Controls.Add(this.txtOra1);
            this.panel2.Controls.Add(this.txtObiectiv);
            this.panel2.Location = new System.Drawing.Point(99, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 186);
            this.panel2.TabIndex = 6;
            // 
            // btnCauta
            // 
            this.btnCauta.Location = new System.Drawing.Point(102, 135);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(125, 23);
            this.btnCauta.TabIndex = 8;
            this.btnCauta.Text = "Cauta";
            this.btnCauta.UseVisualStyleBackColor = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ora sfarsit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Obiectiv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ora start";
            // 
            // txtOra2
            // 
            this.txtOra2.Location = new System.Drawing.Point(150, 90);
            this.txtOra2.Name = "txtOra2";
            this.txtOra2.Size = new System.Drawing.Size(123, 20);
            this.txtOra2.TabIndex = 2;
            // 
            // txtOra1
            // 
            this.txtOra1.Location = new System.Drawing.Point(150, 64);
            this.txtOra1.Name = "txtOra1";
            this.txtOra1.Size = new System.Drawing.Size(123, 20);
            this.txtOra1.TabIndex = 1;
            // 
            // txtObiectiv
            // 
            this.txtObiectiv.Location = new System.Drawing.Point(150, 38);
            this.txtObiectiv.Name = "txtObiectiv";
            this.txtObiectiv.Size = new System.Drawing.Size(123, 20);
            this.txtObiectiv.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Selectati din lista de mai jos excursia dorita:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Rezultat cautare:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 415);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGridViewCauta
            // 
            this.dataGridViewCauta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCauta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdExcursie,
            this.ObiectivTuristic,
            this.FirmaExcursie,
            this.Ora,
            this.PretExcursie,
            this.LocuriExcursie});
            this.dataGridViewCauta.Location = new System.Drawing.Point(54, 27);
            this.dataGridViewCauta.Name = "dataGridViewCauta";
            this.dataGridViewCauta.Size = new System.Drawing.Size(438, 159);
            this.dataGridViewCauta.TabIndex = 11;
            // 
            // IdExcursie
            // 
            this.IdExcursie.HeaderText = "Id";
            this.IdExcursie.Name = "IdExcursie";
            this.IdExcursie.Visible = false;
            // 
            // ObiectivTuristic
            // 
            this.ObiectivTuristic.HeaderText = "Obiectiv";
            this.ObiectivTuristic.Name = "ObiectivTuristic";
            this.ObiectivTuristic.Visible = false;
            // 
            // FirmaExcursie
            // 
            this.FirmaExcursie.HeaderText = "Firma";
            this.FirmaExcursie.Name = "FirmaExcursie";
            // 
            // Ora
            // 
            this.Ora.HeaderText = "Ora";
            this.Ora.Name = "Ora";
            // 
            // PretExcursie
            // 
            this.PretExcursie.HeaderText = "Pret";
            this.PretExcursie.Name = "PretExcursie";
            // 
            // LocuriExcursie
            // 
            this.LocuriExcursie.HeaderText = "Locuri";
            this.LocuriExcursie.Name = "LocuriExcursie";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewCauta);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(447, 236);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 186);
            this.panel3.TabIndex = 12;
            // 
            // ExcursieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.Name = "ExcursieForm";
            this.Text = "ProduseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCauta)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRezervare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtBilete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOra2;
        private System.Windows.Forms.TextBox txtOra1;
        private System.Windows.Forms.TextBox txtObiectiv;
        private System.Windows.Forms.Button btnCauta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn obiectiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firma;
        private System.Windows.Forms.DataGridViewTextBoxColumn OraPlecare;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pret;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locuri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dataGridViewCauta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdExcursie;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObiectivTuristic;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirmaExcursie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ora;
        private System.Windows.Forms.DataGridViewTextBoxColumn PretExcursie;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocuriExcursie;
        private System.Windows.Forms.Panel panel3;
    }
}