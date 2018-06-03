using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    static class Utils
    {
        [ThreadStatic]
        private static Random _random;
        // Singleton random instance to have better random number generation
        public static int NextRandom(int exclusiveUpperBound)
        {
            return NextRandom(0, exclusiveUpperBound);
        }
        public static int NextRandom(int inclusiveLowerBound, int exclusiveUpperBound)
        {
            if (_random == null)
            {
                _random = new Random();
            }

            return _random.Next(inclusiveLowerBound, exclusiveUpperBound);
        }

    }
}
