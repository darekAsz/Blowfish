namespace blowfish
{
    partial class MainPanel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Szyfracja = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recipientLB = new System.Windows.Forms.ListBox();
            this.startEnc = new System.Windows.Forms.Button();
            this.groupBoxEnc = new System.Windows.Forms.GroupBox();
            this.encModeCB = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.keyLengthCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.subblockLengthCB = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.FileEncSB = new System.Windows.Forms.Button();
            this.fileEncryptedTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fileEncCB = new System.Windows.Forms.Button();
            this.fileEncTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Deszyfracja = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recipientLB2 = new System.Windows.Forms.ListBox();
            this.passwordDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deszyfr = new System.Windows.Forms.Button();
            this.sciezka = new System.Windows.Forms.Button();
            this.DecryptedFileRoot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.encryptedFileRoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.Szyfracja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxEnc.SuspendLayout();
            this.Deszyfracja.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Szyfracja);
            this.tabControl1.Controls.Add(this.Deszyfracja);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(509, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // Szyfracja
            // 
            this.Szyfracja.BackColor = System.Drawing.SystemColors.Control;
            this.Szyfracja.Controls.Add(this.progressBar1);
            this.Szyfracja.Controls.Add(this.groupBox1);
            this.Szyfracja.Controls.Add(this.groupBoxEnc);
            this.Szyfracja.Controls.Add(this.label14);
            this.Szyfracja.Controls.Add(this.FileEncSB);
            this.Szyfracja.Controls.Add(this.fileEncryptedTB);
            this.Szyfracja.Controls.Add(this.label6);
            this.Szyfracja.Controls.Add(this.fileEncCB);
            this.Szyfracja.Controls.Add(this.fileEncTB);
            this.Szyfracja.Controls.Add(this.label5);
            this.Szyfracja.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Szyfracja.Location = new System.Drawing.Point(4, 22);
            this.Szyfracja.Name = "Szyfracja";
            this.Szyfracja.Padding = new System.Windows.Forms.Padding(3);
            this.Szyfracja.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Szyfracja.Size = new System.Drawing.Size(501, 480);
            this.Szyfracja.TabIndex = 0;
            this.Szyfracja.Text = "Szyfracja";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(112, 402);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(311, 23);
            this.progressBar1.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recipientLB);
            this.groupBox1.Controls.Add(this.startEnc);
            this.groupBox1.Location = new System.Drawing.Point(19, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 196);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odbiorcy";
            // 
            // recipientLB
            // 
            this.recipientLB.FormattingEnabled = true;
            this.recipientLB.Location = new System.Drawing.Point(6, 19);
            this.recipientLB.Name = "recipientLB";
            this.recipientLB.Size = new System.Drawing.Size(209, 160);
            this.recipientLB.TabIndex = 27;
            // 
            // startEnc
            // 
            this.startEnc.Location = new System.Drawing.Point(267, 83);
            this.startEnc.Name = "startEnc";
            this.startEnc.Size = new System.Drawing.Size(165, 38);
            this.startEnc.TabIndex = 19;
            this.startEnc.Text = "SZYFRUJ";
            this.startEnc.UseVisualStyleBackColor = true;
            this.startEnc.Click += new System.EventHandler(this.startEnc_Click);
            // 
            // groupBoxEnc
            // 
            this.groupBoxEnc.Controls.Add(this.encModeCB);
            this.groupBoxEnc.Controls.Add(this.label17);
            this.groupBoxEnc.Controls.Add(this.label8);
            this.groupBoxEnc.Controls.Add(this.label15);
            this.groupBoxEnc.Controls.Add(this.keyLengthCB);
            this.groupBoxEnc.Controls.Add(this.label10);
            this.groupBoxEnc.Controls.Add(this.label11);
            this.groupBoxEnc.Controls.Add(this.subblockLengthCB);
            this.groupBoxEnc.Location = new System.Drawing.Point(10, 90);
            this.groupBoxEnc.Name = "groupBoxEnc";
            this.groupBoxEnc.Size = new System.Drawing.Size(454, 104);
            this.groupBoxEnc.TabIndex = 26;
            this.groupBoxEnc.TabStop = false;
            this.groupBoxEnc.Text = "Ustawienia kodowania";
            // 
            // encModeCB
            // 
            this.encModeCB.FormattingEnabled = true;
            this.encModeCB.Location = new System.Drawing.Point(113, 70);
            this.encModeCB.Name = "encModeCB";
            this.encModeCB.Size = new System.Drawing.Size(79, 21);
            this.encModeCB.TabIndex = 12;
            this.encModeCB.SelectedIndexChanged += new System.EventHandler(this.encModeCB_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(421, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "bitów";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Długość klucza:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(203, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "bitów";
            // 
            // keyLengthCB
            // 
            this.keyLengthCB.FormattingEnabled = true;
            this.keyLengthCB.Location = new System.Drawing.Point(113, 35);
            this.keyLengthCB.Name = "keyLengthCB";
            this.keyLengthCB.Size = new System.Drawing.Size(79, 21);
            this.keyLengthCB.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Tryb";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(216, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Długość podbloku:";
            // 
            // subblockLengthCB
            // 
            this.subblockLengthCB.FormattingEnabled = true;
            this.subblockLengthCB.Location = new System.Drawing.Point(318, 67);
            this.subblockLengthCB.Name = "subblockLengthCB";
            this.subblockLengthCB.Size = new System.Drawing.Size(95, 21);
            this.subblockLengthCB.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 412);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Stan";
            // 
            // FileEncSB
            // 
            this.FileEncSB.Location = new System.Drawing.Point(260, 61);
            this.FileEncSB.Name = "FileEncSB";
            this.FileEncSB.Size = new System.Drawing.Size(112, 23);
            this.FileEncSB.TabIndex = 5;
            this.FileEncSB.Text = "Miejsce zapisu";
            this.FileEncSB.UseVisualStyleBackColor = true;
            this.FileEncSB.Click += new System.EventHandler(this.FileEncSB_Click);
            // 
            // fileEncryptedTB
            // 
            this.fileEncryptedTB.Enabled = false;
            this.fileEncryptedTB.Location = new System.Drawing.Point(10, 63);
            this.fileEncryptedTB.Name = "fileEncryptedTB";
            this.fileEncryptedTB.Size = new System.Drawing.Size(202, 20);
            this.fileEncryptedTB.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Zapisz jako:";
            // 
            // fileEncCB
            // 
            this.fileEncCB.Location = new System.Drawing.Point(260, 24);
            this.fileEncCB.Name = "fileEncCB";
            this.fileEncCB.Size = new System.Drawing.Size(112, 20);
            this.fileEncCB.TabIndex = 2;
            this.fileEncCB.Text = "Wybierz plik";
            this.fileEncCB.UseVisualStyleBackColor = true;
            this.fileEncCB.Click += new System.EventHandler(this.fileEncCB_Click);
            // 
            // fileEncTB
            // 
            this.fileEncTB.Enabled = false;
            this.fileEncTB.Location = new System.Drawing.Point(10, 24);
            this.fileEncTB.Name = "fileEncTB";
            this.fileEncTB.Size = new System.Drawing.Size(202, 20);
            this.fileEncTB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Plik do zaszyfrowania:";
            // 
            // Deszyfracja
            // 
            this.Deszyfracja.BackColor = System.Drawing.SystemColors.Control;
            this.Deszyfracja.Controls.Add(this.groupBox2);
            this.Deszyfracja.Controls.Add(this.deszyfr);
            this.Deszyfracja.Controls.Add(this.sciezka);
            this.Deszyfracja.Controls.Add(this.DecryptedFileRoot);
            this.Deszyfracja.Controls.Add(this.label3);
            this.Deszyfracja.Controls.Add(this.button1);
            this.Deszyfracja.Controls.Add(this.encryptedFileRoot);
            this.Deszyfracja.Controls.Add(this.label1);
            this.Deszyfracja.Location = new System.Drawing.Point(4, 22);
            this.Deszyfracja.Name = "Deszyfracja";
            this.Deszyfracja.Padding = new System.Windows.Forms.Padding(3);
            this.Deszyfracja.Size = new System.Drawing.Size(501, 480);
            this.Deszyfracja.TabIndex = 1;
            this.Deszyfracja.Text = "Deszyfracja";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.recipientLB2);
            this.groupBox2.Controls.Add(this.passwordDes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(28, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 188);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wybór odbiorcy";
            // 
            // recipientLB2
            // 
            this.recipientLB2.Location = new System.Drawing.Point(27, 34);
            this.recipientLB2.Name = "recipientLB2";
            this.recipientLB2.Size = new System.Drawing.Size(223, 121);
            this.recipientLB2.TabIndex = 28;
            // 
            // passwordDes
            // 
            this.passwordDes.Location = new System.Drawing.Point(307, 82);
            this.passwordDes.Name = "passwordDes";
            this.passwordDes.Size = new System.Drawing.Size(124, 20);
            this.passwordDes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło:";
            // 
            // deszyfr
            // 
            this.deszyfr.ForeColor = System.Drawing.Color.Red;
            this.deszyfr.Location = new System.Drawing.Point(160, 348);
            this.deszyfr.Name = "deszyfr";
            this.deszyfr.Size = new System.Drawing.Size(210, 40);
            this.deszyfr.TabIndex = 8;
            this.deszyfr.Text = "DESZYFRUJ";
            this.deszyfr.UseVisualStyleBackColor = true;
            this.deszyfr.Click += new System.EventHandler(this.deszyfr_Click);
            // 
            // sciezka
            // 
            this.sciezka.Location = new System.Drawing.Point(313, 93);
            this.sciezka.Name = "sciezka";
            this.sciezka.Size = new System.Drawing.Size(111, 24);
            this.sciezka.TabIndex = 7;
            this.sciezka.Text = "Wybierz ścieżkę";
            this.sciezka.UseVisualStyleBackColor = true;
            this.sciezka.Click += new System.EventHandler(this.sciezka_Click);
            // 
            // DecryptedFileRoot
            // 
            this.DecryptedFileRoot.Enabled = false;
            this.DecryptedFileRoot.Location = new System.Drawing.Point(25, 96);
            this.DecryptedFileRoot.Name = "DecryptedFileRoot";
            this.DecryptedFileRoot.Size = new System.Drawing.Size(250, 20);
            this.DecryptedFileRoot.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zapisz jako:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wybierz plik";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // encryptedFileRoot
            // 
            this.encryptedFileRoot.Enabled = false;
            this.encryptedFileRoot.Location = new System.Drawing.Point(25, 47);
            this.encryptedFileRoot.Name = "encryptedFileRoot";
            this.encryptedFileRoot.Size = new System.Drawing.Size(253, 20);
            this.encryptedFileRoot.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plik do odszyfrowania:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(13, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 506);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorToolStripMenuItem,
            this.opisToolStripMenuItem});
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.oProgramieToolStripMenuItem.Text = "O programie";
            // 
            // autorToolStripMenuItem
            // 
            this.autorToolStripMenuItem.Name = "autorToolStripMenuItem";
            this.autorToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.autorToolStripMenuItem.Text = "Autor";
            this.autorToolStripMenuItem.Click += new System.EventHandler(this.autorToolStripMenuItem_Click);
            // 
            // opisToolStripMenuItem
            // 
            this.opisToolStripMenuItem.Name = "opisToolStripMenuItem";
            this.opisToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.opisToolStripMenuItem.Text = "Opis";
            this.opisToolStripMenuItem.Click += new System.EventHandler(this.opisToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 459);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPanel";
            this.Text = "BlowFish";
            this.Load += new System.EventHandler(this.MainPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.Szyfracja.ResumeLayout(false);
            this.Szyfracja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxEnc.ResumeLayout(false);
            this.groupBoxEnc.PerformLayout();
            this.Deszyfracja.ResumeLayout(false);
            this.Deszyfracja.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Szyfracja;
        private System.Windows.Forms.TabPage Deszyfracja;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opisToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox encryptedFileRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sciezka;
        private System.Windows.Forms.TextBox DecryptedFileRoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordDes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deszyfr;
        private System.Windows.Forms.TextBox fileEncTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button fileEncCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fileEncryptedTB;
        private System.Windows.Forms.Button FileEncSB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox keyLengthCB;
        private System.Windows.Forms.ComboBox encModeCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox subblockLengthCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button startEnc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBoxEnc;
        private System.Windows.Forms.ListBox recipientLB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox recipientLB2;
    }
}

