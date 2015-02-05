using System.Collections.Generic;
using Wizard.Common;
using Wizard.IO;

namespace Wizard.Core
{

	/// <summary>
	/// Repräsentiert eine Stich-Runde. In einer solchen Runde legt jeder Spieler genau eine Karte. Die gelegten
	/// Karten werden in einem neu erzeugten <code>Trick</code>-Objekt eingetragen.
	/// Nachdem alle Spieler eine Karte gelegt haben, wird der aktuelle Stich ausgewertet. Der Spieler, der den 
	/// Stich erhalten hat, wird nun ebenfalls im Stich eingetragen. Abschließend wird der Stich in der Runde
	/// <code>Round</code> gespeichert.
	/// </summary>
	public class TrickRound 
    {

		private int _startPlayerIndex;
		private List<AbstractPlayer> _players;
		private Trick _trick;
		private Color _playColor;
		private Color _trump;
		private Round _round;
		private Card _currentHighestCard;
        private IIOManager _ioManager;
		
		// Gibt den Stich zurück, der in dieser Stichrunde gespielt wird
		public Trick Trick 
        {
			get { return _trick; }
		}

		// Gibt die Spielfarbe dieser Stichrunde zurück
		public Color PlayColor 
        {
			get { return _playColor; }
		}

		// Gibt die Runde aus, zu der diese Stichrunde gehört
		public Round Round 
        {
			get { return _round; }
		}

		// Gibt die Karte aus, die momentan den Stich gewinnen würde
		public Card CurrentHighestCard 
        {
			get { return _currentHighestCard; }
		}

		/// <summary>
		/// Konstruktor<br />
		/// Initialisiert die Klassenmember.
		/// </summary>
		/// <param name="startPlayerIndex">Der Index des Spielers, der die erste Karte aufspielt</param>
		/// <param name="_players">Liste aller Spieler</param>
		/// <param name="trump">Die für die gesamte Runde geltende Trumpf-Farbe</param>
        public TrickRound(int startPlayerIndex, List<AbstractPlayer> players, Color trump, Round round) 
        {
			_startPlayerIndex = startPlayerIndex;
			_players = players;
			_trick = new Trick();
			_playColor = Color.Undefined;
			_trump = trump;
			_round = round;
			_currentHighestCard = null;

            // IOManager initialisieren
            _ioManager = IOManagerFactory.GetIOManager();
		}

		/// <summary>
		/// Ablauf einer einzelnen Stich-Runde.
		/// </summary>
		/// <returns>Der in der Stich-Runde entstandene Stich (komplett mit Karten + Spieler)</returns>
		public Trick PlayTrickRound() 
        {
			int j = _startPlayerIndex;

			// Spieler nacheinander durchgehen (beginnend beim Startspieler) und zum legen einer Karte auffordern
			for (int i = 0; i < _players.Count; i++) 
            {
				Card newCard = _players[j].PlayCard();
                _ioManager.ProcessPlayerPlayCard(_players[j], newCard);

				_trick.Add(newCard);
				_currentHighestCard = GetHigherCard(_currentHighestCard, newCard, _trump, _playColor);

                if (j + 1 == _players.Count)
                {
                    j = 0;
                }
                else
                {
                    j++;
                }
				
				// Festlegen der Spielfarbe (falls sie noch undefiniert ist)
				if (_playColor == Color.Undefined) 
                {
					if (newCard.Value == 0)
                    {
						_playColor = Color.Undefined;
					} 
                    else 
                    {
						_playColor = newCard.Color;
					}
				}
			}

			// Stich-Spieler ermitteln und setzen
			_trick.Player = GetTrickPlayer();

			return _trick;
		}

		/// <summary>
		/// Ermittelt den Spieler, der den aktuellen Stich gewonnen hat.
		/// Durch die Prüfung aller gespielten Karten wird die gewinnende Karte herausgesucht. Nachfolgend wird
		/// der Spieler ermittelt, der die entsprechende Karte aufgespielt hat.
		/// </summary>
		/// <returns>Spieler, der den Stich gewonnen hat oder NULL bei einem Fehler</returns>
        private AbstractPlayer GetTrickPlayer() 
        {
			// Prüfen, ob im Stich die korrekte Anzahl von Karten vorhanden ist (= Anzahl der Spieler)
            if (_trick.CardCount != _players.Count)
            {
                return null;
            }

			Card card = CurrentHighestCard;
			int nCardIndex = -1;
			for (int i = 0; i < _trick.CardCount; i++) 
            {
				if (card.Equals(_trick.Get(i))) 
                {
					nCardIndex = i;
					break;
				}
			}

			// Den Spieler suchen, der die Sieg-Karte gespielt hat
			int j = _startPlayerIndex;
			for (int i = 0; i < _players.Count; i++) 
            {
                if (nCardIndex == i)
                {
                    return _players[j];
                }

                if (j + 1 == _players.Count)
                {
                    j = 0;
                }
                else
                {
                    j++;
                }
			}

			// Dieser Punkt sollte niemals erreicht werden
			return null;
		}
		
		/// <summary>
		/// Sucht die höhere Karte
		/// </summary>
		/// <param name="currentHighestCard">1. Karte die verglichen wird</param>
		/// <param name="newCard">2. Karte die verglichen wird</param>
		/// <param name="trump">Trumpffarbe</param>
		/// <param name="playColor">Spielfarbe</param>
		/// <returns>Höhere Karte wird zurückgegeben</returns>
		private Card GetHigherCard(Card currentHighestCard, Card newCard, Color trump, Color playColor) 
        {
			// erste Karte im Stich
            if (currentHighestCard == null)
            {
                return newCard;
            }

			// Zauberer
            if (currentHighestCard.Value == 14)
            {
                return currentHighestCard;
            }
            if (newCard.Value == 14)
            {
                return newCard;
            }

			// höchste Karte mit Trumpffarbe suchen
			if (currentHighestCard.Color == trump || newCard.Color == trump) 
            {
				if (currentHighestCard.Color == trump && newCard.Color == trump) 
                {
					if (currentHighestCard.Value >= newCard.Value) 
                    {
						return currentHighestCard;
					}
					else 
                    {
						return newCard;
					}
				}
				else if (currentHighestCard.Color == trump) 
                {
					return currentHighestCard;
				}
				else 
                {
					return newCard;
				}
			}
			
			// Höchste Karte mit Spielfarbe suchen
			if (currentHighestCard.Color == playColor || newCard.Color == playColor) 
            {
				if (currentHighestCard.Color == playColor && newCard.Color == playColor) 
                {
					if (currentHighestCard.Value >= newCard.Value) 
                    {
						return currentHighestCard;
					}
					else 
                    {
						return newCard;
					}
				}
				else if (currentHighestCard.Color == playColor) 
                {
					return currentHighestCard;
				}
				else 
                {
					return newCard;
				}
			}

			// Dieser Punkt sollte niemals erreicht werden 
			return currentHighestCard;
		}

	}

}