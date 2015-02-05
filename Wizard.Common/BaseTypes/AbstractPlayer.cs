using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizard.Common
{

	/// <summary>
	/// Abstrakte Klasse, die einen Spieler darstellt.
	/// </summary>
    [Serializable]
	public abstract class AbstractPlayer 
	{

		protected bool _isHumanPlayer; 
		protected List<Card> _cards;
		protected string _name;
		protected int _playerNumber;
		protected int _points;

		/// <summary>
		/// Der Spielername
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Die Nummer des Spielers (muss bei allen Spielern eindeutig sein).
		/// </summary>
		public int PlayerNumber 
		{
			get { return _playerNumber; }
		}

		/// <summary>
		/// Der aktuelle Punktestand des Spielers.
		/// </summary>
		public int Points 
		{
			get { return _points; }
		}

		/// <summary>
		/// Gibt an, ob es sich um einen menschlichen Spieler handelt oder nicht.
		/// </summary>
		public bool IsHumanPlayer
		{
			get { return _isHumanPlayer; }
		}

		/// <summary>
		/// Konstruktor.
		/// Initilisiert die verschiedenen Klassenmember.
		/// </summary>
		/// <param name="name">Der Name des Spielers</param>
		/// <param name="playerNumber">Die eindeutige Nummer des Spielers (Index)</param>
		/// <param name="isHumanPlayer">Gibt an, ob es sich um einen menschlichen Spieler handelt</param>
		public AbstractPlayer(string name, int playerNumber, bool isHumanPlayer) 
		{
			_name = name;
			_playerNumber = playerNumber;
			_isHumanPlayer = isHumanPlayer;
			_points = 0;
			_cards = new List<Card>();
		}

		/// <summary>
		/// Übergibt dem Spieler eine neue Kartenhand. Die bisherigen Karten des Spielers werden überschrieben.
		/// </summary>
		/// <param name="newCards">Liste der neuen Handkarten</param>
		public void NewCards(List<Card> newCards) 
		{
			_cards.Clear();

			foreach (Card card in newCards)
			{
				_cards.Add(card);
			}
		}

		/// <summary>
		/// Sortiert die Handkarten des Spielers ABSTEIGEND.
		/// </summary>
		/// <param name="trump">Trumpffarbe</param>
		public void SortCards(Color trump) 
		{
			CardComparer cc = new CardComparer(trump);
            _cards.OrderByDescending(c => c, cc);
		}
		
		/// <summary>
		/// Ermittelt, welche Karten der Spieler aus seiner aktuellen Hand überhaupt spielen kann
		/// bzw. darf. Dies erleichert die Auswahl.
		/// Die Methode gibt eine Liste mit <code>Card</code>-Objekten zurück, die die
		/// spielbaren Karten enthält.
		/// </summary>
		/// <param name="currentTrick">Der aktuelle Stich</param>
		/// <param name="currentPlayColor">Die aktuelle Spielfarbe</param>
		/// <returns>Liste mit spielbaren Karten</returns>
		protected List<Card> GetPlayableCards(Trick currentTrick, Color currentPlayColor) 
		{
			List<Card> playableCards = new List<Card>();

			// alle Spielfarben
			foreach (Card card in _cards)
			{
				if (currentPlayColor == card.Color) 
				{
					playableCards.Add(card);
				}
			}
			// wenn keine Spielfarbe auf Hand, dann alle Karten
			if (playableCards.Count == 0) 
			{
				foreach (Card card in _cards)
				{
					playableCards.Add(card);
				}
			} 
			else 
			{
				// Zauberer & Narren hinzufügen
				foreach (Card card in _cards) 
				{
					if (card.Color == Color.None) 
					{
						playableCards.Add(card);
					}
				}
			}

			return playableCards;
		}

		/// <summary>
		/// Addiert die angegebene Anzahl von Punkten zum Gesamtpunktestand des Spielers.
		/// Hier können auch negative Werte angegeben werden, falls der Spieler sich verschätzt hat.
		/// </summary>
		/// <param name="points">Anzahl der zu addierenden Punkte (auch negative Zahlen möglich!)</param>
		public void AddPoints(int points) 
		{
			_points += points;
		}

		/// <summary>
		/// Wählt die Trump-Farbe für die aktuelle Runde.
		/// </summary>
		/// <returns>Die gewählte Trump-Farbe</returns>
		public abstract Color ChooseTrump();

		/// <summary>
		/// Rät die Anzahl der Stiche, die der Spieler in der aktuellen Runde bekommen wird.
		/// </summary>
		/// <returns>Die getippt Anzahl von Stichen</returns>
		public abstract int GuessTrickCount();

		/// <summary>
		/// Spielt die nächste Karte.
		/// </summary>
		/// <returns>Die Karte, die gespielt werden soll.</returns>
		public abstract Card PlayCard();

	}

}