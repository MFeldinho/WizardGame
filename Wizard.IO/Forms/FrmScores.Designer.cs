namespace Wizard.IO.Forms {
    partial class FrmScores {
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
            btOK = new System.Windows.Forms.Button();
            lstBoxPlayers = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // btOK
            // 
            btOK.Location = new System.Drawing.Point(214, 176);
            btOK.Name = "btOK";
            btOK.Size = new System.Drawing.Size(75, 23);
            btOK.TabIndex = 1;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += new System.EventHandler(btOK_Click);
            // 
            // lstBoxPlayers
            // 
            lstBoxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lstBoxPlayers.FormattingEnabled = true;
            lstBoxPlayers.ItemHeight = 25;
            lstBoxPlayers.Location = new System.Drawing.Point(13, 13);
            lstBoxPlayers.MultiColumn = true;
            lstBoxPlayers.Name = "lstBoxPlayers";
            lstBoxPlayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            lstBoxPlayers.Size = new System.Drawing.Size(276, 154);
            lstBoxPlayers.TabIndex = 2;
            // 
            // F_Scores
            // 
            AcceptButton = btOK;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(301, 211);
            Controls.Add(lstBoxPlayers);
            Controls.Add(btOK);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "F_Scores";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Aktueller Spielstand";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ListBox lstBoxPlayers;
    }
}