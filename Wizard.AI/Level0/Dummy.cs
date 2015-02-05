using System;
using System.Collections;
using System.Collections.Generic;
using Wizard.Common;

namespace Wizard.AI
{

	/// <summary>
	/// Implementiert eine sehr einfache KI.
	/// Stiche raten:
	/// Abgerundete hälfte der Handkarten.
	/// 
	/// Karte spielen:
	/// Zufällige Karte.
	/// 
	/// Wird für Testzwecke benötigt.
	/// </summary>
    public class Dummy : IAIPlayer 
    {

		/// <summary>
		/// <see cref="I_AIEngine.ChooseTrump(List<C_Card>)"/>
		/// </summary>
		public Color ChooseTrump(List<Card> playerCards) 
        {
			return Color.Blue;
		}

		/// <summary>
		/// <see cref="I_AIEngine.GuessTrickCount(List<C_Card>, Hashtable, int)"/>
		/// </summary>
		public int GuessTrickCount(List<Card> playerCards, Hashtable guessedTricks, Color trump, int playerCount) 
        {
			return (int)(playerCards.Count / 2);
		}

		/// <summary>
		/// <see cref="I_AIEngine.PlayCard(List<C_Card>, List<C_Card>, List<C_Card>, Hashtable, Hashtable, List<A_Player>, List<C_Trick>)"/>
		/// </summary>
		public Card PlayCard(Color trump, List<Card> playableCards, List<Card> allCards, List<Card> currentTrickCards, Card currentHighestTrickCard, Hashtable guessedTricks, Hashtable receivedTricks, List<AbstractPlayer> players, List<Trick> playedTricks) 
        {
			TimeSpan millis = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0));
			Random rand = new Random(millis.Milliseconds);
			int index = (int) Math.Floor(rand.NextDouble() * playableCards.Count);

			return playableCards[index];
		}

    }

}