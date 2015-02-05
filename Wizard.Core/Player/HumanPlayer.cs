using System;
using System.Collections.Generic;
using Wizard.Common;
using Wizard.IO;

namespace Wizard.Core
{

	/// <summary>
	/// Repräsentiert einen menschlichen Spieler.
	/// </summary>
    [Serializable]
	public sealed class HumanPlayer : AbstractPlayer 
    {

        private IIOManager _ioManager;

		/// <summary>
		/// Konstruktor<br />
		/// Überlädt den abstrakten Standardkonstruktor.
		/// </summary>
		/// <param name="name">Der gewünschte Spielername (vom User festgelegt)</param>
        /// <param name="playerNumber">Die laufende Nummer des Spielers</param>
		public HumanPlayer(string name, int playerNumber) : base(name, playerNumber, false) 
        {
            // IOManager initialisieren
            _ioManager = IOManagerFactory.GetIOManager();
        }

		/// <summary>
        /// <see cref="AbstractPlayer.ChooseTrump()"/>
		/// </summary>
		public override Color ChooseTrump() 
        {
            Color trumpColor = _ioManager.GetHumanPlayerChooseTrump();

            _ioManager.ProcessPlayerChooseTrump(this, trumpColor);

			return trumpColor;
		}

		/// <summary>
        /// <see cref="AbstractPlayer.GuessTrickCount()"/>
		/// </summary>
		public override int GuessTrickCount() 
        {
            int guessedTrickCount = _ioManager.GetHumanPlayerGuessTrickCount();

            _ioManager.ProcessPlayerGuessTrickCount(this, guessedTrickCount);

			return guessedTrickCount;
		}

		/// <summary>
        /// <see cref="AbstractPlayer.PlayCard()"/>
		/// </summary>
		public override Card PlayCard() 
        {
			// Kopie der Hand-Karten anlegen
			List<Card> cardsCopy = new List<Card>();
			foreach(Card card in _cards) 
            {
				cardsCopy.Add(card);
			}

			// Aktuellen Stich anzeigen und nachfragen, welche Karte der Spieler legen möchte
            Card playedCard = _ioManager.GetHumanPlayerPlayCard(
                GetPlayableCards(GameScope.CS.CurrentTrick, GameScope.CS.CurrentPlayColor), 
                cardsCopy, 
                GameScope.CS.CurrentTrick);

			// Gespielte Karte aus der Hand des Spielers entfernen
			_cards.Remove(playedCard);

			// Gespielte Karte zurückgeben
			return playedCard;
		}

	}

}