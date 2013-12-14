namespace AnaOkuluBilisim
{
    partial class ChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.lbluserid = new System.Windows.Forms.Label();
            this.txtconfirmpwd = new System.Windows.Forms.TextBox();
            this.txtnewpwd = new System.Windows.Forms.TextBox();
            this.txtoldpwd = new System.Windows.Forms.TextBox();
            this.btncreatepwd = new System.Windows.Forms.Button();
            this.btnresetpwd = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Information = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtuserid
            // 
            this.txtuserid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtuserid.Location = new System.Drawing.Point(125, 25);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.Size = new System.Drawing.Size(265, 20);
            this.txtuserid.TabIndex = 1;
            this.txtuserid.Enter += new System.EventHandler(this.txtuserid_Enter);
            // 
            // lbluserid
            // 
            this.lbluserid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbluserid.AutoSize = true;
            this.lbluserid.BackColor = System.Drawing.Color.Transparent;
            this.lbluserid.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserid.ForeColor = System.Drawing.Color.Black;
            this.lbluserid.Location = new System.Drawing.Point(-15, 31);
            this.lbluserid.Name = "lbluserid";
            this.lbluserid.Size = new System.Drawing.Size(0, 14);
            this.lbluserid.TabIndex = 18;
            // 
            // txtconfirmpwd
            // 
            this.txtconfirmpwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtconfirmpwd.Location = new System.Drawing.Point(125, 106);
            this.txtconfirmpwd.Name = "txtconfirmpwd";
            this.txtconfirmpwd.PasswordChar = '*';
            this.txtconfirmpwd.Size = new System.Drawing.Size(265, 20);
            this.txtconfirmpwd.TabIndex = 4;
            this.txtconfirmpwd.Enter += new System.EventHandler(this.txtconfirmpwd_Enter);
            // 
            // txtnewpwd
            // 
            this.txtnewpwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtnewpwd.Location = new System.Drawing.Point(125, 80);
            this.txtnewpwd.Name = "txtnewpwd";
            this.txtnewpwd.PasswordChar = '*';
            this.txtnewpwd.Size = new System.Drawing.Size(265, 20);
            this.txtnewpwd.TabIndex = 3;
            this.txtnewpwd.Enter += new System.EventHandler(this.txtnewpwd_Enter);
            // 
            // txtoldpwd
            // 
            this.txtoldpwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtoldpwd.Location = new System.Drawing.Point(125, 54);
            this.txtoldpwd.Name = "txtoldpwd";
            this.txtoldpwd.PasswordChar = '*';
            this.txtoldpwd.Size = new System.Drawing.Size(265, 20);
            this.txtoldpwd.TabIndex = 2;
            this.txtoldpwd.Enter += new System.EventHandler(this.txtoldpwd_Enter);
            // 
            // btncreatepwd
            // 
            this.btncreatepwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncreatepwd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncreatepwd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncreatepwd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btncreatepwd.Location = new System.Drawing.Point(52, 295);
            this.btncreatepwd.Name = "btncreatepwd";
            this.btncreatepwd.Size = new System.Drawing.Size(152, 25);
            this.btncreatepwd.TabIndex = 5;
            this.btncreatepwd.Text = "&Create";
            this.btncreatepwd.UseVisualStyleBackColor = false;
            this.btncreatepwd.Click += new System.EventHandler(this.btncreatepwd_Click_1);
            // 
            // btnresetpwd
            // 
            this.btnresetpwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnresetpwd.BackColor = System.Drawing.SystemColors.Info;
            this.btnresetpwd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnresetpwd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnresetpwd.Location = new System.Drawing.Point(216, 295);
            this.btnresetpwd.Name = "btnresetpwd";
            this.btnresetpwd.Size = new System.Drawing.Size(152, 25);
            this.btnresetpwd.TabIndex = 6;
            this.btnresetpwd.Text = "&Reset";
            this.btnresetpwd.UseVisualStyleBackColor = false;
            this.btnresetpwd.Click += new System.EventHandler(this.btnresetpwd_Click_1);
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnexit.BackColor = System.Drawing.SystemColors.Info;
            this.btnexit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnexit.Location = new System.Drawing.Point(375, 295);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(152, 25);
            this.btnexit.TabIndex = 7;
            this.btnexit.Text = "&Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(195, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "SİFREYİ DEĞİŞTİR";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aquamarine;
            this.groupBox1.BackgroundImage = global::AnaOkuluBilisim.Properties.Resources.gfff;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPwd);
            this.groupBox1.Controls.Add(this.txtuserid);
            this.groupBox1.Controls.Add(this.txtconfirmpwd);
            this.groupBox1.Controls.Add(this.lbluserid);
            this.groupBox1.Controls.Add(this.txtnewpwd);
            this.groupBox1.Controls.Add(this.txtoldpwd);
            this.groupBox1.Location = new System.Drawing.Point(52, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Information});
            this.statusStrip1.Location = new System.Drawing.Point(0, 374);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(602, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Information
            // 
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(0, 17);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "KULLANICI ADI";
            // 
            // lblPwd
            // 
            this.lblPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPwd.AutoSize = true;
            this.lblPwd.BackColor = System.Drawing.Color.Transparent;
            this.lblPwd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.ForeColor = System.Drawing.Color.Black;
            this.lblPwd.Location = new System.Drawing.Point(5, 57);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(45, 13);
            this.lblPwd.TabIndex = 20;
            this.lblPwd.Text = "SİFRE";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "YENİ SİFRE";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "SİFREYİ ONAYLA";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.BackgroundImage = global::AnaOkuluBilisim.Properties.Resources.gfff;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(602, 396);
            this.Controls.Add(this.btnresetpwd);
            this.Controls.Add(this.btncreatepwd);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.Label lbluserid;
        private System.Windows.Forms.TextBox txtconfirmpwd;
        private System.Windows.Forms.TextBox txtnewpwd;
        private System.Windows.Forms.TextBox txtoldpwd;
        private System.Windows.Forms.Button btncreatepwd;
        private System.Windows.Forms.Button btnresetpwd;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Information;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPwd;
    }
}