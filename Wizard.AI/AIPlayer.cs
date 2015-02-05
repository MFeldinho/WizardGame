using System;
using System.Collections;
using System.Collections.Generic;
using Wizard.Common;

namespace Wizard.AI
{

	/// <summary>
	/// Class AIPlayer
	/// Stellt einen Computer-Spieler dar. Er verfügt über die gleichen Fähigkeiten wie der abstrakte Player, muss
	/// aber über einige zusätzliche Methoden und Eigenschaften verfügen.
	/// Die Operationen werden vom KI-Framework durchgeführt, so dass der Computer-Spieler individuell auf
	/// bestimmte Spielsituationen reagieren kann.
	/// </summary>
    [Serializable]
	public class AIPlayer : AbstractPlayer 
	{
		// Der Schwierigkeitsgrad des Spielers
		private int _level;
		// Die Engine, die der Spieler für seine Aktionen verwendet
		private IAIPlayer _engine;

		// Das Level darf nur abgerufen, aber nicht verändert werden
		public int Level
		{
			get { return _level; }
		}

		/// <summary>
		/// Konstruktor<br />
		/// Initialisiert die Klassenmember.
		/// </summary>
		/// <param name="playerName">Der Name des Spielers</param>
        /// <param name="nPlayerNumber">Laufende Nummer</param>
        /// <param name="nLevel">Das Level des Spielers)</param>
        /// <param name="aiName">Name der KI</param>
		public AIPlayer(string playerName, int nPlayerNumber, int nLevel, string aiName) : base(playerName, nPlayerNumber, false) 
		{
			_level = nLevel;

			// Engine initialisieren
			//TODO Assemblies dynamisch laden
			switch (nLevel) 
			{
				case 0:
					_engine = new Dummy();
					break;
				case 1:
					_engine = new Alpha();
					break;
				case 2:
				case 3:
				default:
					_engine = new Alpha();
					break;
			}	 
		}

		/// <summary>
		/// <see cref="A_Player.ChooseTrump()"/>
		/// </summary>
		public override Color ChooseTrump() 
		{
			Color trumpColor = _engine.ChooseTrump(_cards);
			
			//OutputManagerFactory.GetOutputManager().ProcessPlayerChooseTrump(this, trumpColor);

			return trumpColor;
		}

		/// <summary>
		/// <see cref="A_Player.GuessTrickCount()"/>
		/// </summary>
		public override int GuessTrickCount() 
		{
			// Kopien aller übergebenen Objekte erstellen
			List<Card> lstCardsCopy = new List<Card>();
			foreach (Card card in _cards)
			{
				lstCardsCopy.Add(card);
			}

			Hashtable guessedTricksCopy = new Hashtable();

            //TODO GameScope
            //Hashtable guessedTricks = game.CurrentRound.GuessedTricks;
            //foreach (AbstractPlayer player in guessedTricks.Keys) 
            //{
            //    guessedTricksCopy.Add(player, guessedTricks[player]);
            //}

            //TODO GameScope
            int nGuessedTrickCount = 1; // engine.GuessTrickCount(lstCardsCopy, guessedTricksCopy, game.CurrentRound.Trump, game.PlayerCount);

			//OutputManagerFactory.GetOutputManager().ProcessPlayerGuessTrickCount(this, nGuessedTrickCount);

			return nGuessedTrickCount;
		}

		/// <summary>
		/// <see cref="AbstractPlayer.PlayCard()"/>
		/// </summary>
		public override Card PlayCard() 
		{
			// Kopien aller Objekte erstellen, die an die Engine übergeben werden sollen

            //TODO GameScope
            //List<Card> lstPlayableCardsCopy = new List<Card>();
            //foreach (Card card in GetPlayableCards(game.CurrentRound.CurrentTrickRound.Trick, game.CurrentRound.CurrentTrickRound.PlayColor)) 
            //{
            //    lstPlayableCardsCopy.Add(card);
            //}

            //List<Card> lstAllCardsCopy = new List<Card>();
            //foreach (Card card in lstCards) 
            //{
            //    lstAllCardsCopy.Add(card);
            //}

            //List<Card> lstCurrentTrickCardsCopy = new List<Card>();
            //Trick currentTrick = game.CurrentRound.CurrentTrickRound.Trick;
            //for (int i = 0; i < currentTrick.CardCount; i++) 
            //{
            //    lstCurrentTrickCardsCopy.Add(currentTrick.Get(i));
            //}

            //Card currentHighestTrickCardCopy;
            //TrickRound currentTrickRound = game.CurrentRound.CurrentTrickRound;
            //currentHighestTrickCardCopy = currentTrickRound.CurrentHighestCard;
			
            //Hashtable guessedTricksCopy = new Hashtable();
            //Hashtable guessedTricks = game.CurrentRound.GuessedTricks;
            //foreach (AbstractPlayer player in guessedTricks.Keys) 
            //{
            //    guessedTricksCopy.Add(player, guessedTricks[player]);
            //}

            //Hashtable receivedTricksCopy = new Hashtable();
            //Hashtable receivedTricks = game.CurrentRound.ReceivedTricks;
            //foreach (AbstractPlayer player in receivedTricks.Keys) 
            //{
            //    receivedTricksCopy.Add(player, receivedTricks[player]);
            //}

            //List<AbstractPlayer> lstPlayersCopy = new List<AbstractPlayer>();
            //foreach(AbstractPlayer player in game.Players) 
            //{
            //    lstPlayersCopy.Add(player);
            //}

            //List<Trick> lstPlayedTricksCopy = new List<Trick>();
            //foreach(Trick trick in game.CurrentRound.PlayedTricks) 
            //{
            //    lstPlayedTricksCopy.Add(trick);
            //}

			// Die Karte ermitteln, die gespielt werden soll

            //TODO GameScope
            Card playedCard = null; // engine.PlayCard(game.CurrentRound.Trump, lstPlayableCardsCopy, lstAllCardsCopy, lstCurrentTrickCardsCopy, currentHighestTrickCardCopy, guessedTricksCopy, receivedTricksCopy, lstPlayersCopy, lstPlayedTricksCopy);

			// Gespielte Karte wird aus der Hand des Spielers entfernen
			_cards.Remove(playedCard);

			// Karte zurück
			return playedCard;
		}

	}

}