using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wizard.Common;
using Wizard.Core;

namespace Wizard.Test
{
    /// <summary>
    /// Testet Methode <c>Clone()</c>
    /// </summary>
    [TestClass]
    public class CloneTest
    {
        public CloneTest() { }

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
        public void TestMethod_Clone_SimpleTypes()
        {
            int a = 1;
            Assert.AreEqual(1, CloneTools.Clone(a));

            string s = "Test";
            Assert.AreEqual("Test", CloneTools.Clone(s));
        }

        [TestMethod]
        public void TestMethod_Clone_List()
        {
            List<Card> lst = new List<Card>() { new Card(Color.Red, 11), new Card(Color.None, 1) };
            Assert.AreNotEqual(lst, CloneTools.Clone(lst));
            Assert.AreNotEqual(lst[0], CloneTools.Clone(lst[0]));
            Assert.AreNotEqual(lst[1], CloneTools.Clone(lst[1]));
            Assert.AreEqual(2, CloneTools.Clone(lst).Count);
            Assert.AreEqual(Color.Red, CloneTools.Clone(lst)[0].Color);
            Assert.AreEqual(11, CloneTools.Clone(lst)[0].Value);
            Assert.AreEqual(Color.None, CloneTools.Clone(lst)[1].Color);
            Assert.AreEqual(1, CloneTools.Clone(lst)[1].Value);
        }

        [TestMethod]
        public void TestMethod_Clone_Trick()
        {
            HumanPlayer p = new HumanPlayer("TestPlayer", 1);
            Trick t = new Trick();
            t.Player = p;
            t.Add(new Card(Color.Red, 9));
            t.Add(new Card(Color.Yellow, 8));

            Assert.AreNotEqual(t, CloneTools.Clone(t));
            Assert.AreNotEqual(p, CloneTools.Clone(t).Player);
            Assert.AreNotEqual(t.Get(0), CloneTools.Clone(t).Get(0));
            Assert.AreNotEqual(t.Get(1), CloneTools.Clone(t).Get(1));
            Assert.AreEqual(2, CloneTools.Clone(t).CardCount);
            Assert.AreEqual("TestPlayer", CloneTools.Clone(t).Player.Name);
            Assert.AreEqual(1, CloneTools.Clone(t).Player.PlayerNumber);
            Assert.AreEqual(Color.Red, CloneTools.Clone(t).Get(0).Color);
            Assert.AreEqual(9, CloneTools.Clone(t).Get(0).Value);
            Assert.AreEqual(Color.Yellow, CloneTools.Clone(t).Get(1).Color);
            Assert.AreEqual(8, CloneTools.Clone(t).Get(1).Value);
        }

    }

}