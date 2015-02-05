using System.Collections;
using System.Collections.Generic;
using Wizard.Common;

namespace Wizard.AI
{

	/// <summary>
	/// Interface, das alle KI-Methoden definiert, die dann von konkreten KI-Engines implementiert werden
	/// m�ssen. So ist es m�glich, viele verschiedene Engines zu erstellen, die nach Belieben ausgetauscht
	/// werden k�nnen.<br />
	/// Die konkreten Engines werden �n Schwierigkeitsgrade (Level 1-3) unterteilt.
	/// </summary>
	public interface IAIPlayer 
    {

		/// <summary>
		/// W�hlt die Trumpf-Farbe.
		/// </summary>
		/// <param name="handCards">Liste der Karten auf der eigenen Hand</param>
		/// <returns>Trumpffarbe die bestimmt wurde</returns>
		Color ChooseTrump(List<Card> handCards);

		/// <summary>
		/// R�t die erwartete Anzahl von Stichen.
		/// </summary>
		/// <param name="handCards">Liste der Karten auf der eigenen Hand</param>
		/// <param name="guessedTricks">HashTable der angesagten Stiche in Bezug zu den Spielern</param>
		/// <param name="trump">Die aktuelle Trumpffarbe dieser Runde</param>
		/// <param name="playerCount">Anzahl der Spieler</param>
		/// <returns>Anzahl der Stiche die angesagten werden sollen</returns>
		int GuessTrickCount(List<Card> handCards, Hashtable guessedTricks, Color trump, int playerCount);

		/// <summary>
		/// Spielt eine Karte.
		/// </summary>
		/// <param name="trump">Trumpf-Farbe</param>
		/// <param name="playableCards">Liste der eigenen spielbaren Karten</param>
		/// <param name="handCards">Liste der Karten auf der eigenen Hand</param>
		/// <param name="currentTrickCards">Liste der Karten die momentan auf dem Tisch liegen (Liste kann auch leer sein, wenn noch keine Karten gespielt wurden)</param>
		/// <param name="currentHighestTrickCard">h�chste Karte die momentan auf dem Tisch liegt</param>
		/// <param name="guessedTricks">HashTable der angesagten Stiche in Bezug zu den Spielern</param>
		/// <param name="receivedTricks">HashTable der bekommenen Stiche in Bezug zu den Spielern</param>
		/// <param name="players">Liste der Spieler (enth�lt auch die Punkte der Spieler)</param>
		/// <param name="playedTricks">Alle in dieser Runde gespielten Stiche (enth�lt die gespielten Karten dieser Runde)</param>
		/// <returns>Karte die gespielt werden soll</returns>
        Card PlayCard(Color trump, List<Card> playableCards, List<Card> handCards, List<Card> currentTrickCards, Card currentHighestTrickCard, Hashtable guessedTricks, Hashtable receivedTricks, List<AbstractPlayer> players, List<Trick> playedTricks);
	
    }

}