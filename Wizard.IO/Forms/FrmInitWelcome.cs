using System;
using System.Windows.Forms;

namespace Wizard.IO.Forms 
{

    public partial class FrmInitWelcome : Form 
    {

        private int[] nAIPlayer;
        private bool noExit;

        // Ermittelt den Inhalt der Spielernamen-Textbox
        public string PlayerName
        {
            get { return txtPlayerName.Text; }
        }

        // Ermittelt das Array, in dem die Anzahl und Level der AI-Spieler gespeichert sind
        public int[] AIPlayer 
        {
            get { return nAIPlayer; }
        }

        /// <summary>
        /// Konstruktor<br />
        /// Initialisiert Steuerelemente und Klassenmember.
        /// </summary>
        public FrmInitWelcome() 
        {
            InitializeComponent();

            // Schalter, der beim Schließen des Formulars geprüft werden muss
            noExit = false;

            // ComboBox einstellen
            cboAIPlayerLevel.SelectedIndex = 1;

            // Standard-Einträge in die ListBox eintragen
            lstAIPlayer.Items.Add(1);
            lstAIPlayer.Items.Add(1);
            lstAIPlayer.SelectedIndex = 0;
        }

        private void btWeiter_Click(object sender, EventArgs e)
        {
            if (txtPlayerName.Text == null || txtPlayerName.Text.Equals("")) 
            {
                lblError.Text = "Bitte gib deinen Namen ein!";
            } 
            else 
            {
                // Inhalt der ListBox in das vorgesehene Array übertragen
                nAIPlayer = new int[lstAIPlayer.Items.Count];
                for (int i = 0; i < lstAIPlayer.Items.Count; i++) {
                    nAIPlayer[i] = (int) lstAIPlayer.Items[i];
                }

                // Schalter setzen (Programm nicht beenden)
                noExit = true;

                // Formular schließen
                Close();
            }
        }

        private void btAddAIPlayer_Click(object sender, EventArgs e) 
        {
            lstAIPlayer.Items.Add(cboAIPlayerLevel.SelectedIndex);
            btRemoveAIPlayer.Enabled = true;

            if (lstAIPlayer.Items.Count == 5) 
            {
                btAddAIPlayer.Enabled = false;
            }
        }

        private void btRemoveAIPlayer_Click(object sender, EventArgs e) 
        {
            lstAIPlayer.Items.RemoveAt(lstAIPlayer.SelectedIndex);
            lstAIPlayer.SelectedIndex = 0;
            btAddAIPlayer.Enabled = true;

            if (lstAIPlayer.Items.Count == 2) 
            {
                btRemoveAIPlayer.Enabled = false;
            }
        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e) 
        {
            lblError.Text = String.Empty;
        }

        private void F_InitWelcome_FormClosed(object sender, FormClosedEventArgs e) 
        {
            if (!noExit)
            {
                Environment.Exit(1);
            }
        }

    }

}