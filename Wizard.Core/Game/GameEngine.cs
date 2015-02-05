using System;
using System.Collections.Generic;
using Wizard.Common;
using Wizard.IO;
using Wizard.AI;

namespace Wizard.Core 
{

	/// <summary>
	/// Steuert den Spielablauf.
	/// </summary>
	public class GameEngine 
	{

		private List<Card> _allCards;
		private List<AbstractPlayer> _players;
		private List<Round> _rounds;
		private int _playerCount;
		private int _roundCount;
		private bool _cpuPlayersOnly;
        private IIOManager _ioManager;

		// Gibt die aktuelle Runde zurück
		public Round CurrentRound 
		{
			get { return GetCurrentRound(); }
		}

		// Gibt an, ob es ausschließlich Computerspieler gibt
		public bool CpuPlayersOnly 
		{
			get { return _cpuPlayersOnly; }
		}

		// Gibt die Anzahl der Spieler aus (kann nicht verändert werden)
		public int PlayerCount 
		{
			get { return _playerCount; }
		}

		// Gibt die Liste aller teilnehmenden Spieler aus
		public List<AbstractPlayer> Players 
		{
			get { return _players; }
		}

		/// <summary>
		/// Default-Konstruktor.
		/// </summary>
		public GameEngine() : this(false) { }

		/// <summary>
		/// Konstruktor<br />
		/// Stellt die wichtigen Klassenvariablen ein und startet das Spiel.
		/// Als Parameter wird hier die Anzahl der teilnehmenden Spieler übergeben. Dort sind sowohl alle
		/// AI-Spieler als auch der menschliche Spieler enthalten.
		/// </summary>
		/// <param name="nPlayerCount">Anzahl der Spieler, die am Spiel teilnehmen (HP + AI)</param>
		/// <param name="cpuPlayersOnly">Schalter; falls TRUE, spielen nur CPU-Spieler gegeneinander</param>
		public GameEngine(bool cpuPlayersOnly) 
		{
			// Member initialisieren
			_players = new List<AbstractPlayer>();
			_rounds = new List<Round>();
			_cpuPlayersOnly = cpuPlayersOnly;

            // IOManager initialisieren
            _ioManager = IOManagerFactory.GetIOManager();

            // Namens-Generator initialisieren
            NameGen gen = new NameGen();

			// Willkommens-Informationen anzeigen und Spieleranzahl erfragen
			_ioManager.ProcessWelcome();
			int playerCount = _ioManager.GetPlayerCount();

			// Prüfen, ob ein menschlicher Spieler teilnahmen soll
			string humanPlayerName = "Testspieler";
            int aiPlayerLevel = 0;
			if (!cpuPlayersOnly) 
			{
				// Menschlichen Spieler erstellen
				humanPlayerName = _ioManager.GetPlayerName();
				_players.Add(new HumanPlayer(humanPlayerName, 0));
			} 
			else 
			{
				// Ersten AI-Spieler erstellen
				aiPlayerLevel = _ioManager.GetAILevel(0);
				_players.Add(new AIPlayer(gen.GenerateName(), 0, aiPlayerLevel, null));
			}

			// Restliche AI-Spieler erstellen
			for(int i = 1; i <= (playerCount - 1); i++) 
			{
				aiPlayerLevel = _ioManager.GetAILevel(i);
				_players.Add(new AIPlayer(gen.GenerateName(), i, aiPlayerLevel, null));
			}

			// Variablen setzen
			_playerCount = playerCount;
			_roundCount = 60 / playerCount;
		}

        /// <summary>
        /// Startet das Spiel. Dazu werden nacheinander einzelnen Runden erstellt und gestartet, bis die 
        /// Anzahl der Runden erreicht ist (Rundenanzahl = 60 / Spieleranzahl)
        /// </summary>
        public void Start()
        {
            // Start durchführen und alle Spieler anzeigen
            _ioManager.ProcessProceed();
            _ioManager.ProcessStart();
            _ioManager.ProcessListPlayers(_players);
            _ioManager.ProcessProceed();

            for (int i = 1; i <= _roundCount; i++)
            {
                InitAllCardsList();

                // Runde erstellen
                Round currentRound = new Round(i, _players, GetStartingPlayerIndex());

                // Runde speichern
                _rounds.Add(currentRound);

                // Runde starten
                currentRound.Start(_allCards);
            }
        }

        /// <summary>
        /// Abschließende Operationen (nach dem eigentlichen Spielende) durchführen.
        /// </summary>
        public void Finish()
        {
            // Gewinner und Statistiken anzeigen und das Spiel beenden
            _ioManager.ProcessStatistics(_players);
            _ioManager.ProcessEndOfGame(GetWinningPlayer());
            _ioManager.ProcessStatistics(_players);
        }

		/// <summary>
		/// Initialisiert alle Spielkarten und trägt sie in ein spezielle Liste ein, 
		/// die Klassenweit verfügbar ist.
		/// </summary>
		private void InitAllCardsList() 
		{
			_ioManager.ProcessInitCards();

			// Liste erstellen
			_allCards = new List<Card>();
			
			// Karten in verschiedenen Farben eintragen
			for(int i = 1; i <= 13; i++) 
			{
				_allCards.Add(new Card(Color.Red, i));
			}

			for(int i = 1; i <= 13; i++)
			{
				_allCards.Add(new Card(Color.Yellow, i));
			}

			for(int i = 1; i <= 13; i++)
			{
				_allCards.Add(new Card(Color.Green, i));
			}

			for(int i = 1; i <= 13; i++) 
			{
				_allCards.Add(new Card(Color.Blue, i));
			}

			// Narren eintragen
			for (int i = 1; i <= 4; i++ ) 
			{
				_allCards.Add(new Card(Color.None, 0));
			}
			
			// Zauberer eintragen
			for (int i = 1; i <= 4; i++ ) 
			{
				_allCards.Add(new Card(Color.None, 14));
			}
		}

		/// <summary>
		/// Gibt die aktuell laufende Runde zurück. Wenn keine Runde läuft, liefert die Methode NULL.
		/// </summary>
		/// <returns>Die aktuelle Runde oder NULL</returns>
		private Round GetCurrentRound() 
		{
			if (_rounds != null && _rounds.Count > 0)
			{
				return _rounds[_rounds.Count - 1];
			}

			return null;
		}

		/// <summary>
		/// Ermittelt den Listenindex des Spielers, der die nächste Runde beginnen soll.
		/// Mit Hilfe des erhaltenen Wertes kann das <code>C_Player</code>-Objekt direkt aus der Liste
		/// abgerufen werden.
		/// </summary>
		/// <returns>Der Index als int</returns>
		private int GetStartingPlayerIndex() 
		{
			if (_rounds.Count == 0) 
			{
				// Zufalls-Index erzeugen
				TimeSpan millis = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0));
				Random rand = new Random(millis.Milliseconds);
				int nIndex = (int)Math.Floor(rand.NextDouble() * _players.Count);

				return nIndex;
			} 
			else 
			{
				// Den Index des Start-Spielers der vorherigen Runde ermitteln
				int lastRoundStartPlayerIndex = _rounds[_rounds.Count - 1].StartPlayerIndex;
				
				// Den nächsten Spieler in der Liste ermitteln
				if (lastRoundStartPlayerIndex == _players.Count - 1)
				{
					return 0;
				}
				else
				{
					return lastRoundStartPlayerIndex + 1;
				}
			}
		}

		/// <summary>
		/// Ermittelt den Gewinner des Spiels (oder denjenigen, der momentan die meisten Punkte hat).
		/// </summary>
		/// <returns>Der führende Spieler</returns>
		private AbstractPlayer GetWinningPlayer() 
		{
			AbstractPlayer winner = _players[0];

			for (int i = 1; i < _players.Count; i++) 
			{
				if (_players[i].Points > winner.Points) 
				{
					winner = _players[i];
				}
			}

			return winner;
		}

	}

}