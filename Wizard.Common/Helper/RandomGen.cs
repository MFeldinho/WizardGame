using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizard.Common
{

    public class RandomGen
    {

        private static Random _rand = null;

        public static Random Rand
        {
            get
            {
                if (_rand == null)
                {
                    TimeSpan millis = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0));
                    _rand = new Random(millis.Milliseconds);
                }

                return _rand;
            }
        }

    }

}