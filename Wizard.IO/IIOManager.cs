using System.Collections.Generic;
using Wizard.Common;

namespace Wizard.IO
{

	/// <summary>
	/// Definiert die durch einen IOManager zu implementierenden Methoden. 
	/// Dabei gibt es zwei Kategorien von Methoden:
	/// <code>Process</code>-Methoden f�hren eine bestimmte Abhandlung durch, die dem User angezeigt wird. Hier
	/// wird vom User keine Aktion verlangt, das Programm f�hrt die Aktion durch und stellt die Folgen dar (z.B.
	/// beim Zug eines AI-Players).
	/// Bei <code>Get</code>-Methoden steht die Handlung des Users im Vordergrund. Er wird aufgefordert, eine
	/// Aktion durchzuf�hren (z.B., indem er eine Eingabe macht). Nachfolgend wertet das System die Handlung aus
	/// und zeigt die daraus resultierenden Folgen an.
	/// </summary>
	public interface IIOManager
    {

		/// <summary>
		/// Diese Methode wird als erstes ausgef�hrt und begr��t den Spieler. 
		/// </summary>
		void ProcessWelcome();

		/// <summary>
		/// Wird ausgef�hrt, wenn das eigentliche Spiel startet. Zuvor m�ssen verschiedene Einstellungen
		/// (Anzahl der Spieler, Spielernamen, Spieler-Level) festgelegt worden sein.
		/// </summary>
		void ProcessStart();

		/// <summary>
		/// Wird ebenfalls am Anfang einmal ausgef�hrt und gibt eine �bersicht �ber alle am Spiel teilnehmenden
		/// Spieler.
		/// </summary>
		/// <param name="lstPlayers">Liste der Spieler, die angezeigt werden sollen</param>
		void ProcessListPlayers(List<AbstractPlayer> lstPlayers);

		/// <summary>
		/// Zeigt an, dass die Karten gemischt und vorbereitet wurden.
		/// </summary>
		void ProcessInitCards();

		/// <summary>
		/// Zeigt den Start der Runde an.
		/// </summary>
		/// <param name="nCurrentRoundNumber">Die laufende Nummer der aktuellen Runde</param>
		void ProcessStartRound(int nCurrentRoundNumber);

		/// <summary>
		/// Zeigt den Start der Kartenverteilung an.
		/// </summary>
		void ProcessStartGiveCards();

		/// <summary>
		/// Zeigt an, dass ein Spieler Karten bekommt. Die Karten werden dabei verdeckt angezeigt.
		/// </summary>
		/// <param name="player">Der Spieler, der die Karten bekommt</param>
		void ProcessGiveCards(AbstractPlayer player);

		/// <summary>
		/// Zeigt an, dass ein Spieler Karten bekommt. Die Karten werden dabei offen angezeigt.
		/// </summary>
		/// <param name="player">Der Spieler, der die Karten bekommt</param>
		void ProcessGiveCards(AbstractPlayer player, List<Card> lstCards);

		/// <summary>
		/// Zeigt den Trumpf f�r die aktuelle Runde an.
		/// </summary>
		/// <param name="trumpColor">Die Trumpffarbe</param>
		void ProcessGenerateTrump(Color trumpColor);

		/// <summary>
		/// Zeigt an, welchen Trumpf ein Spieler gew�hlt hat (falls bei der Generierung des Trumpfs ein
		/// Zauberer gezogen wurde).
		/// </summary>
		/// <param name="player">Der Spieler, der den Trumpf gew�hlt hat</param>
		/// <param name="trumpColor">Die gew�hlte Trumpf-Farbe</param>
		void ProcessPlayerChooseTrump(AbstractPlayer player, Color trumpColor);

		/// <summary>
		/// Zeigt an, dass die Rate-Runde beginnt, in der alle Spieler ihr erhaltenen Stiche tippen.
		/// </summary>
		void ProcessGuessTricks();

		/// <summary>
		/// Zeigt an, welche Anzahl von Stichen ein Spieler angesagt hat.
		/// </summary>
		/// <param name="player">Der ansagende Spieler</param>
		/// <param name="nGuessedTrickCount">Die Anzahl von getippten Stichen</param>
		void ProcessPlayerGuessTrickCount(AbstractPlayer player, int nGuessedTrickCount);

		/// <summary>
		/// Zeigt den Start der Stichrunde an.
		/// </summary>
		/// <param name="startPlayer">Der Spieler, der die Stich-Runde beginnt</param>
		/// <param name="trump">Der Trumpf der aktuellen Runde</param>
		void ProcessTrickRoundStart(AbstractPlayer startPlayer, Color trump);

		/// <summary>
		/// Zeigt an, dass der Spieler ein Karte spielt.
		/// </summary>
		/// <param name="player">Der Spieler</param>
		/// <param name="playedCard">Die gespielte Karte</param>
		void ProcessPlayerPlayCard(AbstractPlayer player, Card playedCard);

		/// <summary>
		/// Aktualisiert die Karten des aktuellen Stichs. Die auf dem Tisch liegenden Karten werden
		/// also neu angezeigt.
		/// </summary>
		/// <param name="trick">Der aktuelle laufende Stich</param>
		void ProcessRefreshCurrentTrick(Trick trick);

		/// <summary>
		/// Zeigt einen fertigen Stich an.
		/// </summary>
		/// <param name="trick">Der Stich</param>
		void ProcessShowTrick(Trick trick);

		/// <summary>
		/// Zeigt den Start der Auswertung einer einzelnen Runde.
		/// </summary>
		/// <param name="nRoundNumber">Die Nummer der auszuwertenden Runde</param>
		void ProcessEvaluateRound(int nRoundNumber);

		/// <summary>
		/// Zeigt die Rundenauswertung eines einzelnen Spielers an.
		/// </summary>
		/// <param name="player">Der Spieler</param>
		/// <param name="nGuessedTrickCount">Die Anzahl der Stiche, die der Spieler getippt hatte</param>
		/// <param name="nReceivedTrickCount">Die Anzahl der Stiche, die der Spieler tats�chlich bekommen ht</param>
		/// <param name="nPoints">Die Punkte, die der Spieler f�r diese Runde erh�lt (kann auch negativ sein)</param>
		void ProcessEvaluatePlayer(AbstractPlayer player, int nGuessedTrickCount, int nReceivedTrickCount, int nPoints);
		
		/// <summary>
		/// Zeigt den Gewinner des Spiels an.
		/// Wird zum Ende des Spiels ein einziges Mal angezeigt.
		/// </summary>
		/// <param name="winningPlayer">Der Spieler, der gewonnen hat</param>
		void ProcessEndOfGame(AbstractPlayer winningPlayer);

		/// <summary>
		/// Gibt die aktuelle Gesamt-Statistik aus. Diese wird am Anfang jeder Runde angezeigt.
		/// </summary>
		/// <param name="lstPlayers">Die Liste aller Spieler</param>
		void ProcessStatistics(List<AbstractPlayer> lstPlayers);

		/// <summary>
		/// Unterbricht den Ablauf und fordert den Benutzer auf, eine Taste zu dr�cken, damit der 
		/// Programmablauf fortgesetzt wird.
		/// </summary>
		void ProcessProceed();

		/// <summary>
		/// Fordert den Benutzer auf, die gew�nschte Anzahl von Spielern einzugeben.
		/// </summary>
		/// <returns>Die eingegebene Spieleranzahl</returns>
		int GetPlayerCount();

		/// <summary>
		/// Fordert den Benutzer auf, seinen Namen einzugeben.
		/// </summary>
		/// <returns>Der eingegebene Spielername</returns>
		string GetPlayerName();

		/// <summary>
		/// Fordert den Benutzer auf, den Schwierigkeitsgrad f�r einen teilnehmenden Computer-Spieler 
		/// festzulegen.
		/// </summary>
		/// <param name="nPlayerNumber">Die Nummer des Spielers, f�r den das Level festegelegt werden soll</param>
		/// <returns>Das festgelegte Level</returns>
		int GetAILevel(int nPlayerNumber);

		/// <summary>
		/// Fordert den Benutzer auf, einen Trumpf f�r die aktuelle Runde zu w�hlen.
		/// </summary>
		/// <returns>Die gew�hlte Trumpf-Farbe</returns>
		Color GetHumanPlayerChooseTrump();

		/// <summary>
		/// Fordert den Benutzer auf, die Anzahl seiner erwarteten Stiche zu tippen.
		/// </summary>
		/// <returns>Die erwartete Anzahl von erhaltenen Stichen</returns>
		int GetHumanPlayerGuessTrickCount();

		/// <summary>
		/// Fordert den Benutzer auf, eine Karte zu spielen.
		/// </summary>
		/// <param name="lstPlayableCards">Liste aller Karten, die der Spieler momentan spielen kann.</param>
		/// <param name="lstAllCards">Liste aller Karten, die der Spieler momentan hat</param>
		/// <param name="trick">Der aktuelle Stich, also die auf dem Tisch liegenden Karten</param>
		/// <returns>Die gespielte Karte</returns>
		Card GetHumanPlayerPlayCard(List<Card> lstPlayableCards, List<Card> lstAllCards, Trick trick);

	}

}