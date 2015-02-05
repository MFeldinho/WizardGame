using System.Collections.Generic;
using System.Windows.Forms;
using Wizard.Common;
using Wizard.IO.Forms;

namespace Wizard.IO
{

    public class FormIOManager : IIOManager
    {
        
        private FrmInitWelcome _frmInitWelcome;
        private Form _frmMain;
        private int _playerCount;

        public void ProcessWelcome()
        {
            // SplashScreen erstellen und anzeigen
            FrmSplash splashScreen = new FrmSplash(1);
            splashScreen.ShowDialog();

            // Erstes Optionen-Formular anzeigen
            _frmInitWelcome = new FrmInitWelcome();
            _frmInitWelcome.ShowDialog();

            // Spieleranzahl laden
            _playerCount = _frmInitWelcome.AIPlayer.Length + 1;
        }

        public void ProcessStart()
        {
            // Hauptformular starten (abhängig von der Spieleranzahl)
            switch (_playerCount)
            {
                case 3:
                    _frmMain = new FrmMain3p();
                    break;
                case 4:
                    _frmMain = new FrmMain4p();
                    break;
                case 5:
                    _frmMain = new FrmMain5p();
                    break;
                case 6:
                    _frmMain = new FrmMain6p();
                    break;
            }

            // Formular anzeigen
            _frmMain.Show();
        }

        public void ProcessListPlayers(List<AbstractPlayer> lstPlayers)
        {
            // Initialen Spielstand anzeigen
            FrmScores scores = new FrmScores(lstPlayers);
            scores.ShowDialog();
        }

        public void ProcessInitCards()
        {
        }

        public void ProcessStartRound(int nRoundNumber)
        {
        }

        public void ProcessStartGiveCards()
        {
        }

        public void ProcessGiveCards(AbstractPlayer player)
        {
        }

        public void ProcessGiveCards(AbstractPlayer player, List<Card> lstCards)
        {
        }

        public void ProcessGenerateTrump(Color trumpColor)
        {
        }

        public void ProcessPlayerChooseTrump(AbstractPlayer player, Color trumpColor)
        {
        }

        public void ProcessGuessTricks()
        {
        }

        public void ProcessPlayerGuessTrickCount(AbstractPlayer player, int nGuessedTrickCount)
        {
        }

        public void ProcessTrickRoundStart(AbstractPlayer startPlayer, Color trump)
        {
        }

        public void ProcessPlayerPlayCard(AbstractPlayer player, Card playedCard)
        {
        }

        public void ProcessRefreshCurrentTrick(Trick trick)
        {
        }

        public void ProcessShowTrick(Trick trick)
        {
        }

        public void ProcessEvaluateRound(int nRoundNumber)
        {
        }

        public void ProcessEvaluatePlayer(AbstractPlayer player, int nGuessedTrickCount, int nReceivedTrickCount, int nPoints)
        {
        }

        public void ProcessEndOfGame(AbstractPlayer winningPlayer)
        {
        }

        public void ProcessStatistics(List<AbstractPlayer> lstPlayers)
        {
        }

        public void ProcessProceed()
        {
        }

        public int GetPlayerCount()
        {
            return _playerCount;
        }

        public string GetPlayerName()
        {
            return _frmInitWelcome.PlayerName;
        }

        public int GetAILevel(int nPlayerNumber)
        {
            return _frmInitWelcome.AIPlayer[nPlayerNumber - 1];
        }

        public Color GetHumanPlayerChooseTrump()
        {
            return Color.None;
        }

        public int GetHumanPlayerGuessTrickCount()
        {
            return 0;
        }

        public Card GetHumanPlayerPlayCard(List<Card> lstPlayableCards, List<Card> lstAllCards, Trick trick)
        {
            return null;
        }

    }

}