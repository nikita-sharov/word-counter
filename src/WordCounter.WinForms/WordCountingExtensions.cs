using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordCounter.WinForms
{
    public static class WordCountingExtensions
    {
        public static OrderedWordCounting ToOrderedWordCounting(this WordCounting counting)
        {
            var orderedCounting = new OrderedWordCounting();
            IOrderedEnumerable<KeyValuePair<string, int>> orderedWordCounts = counting.OrderByWordCountDescending();
            int index = 0;
            foreach (var wordCount in orderedWordCounts)
            {
                orderedCounting.Add(index, wordCount);
                index += 1;
            }

            return orderedCounting;
        }
    }
}
