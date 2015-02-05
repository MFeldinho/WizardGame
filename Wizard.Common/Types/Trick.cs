using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Common
{

	/// <summary>
	/// Wrapper-Klasse, die einen einzelnen Stich darstellt. Ein Stich besteht aus den in der zugehörigen 
	/// Stich-Runde gespielten Karten und dem Spieler, der den Stich bekommen hat.
	/// </summary>
    [Serializable]
	public class Trick 
    {

		// Die Liste der zum Stich gehörenden Karten
		private List<Card> lstTrickCards;
		// Der Spieler, der den Stich bekommen hat
        private AbstractPlayer player;

		/// <summary>
		/// Der Spieler, der den Stich bekommen hat (oder NULL, falls Stich noch nicht beendet).
		/// </summary>
        public AbstractPlayer Player 
        {
			get { return player; }
			set { player = value; }
		}

		/// <summary>
		/// Anzahl der aktuell enthaltenen Karten.
		/// </summary>
		public int CardCount 
        {
			get { return lstTrickCards.Count; }
		}

		/// <summary>
		/// Konstruktor<br />
		/// Initialisiert die Member.
		/// </summary>
		public Trick() 
        {
			lstTrickCards = new List<Card>();
			player = null;
		}

		/// <summary>
		/// Fügt eine neue Karte hinzu.
		/// </summary>
		/// <param name="card">Die hinzuzufügende Karte</param>
		public void Add(Card card) 
        {
			lstTrickCards.Add(card);
		}

		/// <summary>
		/// Ruft eine Karte ab, die über ihren Index in der Liste identifiziert wird.
		/// </summary>
		/// <param name="nIndex">Der Index der gesuchten Karte</param>
		/// <returns>Die Karte</returns>
		public Card Get(int nIndex) 
        {
			return lstTrickCards[nIndex];
		}

	}

}