using System.Configuration;
using Wizard.IO;
using Wizard.Core;

namespace Wizard
{

    public class Program
    {

        public static void Main(string[] args)
        {
            GameEngine game = new GameEngine();
            game.Start();
            game.Finish();
        }

    }

}