using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wizard.Common;

namespace Wizard.Test
{
    /// <summary>
    /// Testet die Klasse <c>Trick</c>.
    /// </summary>
    [TestClass]
    public class TrickTest
    {
        public TrickTest() { }

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Textkontext mit Informationen über
        ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        //
        // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
        //
        // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestConstructor()
        {
            Trick trick = new Trick();

            Assert.IsNull(trick.Player);
            Assert.AreEqual(0, trick.CardCount);
        }

        [TestMethod]
        public void TestMethod_Add_Get()
        {
            Trick trick = new Trick();

            Assert.AreEqual(0, trick.CardCount);

            Card c = new Card(Color.Red, 11);
            trick.Add(c);
            Assert.AreEqual(1, trick.CardCount);
            Assert.AreEqual(c, trick.Get(0));

            try
            {
                trick.Get(1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void TestMethod_Player_GetSet()
        {
            Trick trick = new Trick();

            Assert.IsNull(trick.Player);

            TestPlayer player = new TestPlayer();
            trick.Player = player;
            Assert.AreEqual(player, trick.Player);
        }

        // Private Player-Klasse für Testzwecke
        private class TestPlayer : AbstractPlayer
        {
            public TestPlayer() : base("TestPlayer", 1, true)
            {
            }

            public override Color ChooseTrump()
            {
                throw new NotImplementedException();
            }

            public override int GuessTrickCount()
            {
                throw new NotImplementedException();
            }

            public override Card PlayCard()
            {
                throw new NotImplementedException();
            }
        }

    }

}