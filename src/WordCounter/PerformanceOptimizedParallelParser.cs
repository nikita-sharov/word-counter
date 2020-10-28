using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public sealed class PerformanceOptimizedParallelParser : IParser
    {
        public ITokenizer Tokenizer { get; private set; } = new LazyTokenizer();

        public Task<WordCounting> ParseAsync(string path, Encoding encoding, CancellationToken cancellationToken)
        {
            var globalCounting = new ConcurrentDictionary<string, int>();

            string[] lines = File.ReadAllLines(path, encoding);
            cancellationToken.ThrowIfCancellationRequested();

            Parallel.For(
                fromInclusive: 0,
                toExclusive: lines.Length,
                localInit: () => new WordCounting(),
                body: (lineIndex, loopState, localCounting) =>
                {
                    string line = lines[lineIndex];
                    IEnumerable<string> words = Tokenizer.Tokenize(line);
                    foreach (string word in words)
                    {
                        if (localCounting.ContainsKey(word))
                        {
                            localCounting[word] += 1;
                        }
                        else
                        {
                            localCounting.Add(word, 1);
                        }
                    }

                    return localCounting;
                },
                localFinally: (localCounting) =>
                {
                    foreach (KeyValuePair<string, int> wordCount in localCounting)
                    {
                        globalCounting.AddOrUpdate(wordCount.Key, 1, (word, oldValue) => oldValue += wordCount.Value);
                    }
                });

            var counting = new WordCounting(globalCounting);
            return Task.FromResult(counting);
        }
    }
}
