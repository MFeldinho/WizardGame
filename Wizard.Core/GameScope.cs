using System.Collections.Generic;
using Wizard.Common;

namespace Wizard.Core
{

    /// <summary>
    /// Ermöglicht das Abrufen des aktuellen Spiel-Status.
    /// Die Informationen werden statisch angeboten, damit sie aus verschiedenen Komponenten heraus verwendet
    /// werden können. Aus fremden Assemblies heraus können die Informationen nur gelesen, aber nicht verändert
    /// werden. Im selben Assembly können die verschiedenen Setter und speziellen Methoden verwendet werden, um
    /// die Spielinformationen zu setzen.
    /// Wichtig: Der GameScope dient als reiner Datencontainer, die enthaltenen Informationen müssen im Spielablauf
    /// von außen gepflegt werden. Der GameScope aktualisiert die enthaltenen Informationen niemals selbstständig.
    /// </summary>
    public class GameScope
    {

        //TODO Bei "get" immer Kopien zurückgeben (niemals Referenzen)
        //TODO Standardwerte für "get" definieren und setzen (falls Wert vom Game nicht gesetzt wurde)

        private int _playerCount;
        private int _roundCount;
        private List<PlayerInformation> _playerInfoList;
        private Color _currentTrump;
        private Color _currentPlayColor;
        private Trick _currentTrick;
        private Trick _lastTrick;
        private int _lastTrickWinnerPlayerNumber;

        /// <summary>
        /// Konstruktor unsichtbar, da nur der statische Zugriff erlaubt ist
        /// </summary>
        private GameScope()
        {
        }

        #region Properties

        /// <summary>
        /// Anzahl der Spieler, die am Spiel teilnehmen.
        /// </summary>
        public int PlayerCount
        {
            get { return _playerCount; }
            internal set { _playerCount = value; }
        }

        /// <summary>
        /// Anzahl der bisher gespielten (und beendeten) Runden.
        /// </summary>
        public int RoundCount
        {
            get { return _roundCount; }
            internal set { _roundCount = value; }
        }

        /// <summary>
        /// Liste, die pro Spieler eine <c>PlayerInfo</c>-Struktur enthält, aus der
        /// verschiedene Informationen abgerufen werden können.
        /// </summary>
        public List<PlayerInformation> PlayerInfoList
        {
            get { return _playerInfoList; }
            internal set { _playerInfoList = value; }
        }

        /// <summary>
        /// Der aktuelle Trumpf.
        /// </summary>
        public Color CurrentTrump
        {
            get { return _currentTrump; }
            internal set { _currentTrump = value; }
        }

        /// <summary>
        /// Die aktuelle Spielfarbe.
        /// </summary>
        public Color CurrentPlayColor
        {
            get { return _currentPlayColor; }
            internal set { _currentPlayColor = value; }
        }

        /// <summary>
        /// Der aktuelle Stich (also die Karten, die aktuell auf dem Tisch liegen).
        /// </summary>
        public Trick CurrentTrick
        {
            get { return _currentTrick; }
            internal set { _currentTrick = value; }
        }

        /// <summary>
        /// Der vorherige (also zuletzt beendete) Stich.
        /// </summary>
        public Trick LastTrick
        {
            get { return _lastTrick; }
            internal set { _lastTrick = value; }
        }

        /// <summary>
        /// Die Nummer des Spielers, der den letzten Stich bekommen hat.
        /// </summary>
        public int LastTrickWinnerPlayerNumber
        {
            get { return _lastTrickWinnerPlayerNumber; }
            internal set { _lastTrickWinnerPlayerNumber = value; }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Fügt eine Karte zur Liste der Tischkarten hinzu.
        /// Kann verwendet werden, wenn eine neue Karte gespielt wird.
        /// </summary>
        /// <param name="card">Die hinzuzufügende Karte</param>
        internal void AddCardToCurrentTrickCards(Card card)
        {
            _currentTrick.Add(card);
        }

        /// <summary>
        /// Ersetzt die übergebene <c>PlayerInfo</c>-Struktur oder fügt sie - falls vorhanden - neu ein.
        /// </summary>
        /// <param name="playerInfo">PlayerInfo-Struktur, die eingesetzt werden kann</param>
        internal void ReplaceOrAddPlayerInfo(PlayerInformation playerInfo)
        {
            int playerNumber = playerInfo.playerNumber;

            // Suchen
            PlayerInformation found = _playerInfoList.Find(pi => pi.playerNumber == playerNumber);

            // Ersetzen oder neu einfügen
            if (found.Equals(default(PlayerInformation)))
            {
                _playerInfoList.Add(playerInfo);
            }
            else
            {
                _playerInfoList[_playerInfoList.IndexOf(found)] = playerInfo;
            }
        }

        #endregion

        #region Static

        private static GameScope _scope = null;

        public static GameScope CS
        {
            get
            {
                if (_scope == null)
                {
                    _scope = new GameScope();
                }

                return _scope;
            }
        }

        #endregion

    }

}