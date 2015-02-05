using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wizard.Common;

namespace Wizard.Test
{
    /// <summary>
    /// Testet die Klasse <c>Card</c>.
    /// </summary>
    [TestClass]
    public class CardTest
    {
        public CardTest(){ }

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
        public void TestConstructor_ColorAndValue()
        {
            Card card = new Card(Color.Blue, 12);

            Assert.AreEqual(Color.Blue, card.Color);
            Assert.AreEqual(12, card.Value);

            try
            {
                card = new Card(Color.Blue, 15);
                Assert.Fail();
            }
            catch(ArgumentException)
            {
            }
        }

        [TestMethod]
        public void TestConstructor_CloneCard()
        {
            Card card = new Card(Color.Blue, 12);

            Assert.AreEqual(Color.Blue, card.Color);
            Assert.AreEqual(12, card.Value);

            Card card2 = new Card(card);

            Assert.AreEqual(Color.Blue, card2.Color);
            Assert.AreEqual(12, card2.Value);
        }

        [TestMethod]
        public void TestMethod_ToString()
        {
            Card card = new Card(Color.Blue, 12);

            Assert.AreEqual("[Blue12]", card.ToString());
        }

    }
}