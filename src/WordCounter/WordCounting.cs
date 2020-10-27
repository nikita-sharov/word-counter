using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public class WordCounting : Dictionary<string, int>
    {
        private WordCounting() { }

        public static WordCounting Parse(string path, Encoding encoding)
        {
            return null;
        }

        public static async Task<WordCounting> ParseAsync(
            string path, Encoding encoding, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
