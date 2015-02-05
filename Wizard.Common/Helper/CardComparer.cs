using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Common 
{

    /// <summary>
    /// Erlaubt den Vergleich von Spielkarten.
    /// </summary>
	public class CardComparer : IComparer<Card> 
    {
		Color _trump;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="trump"></param>
		public CardComparer(Color trump) 
        {
			_trump = trump;
		}

		/// <summary>
		/// Vergleichsklasse für Kartenobjekt.<br />
		/// Karten werden nur nach ihrer Zahl (Value) aufsteigend sortiert
		/// </summary>
		/// <param name="card_1">erste Karte</param>
		/// <param name="card_2">zweite Karte</param>
		/// <returns>0: gleichgroß; 1: erste karte größer; -1: zweite karte größer</returns>
		public int Compare(Card card_1, Card card_2) 
        {
			// Vergleich mit null
			if (card_1 == null || card_2 == null) 
            {
                if (card_1 == null && card_2 == null)
                {
                    return 0;
                }
                else if (card_1 == null)
                {
                    return -1;
                }
                else if (card_2 == null)
                {
                    return 1;
                }
			}
			
			// Zauberer vergleich
			if (card_1.Value == 14 || card_2.Value == 14) 
            {
                if (card_1.Value == 14 && card_2.Value == 14)
                {
                    return 0;
                }
                else if (card_1.Value == 14)
                {
                    return 1;
                }
                else if (card_2.Value == 14)
                {
                    return -1;
                }
			}

			// Narren vergleichen
			if (card_1.Value == 0 || card_2.Value == 0) 
            {
                if (card_1.Value == 0 && card_2.Value == 0)
                {
                    return 0;
                }
                else if (card_1.Value == 0)
                {
                    return -1;
                }
                else if (card_2.Value == 0)
                {
                    return 1;
                }
			}
			
			// Trumpf vergleichen
			if (card_1.Color == _trump || card_2.Color == _trump) 
            {
				if (card_1.Color == _trump && card_2.Color == _trump) 
                {
                    if (card_1.Value == card_2.Value)
                    {
                        return 0;
                    }
                    else if (card_1.Value > card_2.Value)
                    {
                        return 1;
                    }
                    else if (card_1.Value < card_2.Value)
                    {
                        return -1;
                    }
				}
                else if (card_1.Color == _trump)
                {
                    return 1;
                }
                else if (card_2.Color == _trump)
                {
                    return -1;
                }
			}

			// Farben vergleichen
			if (card_1.Color == card_2.Color) 
            {
                if (card_1.Value == card_2.Value)
                {
                    return 0;
                }
                else if (card_1.Value > card_2.Value)
                {
                    return 1;
                }
                else if (card_1.Value < card_2.Value)
                {
                    return -1;
                }
			}
            else if (card_1.Color == Color.Red)
            {
                return 1;
            }
            else if (card_2.Color == Color.Red)
            {
                return -1;
            }
            else if (card_1.Color == Color.Yellow)
            {
                return 1;
            }
            else if (card_2.Color == Color.Yellow)
            {
                return -1;
            }
            else if (card_1.Color == Color.Green)
            {
                return 1;
            }
            else if (card_2.Color == Color.Green)
            {
                return -1;
            }
            else if (card_1.Color == Color.Blue)
            {
                return 1;
            }
            else if (card_2.Color == Color.Blue)
            {
                return -1;
            }
			
			return 0;
		}

	}

}