namespace Wizard.IO.Forms {
	partial class FrmMain3p {
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
            mnuMain = new System.Windows.Forms.MenuStrip();
            spielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statMain = new System.Windows.Forms.StatusStrip();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            spielToolStripMenuItem});
            mnuMain.Location = new System.Drawing.Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new System.Drawing.Size(911, 24);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "menuStrip1";
            // 
            // spielToolStripMenuItem
            // 
            spielToolStripMenuItem.Name = "spielToolStripMenuItem";
            spielToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            spielToolStripMenuItem.Text = "Spiel";
            // 
            // statMain
            // 
            statMain.Location = new System.Drawing.Point(0, 676);
            statMain.Name = "statMain";
            statMain.Size = new System.Drawing.Size(911, 22);
            statMain.TabIndex = 1;
            statMain.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(189, 496);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(74, 101);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // F_Main3p
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Green;
            ClientSize = new System.Drawing.Size(911, 698);
            Controls.Add(pictureBox1);
            Controls.Add(statMain);
            Controls.Add(mnuMain);
            MainMenuStrip = mnuMain;
            MaximizeBox = false;
            Name = "F_Main3p";
            Text = "Wizard - 3 Spieler";
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ResumeLayout(false);
            PerformLayout();

		}

		#endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem spielToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statMain;
        private System.Windows.Forms.PictureBox pictureBox1;
	}
}