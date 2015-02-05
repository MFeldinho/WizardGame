using System;
using System.Collections;
using System.Collections.Generic;
using Wizard.Common;

namespace Wizard.AI
{

	/// <summary>
	/// Implementiert eine relativ einfache KI.
	/// Stiche raten:
	/// Es werden Stiche in Abhängigkeit von den Handkarten(z.B. 1-8 -> nein, 9-13 ja)
	/// und der Anzahl der Spieler geraten.
	/// 
	/// Karte spielen:
	/// Wenn sich eine höhere Karte auf der Hand befindet,
	/// spiele die höchste Handkarte.
	/// Wenn nicht, dann spiele die kleinste Handkarte.
	/// 
	/// Wird für Testzwecke benötigt.
	/// </summary>
    public class Alpha : IAIPlayer 
    {

		/// <summary>
		/// <see cref="I_AIEngine.ChooseTrump(List<C_Card>)"/>
		/// </summary>
		public Color ChooseTrump(List<Card> lstPlayerCards) 
        {
			Color color = GetMostDetectedColor(lstPlayerCards);
			return color;
		}

		/// <summary>
		/// <see cref="I_AIEngine.GuessTrickCount(List<C_Card>, Hashtable, int)"/>
		/// </summary>
		public int GuessTrickCount(List<Card> lstPlayerCards, Hashtable guessedTricks, Color trump, int nPlayerCount) 
        {
			int nTrickCount = 0;

			foreach (Card card in lstPlayerCards) 
            {
                if (card.Color == trump && card.Value > 4)
                {
                    nTrickCount++;
                }
                else if (card.Value > (13 - Math.Floor(13.0f / nPlayerCount)))
                {
                    nTrickCount++;
                }
			}

			return nTrickCount;
		}

		/// <summary>
		/// <see cref="I_AIEngine.PlayCard(List<C_Card>, List<C_Card>, List<C_Card>, Hashtable, Hashtable, List<A_Player>, List<C_Trick>)"/>
		/// </summary>
		public Card PlayCard(Color trump, List<Card> playableCards, List<Card> allCards, List<Card> currentTrickCards, Card currentHighestTrickCard, Hashtable guessedTricks, Hashtable receivedTricks, List<AbstractPlayer> players, List<Trick> playedTricks) 
        {
			TimeSpan millis = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0));
			Random rand = new Random(millis.Milliseconds);
			
			if (currentTrickCards.Count == 0) 
            {
				//erste aufgespielte karte ist zufällig
				int nIndex = (int) Math.Floor(rand.NextDouble() * playableCards.Count);
				return playableCards[nIndex];
			}
			
			Color playColor = currentTrickCards[0].Color;
			Card highestTrickCard = currentHighestTrickCard;
			Card highestPlayableCard = GetHighestCard(playableCards, trump, playColor);
			Card lowestPlayableCard = GetLowestCard(playableCards, trump, playColor);

			// wenn kein karte höher als die höchste karte im stich, dann spiele kleinste karte
            if (HigherCard(highestTrickCard, highestPlayableCard, trump, playColor) == 1)
            {
                return lowestPlayableCard;
            }

			// sonst spiele höchste karte
			return highestPlayableCard;
		}
		
		/// <summary>
		/// Sucht die häufigste Farbe in den Handkarten
		/// </summary>
		/// <param name="playerCards">Liste der Handkarten</param>
		/// <returns>Farbe die am häufigsten auftrat</returns>
		private Color GetMostDetectedColor(List<Card> playerCards)
		{
			int[] color = new int[4];

			// zähle die Anzahl je Farbe
			foreach (Card card in playerCards)
			{
                if (card.Color == Color.Red)
                {
                    color[0]++;
                }
                else if (card.Color == Color.Yellow)
                {
                    color[1]++;
                }
                else if (card.Color == Color.Green)
                {
                    color[2]++;
                }
                else if (card.Color == Color.Blue)
                {
                    color[3]++;
                }
			}
			
			// suche Index mit häufigster Farbe
			int maxColor = -1;
			int indexMaxColor = -1;
			Color returnColor = Color.Undefined;

			for (int nIndex=0; nIndex < color.Length; nIndex++) 
            {
				if (color[nIndex] >= maxColor) 
                {
					indexMaxColor = nIndex;
					maxColor = color[nIndex];
				}
			}
			
			// ordne dem Index eine Farbe zu
			switch (maxColor) 
            {
				case 0:
					returnColor = Color.Red;
					break;
				case 1:
					returnColor = Color.Yellow;
					break;
				case 2:
					returnColor = Color.Green;
					break;
				case 3:
					returnColor = Color.Blue;
					break;
			}

			return returnColor;
		}
		
		/// <summary>
		/// Errechnet die höhere Karte.
		/// Gibt bei Gleichheit der Karten eine 0 zurück,
		/// wenn die erste Karte höher ist eine 1,
		/// wenn die zweite Karte höher ist eine 2.
		/// </summary>
		/// <param name="firstCard">erste Karte die verglichen wird</param>
		/// <param name="secondCard">zweite Karte die verglichen wird</param>
		/// <param name="trump">Trumpf-Farbe</param>
		/// <param name="playColor">Spiel-Farbe</param>
		/// <returns>0, 1 oder 2 (siehe "summary")</returns>
		private int HigherCard(Card firstCard, Card secondCard, Color trump, Color playColor)
		{
			if (firstCard.Color == secondCard.Color) 
            {
                if (firstCard.Value == secondCard.Value)
                {
                    return 0;
                }

                if (firstCard.Value > secondCard.Value)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
			}

            if (firstCard.Color == trump)
            {
                return 1;
            }
            if (secondCard.Color == trump)
            {
                return 2;
            }

            if (firstCard.Color == playColor)
            {
                return 1;
            }
            if (secondCard.Color == playColor)
            {
                return 2;
            }

            if (firstCard.Value > secondCard.Value)
            {
                return 1;
            }
            else
            {
                return 2;
            }
		}

		/// <summary>
		/// Sucht die höchste Karte
		/// Hierzu müssen die Handkarten nach folgendem Schema sortiert sein:
		/// Z*, T*, O* [rt, ge, gr, bl], N*
		/// </summary>
		/// <param name="playableCards">Liste der Karten, aus der die größte gesucht werden soll</param>
		/// <param name="trump">Trumpffarbe</param>
		/// <param name="playColor">Spielfarbe</param>
		/// <returns>größte Karte aus der Liste</returns>
		private Card GetHighestCard(List<Card> playableCards, Color trump, Color playColor) 
        {
			// Vorraussetzung ist, dass die Karten sortiert sind
			foreach (Card card in playableCards) 
            {
				return card;
			}

			// Dieser Punkt sollte niemals erreicht werden (Liste der spielbaren Karten ist leer)
			return null;
		}

		/// <summary>
		/// Sucht die kleinste Karte
		/// Hierzu müssen die Handkarten nach folgendem Schema sortiert sein:
		/// Z*, T*, O* [rt, ge, gr, bl], N*
		/// </summary>
		/// <param name="playableCards">Liste der Karten, aus der die kleinste gesucht werden soll</param>
		/// <param name="trump">Trumpffarbe</param>
		/// <param name="playColor">Spielfarbe</param>
		/// <returns>kleinste Karte aus der Liste</returns>
		private Card GetLowestCard(List<Card> playableCards, Color trump, Color playColor) 
        {
			Card lowestCard = null;
			foreach (Card card in playableCards) 
            {
				lowestCard = card;
			}

			return lowestCard;
		}

	}

}