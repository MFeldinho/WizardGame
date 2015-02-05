using System;

namespace Wizard.Common
{

	/// <summary>
	/// Repräsentiert eine Spielkarte.
	/// </summary>
    [Serializable]
	public class Card 
    {

        private Color _color;
        private int _value;

		/// <summary>
		/// Konstruktor<br />
		/// </summary>
		/// <param name="color">Farbe</param>
		/// <param name="value">Zahlenwert</param>
		public Card(Color color, int value) 
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Ungültiger Wert", "value");
            }

			_color = color;
			_value = value;
		}

		/// <summary>
		/// Clone-Konstruktor<br />
		/// Erstellt eine Kopie der übergebenen Karte.
		/// </summary>
		/// <param name="card">Die Original-Karte</param>
		public Card(Card card) : this(card.Color, card.Value) { }

		/// <summary>
        /// Die Farbe der Karte (rot, gelb, grün, blau oder keine)
		/// </summary>
		public Color Color 
        {
			get { return _color; }
		}

		/// <summary>
        /// Der Zahlenwert (0 - 14)
		/// </summary>
		public int Value 
        {
			get { return _value; }
		}

		/// <summary>
		/// Stellt die Karte als Text dar.<br />
		/// Bsp.: [red10] (Rote 10), [none14] (Zauberer), [none0] (Narr)
		/// </summary>
		/// <returns>Die Karte als String</returns>
		public override string ToString()
        {
			return "[" + Color.ToString() + Value.ToString() + "]";
		}

	}

}