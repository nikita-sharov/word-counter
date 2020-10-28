using System.Collections.Generic;

namespace WordCounter
{
    public sealed class WordCounting : Dictionary<string, int>
    {
        public WordCounting() { }

        public WordCounting(IDictionary<string, int> dictionary)
            : base(dictionary)
        {
        }
    }
}
