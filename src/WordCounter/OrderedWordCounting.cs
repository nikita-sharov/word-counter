using System.Collections.Generic;
using System.Linq;

namespace WordCounter
{
    public sealed class OrderedWordCounting : Dictionary<int, KeyValuePair<string, int>>
    {
        public static OrderedWordCounting OrderByWordCountDescending(WordCounting counting)
        {
            var orderedCounting = new OrderedWordCounting();
            IOrderedEnumerable<KeyValuePair<string, int>> pairs =
                counting.OrderByDescending(wordCount => wordCount.Value);

            int index = 0;
            foreach (var wordCount in pairs)
            {
                orderedCounting.Add(index, wordCount);
                index += 1;
            }

            return orderedCounting;
        }
    }
}
