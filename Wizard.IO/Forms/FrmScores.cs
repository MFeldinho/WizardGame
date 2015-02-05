using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wizard.Common;

namespace Wizard.IO.Forms
{

    /// <summary>
    /// Class F_Scores<br />
    /// Formular, das den aktuellen Punktestand anzeigt.
    /// </summary>
    public partial class FrmScores : Form 
    {

        /// <summary>
        /// Konstruktor<br />
        /// Füllt die Spielerliste und ordnet die aktuelle Punktzahl zu.
        /// </summary>
        /// <param name="lstPlayers">Liste aller teilnehmenden Spieler</param>
        public FrmScores(List<AbstractPlayer> lstPlayers) 
        {
            InitializeComponent();

            foreach(AbstractPlayer player in lstPlayers) 
            {
                lstBoxPlayers.Items.Add(player.Name + ": " + player.Points + " Punkte");
            }
        }

        /// <summary>
        /// Beim Klicken auf OK wird das Formular geschlossen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e) 
        {
            Close();
        }

    }

}