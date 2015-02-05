using System;
using System.Collections;
using System.Collections.Generic;
using Wizard.Common;
using Wizard.IO;

namespace Wizard.Core
{

	/// <summary>
	/// Erstellt eine neue Spielrunde. Dabei wird eine bestimmte Zahl von Karten an jeden Spieler verteilt und am
	/// Ende der Runde werden jedem Spieler die entsprechenden Punkt gutgeschrieben oder abgezogen.
	/// Innerhalb einer Runde (<code>Round</code>) finden verschiedene Stich-Runden (<code>TrickRound</code>)
	/// statt.
	/// </summary>
	public class Round 
    {

        private List<AbstractPlayer> _players;
		private int _currentRoundNumber;
		private int _playerCount;
		private Color _trump;
		private TrickRound _currentTrickRound;
		private List<Trick> _tricks;
		private int _startPlayerIndex;
		private Hashtable _guessedTricks;
		private Hashtable _receivedTricks;
		private Hashtable _playerPoints;
        private IIOManager _ioManager;

		// Gibt den Trumpf der aktuellen Runde aus.
		public Color Trump 
        {
			get { return _trump; }
		}

		// Gibt das TrickRound-Objekt zurück, das die aktuell laufende Stichrunde repräsentiert.
		public TrickRound CurrentTrickRound 
        {
			get { return _currentTrickRound; }
		}

		// Gibt eine Liste aller Stiche aus, die in dieser Runde BISHER gespielt wurden
		public List<Trick> PlayedTricks 
        {
			get { return _tricks; }
		}

		// Gibt den Index des Spielers aus, der die Runde begonnen hat
		public int StartPlayerIndex 
        {
			get { return _startPlayerIndex; }
		}

		// Ermöglicht das Abrufen der HashTable mit den Tipps der Spieler
		public Hashtable GuessedTricks 
        {
			get { return _guessedTricks; }
		}

		// Ermöglicht das Abrufen der HashTable mit den erhaltenen Stichen aller Spieler
		public Hashtable ReceivedTricks 
        {
			get { return _receivedTricks; }
		}

		// Gibt die aktuellen Punktestände aller Spieler zurück
		public Hashtable PlayerPoints 
        {
			get { return _playerPoints; }
		}

		/// <summary>
		/// Konstruktor<br />
		/// Initialisiert alle Klassenvariablen.
		/// </summary>
		/// <param name="currentRoundNumber">Die Nummer der Runde</param>
		/// <param name="players">Eine Liste aller Spieler</param>
		/// <param name="startPlayerIndex">Der Index des Spielers, der die erste Runde beginnt</param>
        public Round(int currentRoundNumber, List<AbstractPlayer> players, int startPlayerIndex) 
        {
			// Initialisierung der Klassenvariablen
			_currentRoundNumber = currentRoundNumber;
			_players = players;
			_playerCount = players.Count;
			_trump = Color.None;
			_currentTrickRound = null;
			_tricks = new List<Trick>();
			_startPlayerIndex = startPlayerIndex;

			// HashTables initialisieren
			_guessedTricks = new Hashtable();
			_receivedTricks = new Hashtable();
			_playerPoints = new Hashtable();

            // IOManager initialisieren
            _ioManager = IOManagerFactory.GetIOManager();

            foreach (AbstractPlayer player in players) 
            {
				_receivedTricks.Add(player, 0);
			}
		}

		/// <summary>
		/// Steuert den Ablauf der Runde. Dazu werden verschiedene Schritte durchlaufen:
		///	- Verteilung der Karten
		///	- Generierung der für diese Runde relevanten Trumpf-Farbe
		///	- Start der Rate-Runde, in der die Spieler tippen müsse, wieviele Stiche sie bekommen
		///	- Eigentlicher Spielablauf der Runde; Abfolge von einzelnen Stich-Runden
		/// </summary>
		/// <param name="cards">Die verfügbaren Spielkarten</param>
		public void Start(List<Card> cards) 
        {
			// Start der neuen Runde anzeigen
            _ioManager.ProcessProceed();
            _ioManager.ProcessStartRound(_currentRoundNumber);

			// Statistik anzeigen
            _ioManager.ProcessStatistics(_players);
            _ioManager.ProcessProceed();

			// Ablauf der Runde:

			// 1.: Karten verteilen
			GiveCards(cards);

			// 2.: Karten sortieren
            foreach (AbstractPlayer player in _players)
            {
                player.SortCards(_trump);
            }
			
			// 3.: Trumpf-Farbe ermitteln (ggf. Spieler auswählen lassen)
			GenerateTrump(cards, _startPlayerIndex);
            GameScope.CS.CurrentTrump = _trump;

			// 4.: Karten Sortieren
            foreach (AbstractPlayer player in _players)
            {
                player.SortCards(_trump);
            }

			// 5.: Karten Anzeigen
            foreach (AbstractPlayer player in _players)
            {
                //player.ShowCards();
            }

			// 6.: Trumpf Anzeigen
            _ioManager.ProcessGenerateTrump(_trump);

            _ioManager.ProcessProceed();

			// 7.: Rate-Runde durchführen
			PlayGuessRound(_startPlayerIndex);

            _ioManager.ProcessProceed();

			// 8.: Eigentliche Runde spielen und Stiche speichern
			PlayTrickRounds(_startPlayerIndex);

			// 9.: Ergebnis auswerten, Punktverteilung
			EvaluateRoundResults();
		}

		/// <summary>
		/// Prozedur zum Verteilen der Karten. Dabei erhält jeder Spieler [<code>nCurrentRoundNumber</code>]
		/// Karten. Die Karten werden aus der Liste entfernt.
		/// </summary>
		/// <param name="cards">Liste aller Karten</param>
		private void GiveCards(List<Card> cards) 
        {
            _ioManager.ProcessStartGiveCards();

            foreach (AbstractPlayer player in _players)
            {
				player.NewCards(GenerateNewHand(cards));
			}
		}

		/// <summary>
		/// Hilfsmethode zum Verteilen der Karten (siehe oben). Hier wird eine Hand erzeugt, die dem Spieler dann
		/// sofort zugeordnet werden kann.
		/// </summary>
		/// <param name="cards">Liste aller Karten</param>
		/// <returns>Neue Kartenhand (als Liste)</returns>
		private List<Card> GenerateNewHand(List<Card> cards) 
        {
			List<Card> newHandCards = new List<Card>();

			for (int i = 1; i <= _currentRoundNumber; i++) 
            {
				int nextIndex = (int) Math.Floor(RandomGen.Rand.NextDouble() * cards.Count);
				newHandCards.Add(cards[nextIndex]);
				cards.RemoveAt(nextIndex);
			}

			return newHandCards;
		}

		/// <summary>
		/// Generiert die Trumpf-Farbe für diese Runde und speichert das Ergebnis in der entsprechenden
		/// Member-Variable. Die Farbe wird per Zufall ermittelt, in dem einfach eine Karte aus der Liste der
		/// nicht-verteilten Karten "gezogen" wird.
		/// Wird ein Zauberer (Kartenwert 14) gezogen, so darf der Startspieler der Runde den Trumpf bestimmen. Zu
		/// diesem Zweck muss der Listenindex des Spielers ebenfalls übergeben werden.<br />
		/// Bei einem Narr gibt es in der Runde keinen Trumpf (<code>E_Color.none</code>).
		/// </summary>
		/// <param name="cards">Liste aller übrigen Karten (NACH dem Verteilen)</param>
		/// <param name="startPlayerIndex">Der Listenindex des Startspielers</param>
		private void GenerateTrump(List<Card> cards, int startPlayerIndex) 
        {
			if (cards.Count == 0) 
            {
				// In der letzten Runde
				_trump = Color.None;
			} 
            else 
            {
				// Der Index der "gezogenen" Karte wird zufällig errechnet
				TimeSpan millis = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0));
				Random rand = new Random(millis.Milliseconds);
				int index = (int) Math.Floor(rand.NextDouble() * cards.Count);

				Card trumpCard = cards[index];

				// Prüfen, ob es sich um einen Zauberer handelt
				if (trumpCard.Value == 14) 
                {
					_trump = _players[startPlayerIndex].ChooseTrump();
				} 
                else 
                {
					_trump = trumpCard.Color;
				}
			}
		}

		/// <summary>
		/// Führt die Rate-Runde durch, in der jeder Spieler tippen muss, wieviele Stiche er in der Runde
		/// erhalten wird. Hier ist auch wieder der Listenindex des Startspielers wichtig, da er als erster
		/// raten muss. 
		/// </summary>
		/// <param name="startPlayerIndex">Der Listenindex des Startspielers</param>
		private void PlayGuessRound(int startPlayerIndex) 
        {
            _ioManager.ProcessGuessTricks();

			int j = startPlayerIndex;

			// Die Spieler werden nacheinander aufgefordert, einen Tipp abzugeben
			for (int i = 1; i <= _players.Count; i++) 
            {
				// Spieler und zugehörigen Tipp in die HashTable eintragen
				_guessedTricks.Add(_players[j], _players[j].GuessTrickCount());

                if (j + 1 == _players.Count)
                {
                    j = 0;
                }
                else
                {
                    j++;
                }
			}
		}

		/// <summary>
		/// Führt die eigentliche Spielrunde durch. Dazu werden nacheinander einzelne Stichrunden durchgeführt.
		/// Die ermittelten Stiche werden dem Spieler zugeordnet und gespeichert.
		/// </summary>
		/// <param name="nIndex">Der Index des Startspielers, der die erste Stichrunde beginnt</param>
		private void PlayTrickRounds(int nIndex) 
        {
			int startPlayerIndex = nIndex;

			for (int i = 1; i <= _currentRoundNumber; i++) 
            {
                _ioManager.ProcessTrickRoundStart(_players[startPlayerIndex], _trump);

				// Stichrunde erstellen und spielen
				_currentTrickRound = new TrickRound(startPlayerIndex, _players, _trump, this);
				Trick trick = _currentTrickRound.PlayTrickRound();

				// Anzahl der erhaltenen Stiche für den Spieler inkrementieren
				_receivedTricks[trick.Player] = Int32.Parse(_receivedTricks[trick.Player].ToString()) + 1;

                _ioManager.ProcessShowTrick(trick);
                _ioManager.ProcessProceed();

				// Den Startspieler für die nächste Stichrunde festlegen
				startPlayerIndex = _players.IndexOf(trick.Player);

				// Der Stich wird in der Runde gespeichert
				_tricks.Add(trick);
			}
		}

		/// <summary>
		/// Wertet das Ergebnis der Runde aus.
		/// Die Spieler bekommen eine entsprechende Anzahl von Punkten zugesprochen (oder abgezogen).
		/// 
		/// Richtig geraten:
		/// - Anzahl der Stiche richtig erraten: 2 Punkte (statisch)
		/// - 1 Punkt für jeden erhaltenen Stich
		/// 
		/// Falsch geraten:
		/// - Punkte abziehen, Anzahl entspricht der Differenz zwischen geratenen und erhaltenen Stichen
		/// </summary>
		private void EvaluateRoundResults() 
        {
            _ioManager.ProcessEvaluateRound(_currentRoundNumber);

			// Nacheinander werden für jeden Spieler die Punkte ermittelt
			int guessedTrickCount = 0;
			int receivedTrickCount = 0;
            foreach (AbstractPlayer player in _players) 
            {
				// Getippt und erhaltene Stiche des Spielers extrahieren
				guessedTrickCount = Int32.Parse(_guessedTricks[player].ToString());
				receivedTrickCount = Int32.Parse(_receivedTricks[player].ToString());

				// Prüfen, ob der Spieler richtig geraten hat
				int points = 0;
				if (guessedTrickCount == receivedTrickCount) 
                {
					points = guessedTrickCount + 2;
				} 
                else 
                {
					points = Math.Abs(guessedTrickCount - receivedTrickCount) * (-1);
				}

				player.AddPoints(points);

                _ioManager.ProcessEvaluatePlayer(player, guessedTrickCount, receivedTrickCount, points);

				_playerPoints.Add(player, player.Points);
			}

            _ioManager.ProcessProceed();
		}

	}

}