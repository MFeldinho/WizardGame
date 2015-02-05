namespace Wizard.IO.Forms {
	partial class FrmSplash {
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
			components = new System.ComponentModel.Container();
			picSplash = new System.Windows.Forms.PictureBox();
			tmrDuration = new System.Windows.Forms.Timer(components);
			progBarSplash = new System.Windows.Forms.ProgressBar();
			label1 = new System.Windows.Forms.Label();
			tmrProgBar = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)(picSplash)).BeginInit();
			SuspendLayout();
			// 
			// picSplash
			// 
			picSplash.Image = global::Wizard.Properties.Resources.splashscreen1;
			picSplash.Location = new System.Drawing.Point(12, 12);
			picSplash.Name = "picSplash";
			picSplash.Size = new System.Drawing.Size(440, 567);
			picSplash.TabIndex = 0;
			picSplash.TabStop = false;
			// 
			// tmrDuration
			// 
			tmrDuration.Interval = 1000;
			tmrDuration.Tick += new System.EventHandler(tmrShowDuration_Tick);
			// 
			// progBarSplash
			// 
			progBarSplash.Location = new System.Drawing.Point(13, 617);
			progBarSplash.Name = "progBarSplash";
			progBarSplash.Size = new System.Drawing.Size(439, 22);
			progBarSplash.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.Location = new System.Drawing.Point(169, 591);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(117, 13);
			label1.TabIndex = 2;
			label1.Text = "Das Spiel startet ...";
			// 
			// tmrProgBar
			// 
			tmrProgBar.Tick += new System.EventHandler(tmrProgBar_Tick);
			// 
			// F_Splash
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(464, 656);
			Controls.Add(label1);
			Controls.Add(progBarSplash);
			Controls.Add(picSplash);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "F_Splash";
			SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(picSplash)).EndInit();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picSplash;
		private System.Windows.Forms.Timer tmrDuration;
		private System.Windows.Forms.ProgressBar progBarSplash;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer tmrProgBar;
	}
}