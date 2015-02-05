namespace Wizard.IO.Forms {
    partial class FrmInitWelcome {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInitWelcome));
            btWeiter = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            txtPlayerName = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblError = new System.Windows.Forms.Label();
            lstAIPlayer = new System.Windows.Forms.ListBox();
            cboAIPlayerLevel = new System.Windows.Forms.ComboBox();
            btAddAIPlayer = new System.Windows.Forms.Button();
            btRemoveAIPlayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // btWeiter
            // 
            btWeiter.Location = new System.Drawing.Point(289, 316);
            btWeiter.Name = "btWeiter";
            btWeiter.Size = new System.Drawing.Size(94, 23);
            btWeiter.TabIndex = 1;
            btWeiter.Text = "Start !";
            btWeiter.UseVisualStyleBackColor = true;
            btWeiter.Click += new System.EventHandler(btWeiter_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(151, 108);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 13);
            label2.TabIndex = 4;
            label2.Text = "Dein Name:";
            // 
            // txtPlayerName
            // 
            txtPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPlayerName.Location = new System.Drawing.Point(220, 106);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new System.Drawing.Size(162, 20);
            txtPlayerName.TabIndex = 5;
            txtPlayerName.TextChanged += new System.EventHandler(txtPlayerName_TextChanged);
            // 
            // pictureBox1
            // 
            pictureBox1.Image = global::Wizard.Properties.Resources.card_back1;
            pictureBox1.Location = new System.Drawing.Point(15, 106);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(123, 192);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(151, 150);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 7;
            label1.Text = "Mitspieler:";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(12, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(371, 58);
            label3.TabIndex = 8;
            label3.Text = resources.GetString("label3.Text");
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Location = new System.Drawing.Point(13, 316);
            lblError.Name = "lblError";
            lblError.Size = new System.Drawing.Size(0, 17);
            lblError.TabIndex = 9;
            // 
            // lstAIPlayer
            // 
            lstAIPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstAIPlayer.FormattingEnabled = true;
            lstAIPlayer.Location = new System.Drawing.Point(154, 177);
            lstAIPlayer.Name = "lstAIPlayer";
            lstAIPlayer.Size = new System.Drawing.Size(120, 119);
            lstAIPlayer.TabIndex = 10;
            // 
            // cboAIPlayerLevel
            // 
            cboAIPlayerLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboAIPlayerLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cboAIPlayerLevel.FormattingEnabled = true;
            cboAIPlayerLevel.Items.AddRange(new object[] {
            "Test",
            "Leicht",
            "Mittel",
            "Schwer"});
            cboAIPlayerLevel.Location = new System.Drawing.Point(289, 177);
            cboAIPlayerLevel.Name = "cboAIPlayerLevel";
            cboAIPlayerLevel.Size = new System.Drawing.Size(94, 21);
            cboAIPlayerLevel.TabIndex = 11;
            // 
            // btAddAIPlayer
            // 
            btAddAIPlayer.BackColor = System.Drawing.SystemColors.Control;
            btAddAIPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btAddAIPlayer.Location = new System.Drawing.Point(289, 204);
            btAddAIPlayer.Name = "btAddAIPlayer";
            btAddAIPlayer.Size = new System.Drawing.Size(94, 23);
            btAddAIPlayer.TabIndex = 12;
            btAddAIPlayer.Text = "Hinzufügen";
            btAddAIPlayer.UseVisualStyleBackColor = false;
            btAddAIPlayer.Click += new System.EventHandler(btAddAIPlayer_Click);
            // 
            // btRemoveAIPlayer
            // 
            btRemoveAIPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btRemoveAIPlayer.Location = new System.Drawing.Point(289, 233);
            btRemoveAIPlayer.Name = "btRemoveAIPlayer";
            btRemoveAIPlayer.Size = new System.Drawing.Size(94, 23);
            btRemoveAIPlayer.TabIndex = 13;
            btRemoveAIPlayer.Text = "Entfernen";
            btRemoveAIPlayer.UseVisualStyleBackColor = true;
            btRemoveAIPlayer.Click += new System.EventHandler(btRemoveAIPlayer_Click);
            // 
            // F_InitWelcome
            // 
            AcceptButton = btWeiter;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(395, 351);
            Controls.Add(btRemoveAIPlayer);
            Controls.Add(btAddAIPlayer);
            Controls.Add(cboAIPlayerLevel);
            Controls.Add(lstAIPlayer);
            Controls.Add(lblError);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtPlayerName);
            Controls.Add(label2);
            Controls.Add(btWeiter);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "F_InitWelcome";
            Text = "Willkommen bei Wizard!";
            FormClosed += new System.Windows.Forms.FormClosedEventHandler(F_InitWelcome_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btWeiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ListBox lstAIPlayer;
        private System.Windows.Forms.ComboBox cboAIPlayerLevel;
        private System.Windows.Forms.Button btAddAIPlayer;
        private System.Windows.Forms.Button btRemoveAIPlayer;
    }
}