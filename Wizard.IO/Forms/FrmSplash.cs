using System;
using System.Windows.Forms;

namespace Wizard.IO.Forms 
{

	/// <summary>
	/// Class F_Splash<br />
	/// Stellt den Splash-Screen dar, der bei Programmstart eine bestimmte Zeit angezeigt wird.
	/// </summary>
	public partial class FrmSplash : Form 
    {

		// Die komplette Anzeigedauer (Sek.)
		private int _duration;
		// Die bereits vertrichene Zeit (Sek.)
		private int _elapsed;

		/// <summary>
		/// Konstruktor<br />
		/// Initialisiert den Splash-Screen und stellt die Anzeige-Dauer ein.
		/// </summary>
		/// <param name="duration">Anzeigedauer in Sekunden</param>
		public FrmSplash(int duration) 
        {
			InitializeComponent();
			_duration = duration;
			_elapsed = 0;

			// Progressbar einstellen
			progBarSplash.Maximum = duration * 100;
			progBarSplash.Step = (progBarSplash.Maximum / 10);

			// Timer starten
			tmrDuration.Enabled = true;
			tmrProgBar.Interval = duration * 100;
			tmrProgBar.Enabled = true;
		}

		/// <summary>
		/// Bei jedem Tick des Trimers wird geprüft, ob die <code>nDuration</code> schon erreicht wurde.
		/// In diesem Fall wird der Splash-Screen einfach wieder geschlossen.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmrShowDuration_Tick(object sender, EventArgs e) 
        {
			// Prüfen, ob die abzuwartende Zeit bereits verstrichen ist
            if (_elapsed++ >= _duration) 
            {
				Close();
            }
		}

		/// <summary>
		/// Führt einen Schritt in der Progressbar durch.
		/// Dabei werden hier (<code>nDuration</code> * 10) Schritte durchlaufen.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmrProgBar_Tick(object sender, EventArgs e) 
        {
			progBarSplash.PerformStep();
		}

	}

}