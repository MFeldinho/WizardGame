using System;
using System.Collections.Generic;
using System.Threading;
using Wizard.Common;

namespace Wizard.IO 
{

	public class ConsoleIOManager : IIOManager 
    {

		// Wartungs-Konstanten
		private const int LONGSLEEPTIME = 0;
		private const int SHORTSLEEPTIME = 0;
		private const bool SHOULDPROCEED = true;

		public void ProcessWelcome() 
        {
			Console.WriteLine("\n\n-- WILLKOMMEN BEI WIZARD! --\n");
		}

		public void ProcessStart() 
        {
			Console.WriteLine("\n-- Das Spiel beginnt! --");
		}

		public void ProcessListPlayers(List<AbstractPlayer> lstPlayers) 
        {
			Console.WriteLine("\nTeilnehmende Spieler:");
			foreach (AbstractPlayer player in lstPlayers) 
            {
				Console.WriteLine(" Spieler " + (player.PlayerNumber + 1) + ": " + player.Name);
			}
		}

		public void ProcessInitCards() 
        {
			Console.WriteLine("\n-- Die Karten wurden gemischt und vorbereitet. --");
		}

		public void ProcessStartRound(int nRoundNumber) 
        {
			Console.WriteLine("\n-- Runde " + nRoundNumber.ToString() + " startet. --");
		}

		public void ProcessStartGiveCards() {
			Console.WriteLine("\n-- Die Karten werden verteilt. --\n");
		}

		public void ProcessGiveCards(AbstractPlayer player) 
        {
			Console.WriteLine(player.Name + " ...");
			Thread.Sleep(SHORTSLEEPTIME);
		}

		public void ProcessGiveCards(AbstractPlayer player, List<Card> lstCards) 
        {
			Console.Write(player.Name + " ... ");
			Console.Write("[ ");

			foreach (Card card in lstCards) 
            {
				Console.Write(card.ToString() + " ");
			}

			Console.WriteLine("]");
			Thread.Sleep(SHORTSLEEPTIME);
		}

		public void ProcessGenerateTrump(Color trumpColor) 
        {
			Console.WriteLine("\nDer Trumpf für diese Runde wurde bestimmt: " + StringTools.GetColorAsString(trumpColor));
		}

		public void ProcessPlayerChooseTrump(AbstractPlayer player, Color trumpColor) 
        {
			Console.WriteLine("\n" + player.Name + " hat folgenden Trumpf gewählt: " + StringTools.GetColorAsString(trumpColor));
		}

		public void ProcessGuessTricks() 
        {
			Console.WriteLine("\n-- Tippen der erhaltenen Stiche. --\n");
		}

		public void ProcessPlayerGuessTrickCount(AbstractPlayer player, int nGuessedTrickCount) 
        {
			Console.WriteLine(" " + player.Name + " glaubt, " + nGuessedTrickCount + " Stiche zu bekommen.");
			Thread.Sleep(LONGSLEEPTIME);
		}

		public void ProcessTrickRoundStart(AbstractPlayer startPlayer, Color trump) 
        {
			Console.WriteLine("\n-- Start der Stichrunde (Trumpf: " + StringTools.GetColorAsString(trump) + ") --\n");
		}

		public void ProcessPlayerPlayCard(AbstractPlayer player, Card playedCard) 
        {
			Console.WriteLine(" " + player.Name + " spielt " + playedCard.ToString());
			Thread.Sleep(LONGSLEEPTIME);
		}

		public void ProcessRefreshCurrentTrick(Trick trick) 
        {
			Console.Write("Karten in der Mitte: [ ");

			for (int i = 0; i < trick.CardCount; i++) 
            {
				Console.Write(trick.Get(i).ToString() + " ");
			}

			Console.WriteLine("]");
		}

		public void ProcessShowTrick(Trick trick) 
        {
			Console.WriteLine("\n-- Ende der Stichrunde. --");
			Console.WriteLine("\nDer Stich ging an " + trick.Player.Name + "!");
		}

		public void ProcessEvaluateRound(int roundNumber) 
        {
			Console.WriteLine("\nAuswertung für Runde " + roundNumber + ": ");
		}

		public void ProcessEvaluatePlayer(AbstractPlayer player, int nGuessedTrickCount, int nReceivedTrickCount, int nPoints) 
        {
			Console.Write(player.Name + " (Spieler " + (player.PlayerNumber + 1) + "): ");
			Console.WriteLine("G: " + nGuessedTrickCount + " / R: " + nReceivedTrickCount + " / P: " + nPoints);
		}

		public void ProcessEndOfGame(AbstractPlayer winningPlayer) 
        {
			Console.WriteLine("\n-- Ende des Spiels! --");
			Console.WriteLine("\nGewinner: " + winningPlayer.Name + " (Spieler " + (winningPlayer.PlayerNumber + 1) + ") mit " + winningPlayer.Points.ToString() + " Punkten!");

			Console.Write("\nZum Beenden bitte <ENTER> drücken.");
			Console.ReadLine();
		}

		public void ProcessStatistics(List<AbstractPlayer> lstPlayers) 
        {
			Console.WriteLine("\nAktueller Punktestand:");
			foreach (AbstractPlayer player in lstPlayers) {
				Console.WriteLine(player.Name + ": " + player.Points + " Punkte" );
			}
		}

		public void ProcessProceed() 
        {
			if (SHOULDPROCEED) 
            {
				Console.Write("\nZum Fortfahren bitte <ENTER> drücken ...");
				Console.ReadLine();
			}
		}

		public int GetPlayerCount() 
        {
			Console.Write("Bitte Anzahl der Spieler angeben: ");
			int nPlayerCount = Int32.Parse(Console.ReadLine());
			return nPlayerCount;
		}
		
		public string GetPlayerName() 
        {
			Console.Write("\nBitte gib deinen Namen an: ");
			string strPlayername = Console.ReadLine();
			Console.WriteLine();
			return strPlayername;
		}

		public int GetAILevel(int nPlayerNumber) 
        {
			Console.Write("Bitte Level für Spieler " + (nPlayerNumber + 1) + " angeben: ");
			int nAILevel = Int32.Parse(Console.ReadLine());
			return nAILevel;
		}

		public Color GetHumanPlayerChooseTrump() 
        {
			Console.Write("Bitte gewünschte Trumpf-Farbe angeben (r, b, g, y): ");
			char chrTrumpColor = Console.ReadLine().ToCharArray()[0];

            if (chrTrumpColor == 'r')
            {
                return Color.Red;
            }
            else if (chrTrumpColor == 'g')
            {
                return Color.Green;
            }
            else if (chrTrumpColor == 'b')
            {
                return Color.Blue;
            }
            else if (chrTrumpColor == 'y')
            {
                return Color.Yellow;
            }

			return Color.None;
		}

		public int GetHumanPlayerGuessTrickCount() 
        {
			Console.Write("Bitte Anzahl der erwarteten Stiche tippen: ");
			int nGuessedTrickCount = Int32.Parse(Console.ReadLine());
			return nGuessedTrickCount;
		}

		public Card GetHumanPlayerPlayCard(List<Card> lstPlayableCards, List<Card> lstAllCards, Trick trick) 
        {
			Console.WriteLine("\nFolgende Karten können gespielt werden: ");
			for (int i = 0; i < lstPlayableCards.Count; i++) 
            {
				Console.WriteLine( " " + i + ": " + lstPlayableCards[i].ToString() );
			}

			Console.Write("Eingabe: ");
			int nCardNumber = Int32.Parse(Console.ReadLine());

			Console.WriteLine();

			return lstPlayableCards[nCardNumber];
		}

	}

}