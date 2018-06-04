using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    static class Utils
    {
        [ThreadStatic]
        private static Random _random;
        // Singleton random instance to achive better random number generation
        public static int NextRandom(int exclusiveUpperBound)
        {
            if (_random == null)
            {
                _random = new Random();
            }
            return _random.Next(exclusiveUpperBound);
        }

        public static void WriteToFile(string filename, string content)
        {
            using (StreamWriter Writer = new StreamWriter(filename))
            {
                Writer.WriteLine(content);
            }
        }

    }
}
