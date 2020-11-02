using System.Collections.Generic;

namespace WordCounter.WinForms
{
    public sealed class OrderedWordCounting : Dictionary<int, KeyValuePair<string, int>>
    {
        ////public static OrderedWordCounting OrderByWordCountDescending(WordCounting counting)
        ////{
        ////    var orderedCounting = new OrderedWordCounting();
        ////    IOrderedEnumerable<KeyValuePair<string, int>> orderedWordCounts =
        ////        counting.OrderByDescending(wordCount => wordCount.Value);

        ////    int index = 0;
        ////    foreach (var wordCount in orderedWordCounts)
        ////    {
        ////        orderedCounting.Add(index, wordCount);
        ////        index += 1;
        ////    }

        ////    return orderedCounting;
        ////}
    }
}
