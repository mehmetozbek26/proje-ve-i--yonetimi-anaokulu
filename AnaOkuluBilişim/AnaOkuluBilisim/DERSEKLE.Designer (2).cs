namespace AnaOkuluBilisim
{
    partial class DERSEKLE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DERSEKLE));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOgrAdi = new System.Windows.Forms.TextBox();
            this.dersdatagrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOgrSoyad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDersAdi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dersdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ogretmen Adi : ";
            // 
            // txtOgrAdi
            // 
            this.txtOgrAdi.Location = new System.Drawing.Point(136, 192);
            this.txtOgrAdi.Name = "txtOgrAdi";
            this.txtOgrAdi.ReadOnly = true;
            this.txtOgrAdi.Size = new System.Drawing.Size(244, 20);
            this.txtOgrAdi.TabIndex = 1;
            // 
            // dersdatagrid
            // 
            this.dersdatagrid.AllowUserToAddRows = false;
            this.dersdatagrid.AllowUserToDeleteRows = false;
            this.dersdatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dersdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dersdatagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dersdatagrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dersdatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dersdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dersdatagrid.Location = new System.Drawing.Point(12, 12);
            this.dersdatagrid.MultiSelect = false;
            this.dersdatagrid.Name = "dersdatagrid";
            this.dersdatagrid.ReadOnly = true;
            this.dersdatagrid.RowHeadersVisible = false;
            this.dersdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dersdatagrid.Size = new System.Drawing.Size(356, 150);
            this.dersdatagrid.TabIndex = 2;
            this.dersdatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dersdatagrid_CellContentClick);
            this.dersdatagrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dersdatagrid_MouseClick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ogretmen Soyad : ";
            // 
            // txtOgrSoyad
            // 
            this.txtOgrSoyad.Location = new System.Drawing.Point(136, 218);
            this.txtOgrSoyad.Name = "txtOgrSoyad";
            this.txtOgrSoyad.ReadOnly = true;
            this.txtOgrSoyad.Size = new System.Drawing.Size(244, 20);
            this.txtOgrSoyad.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ders Adı : ";
            // 
            // txtDersAdi
            // 
            this.txtDersAdi.Location = new System.Drawing.Point(136, 244);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Size = new System.Drawing.Size(244, 20);
            this.txtDersAdi.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button1.BackgroundImage = global::AnaOkuluBilisim.Properties.Resources.b1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(55, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.BackgroundImage = global::AnaOkuluBilisim.Properties.Resources.rrrr;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(217, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "Iptal";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DERSEKLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AnaOkuluBilisim.Properties.Resources.gfff;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(392, 362);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dersdatagrid);
            this.Controls.Add(this.txtDersAdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOgrSoyad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOgrAdi);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DERSEKLE";
            this.Text = "DERS EKLE";
            this.Load += new System.EventHandler(this.DERSEKLE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dersdatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrAdi;
        private System.Windows.Forms.DataGridView dersdatagrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOgrSoyad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDersAdi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}