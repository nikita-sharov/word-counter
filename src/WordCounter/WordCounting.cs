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

        public static WordCounting Merge(IEnumerable<WordCounting> countings)
        {
            var mergedCountings = new WordCounting();
            foreach (WordCounting counting in countings)
            {
                foreach (KeyValuePair<string, int> wordCount in counting)
                {
                    if (mergedCountings.ContainsKey(wordCount.Key))
                    {
                        mergedCountings[wordCount.Key] += wordCount.Value;
                    }
                    else
                    {
                        mergedCountings.Add(wordCount.Key, wordCount.Value);
                    }
                }
            }

            return mergedCountings;
        }
    }
}
