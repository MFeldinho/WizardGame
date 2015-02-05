using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Common
{

	/// <summary>
	/// Verschiedene statische Methoden zur Generierung oder Interpretation von Strings.
	/// </summary>
	public static class StringTools 
    {

		/// <summary>
		/// Wandelt einen <code>Color</code>-Eintrag in einen lesbaren (deutschen) String um.
		/// </summary>
		/// <param name="color">Die Farbe</param>
		/// <returns>Der lesbare Text</returns>
		public static string GetColorAsString(Color color) 
        {
            if (color == Color.Blue)
            {
                return "Blau";
            }
            if (color == Color.Green)
            {
                return "Grün";
            }
            if (color == Color.Red)
            {
                return "Rot";
            }
            if (color == Color.Yellow)
            {
                return "Gelb";
            }
            if (color == Color.None)
            {
                return "Kein";
            }

			return "Undefiniert";
		}

	}

}