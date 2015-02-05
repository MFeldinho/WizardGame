using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Common
{
	
	/// <summary>
	/// Stellt Methoden bereit, um zuf�llige Spielernamen zu generieren. Dabei merkt sich die Klasse,
	/// welche Namen bereits vergeben sind. So ist gew�hrleistet, dass es niemals zwei Spieler mit dem gleichen
	/// Namen gibt.
	/// </summary>
	public class NameGen 
    {
		private List<String> _names;
		private Random _rand;

		/// <summary>
		/// Konstruktor<br />
		/// Initialisiert das Array mit allen m�glichen Namen.
		/// </summary>
		public NameGen() 
        {
			// Array initialisieren
			string[] names = new string[] {  "Manfred", "D�rte", 
												"Hubert", "Frauke", 
												"Claudette", "Adelheid", 
												"G�nther", "Marion",
												"Chantalle", "Kevin-Justin", 
												"Bert", "Ernie",
												"Udo", "Annemarie",
												"Karl-Heinz", "Kader",
												"Friedolin", "Ferdinant",
												"Annette", "Marlies",
												"Pauline", "Carsten",
												"Georg", "Rosina",
												"Marcel", "Nina",
												"Christoph", "Hermine",
												"Fritz", "Gertrud",
												"Hans", "Gisela"
											};

			// Die Namen werden in die Liste �berf�hrt
			_names = new List<string>(names.Length);
			foreach (string name in names) 
            {
				_names.Add(name);
			}

			// Zufalls-Index erzeugen
			TimeSpan millis = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0));
			_rand = new Random(millis.Milliseconds);
		}

        /// <summary>
        /// Ermittelt einen Namen aus der internen Liste.
        /// </summary>
        /// <returns>Name</returns>
		public string GenerateName() 
        {
			int index = (int) Math.Floor(_rand.NextDouble() * _names.Count);
			string name = _names[index];

			// Namen aus der Liste entfernen
			_names.RemoveAt(index);

			// Namen ausgeben
			return name;
		}

	}

}