using System.Collections.Generic;
using System.Linq;

namespace WordCounter
{
    public sealed class WordCounting : Dictionary<string, int>
    {
        public WordCounting() { }

        public WordCounting(IDictionary<string, int> dictionary)
            : base(dictionary)
        {
        }

        public int TotalWordCount => Values.Sum();
    }
}
