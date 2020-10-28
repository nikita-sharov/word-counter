using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public sealed class PerformanceOptimizedParser : Parser
    {
        /// <summary>
        /// A parallelized implementation of an <see cref="IParser"/>, being more performant but
        /// less memory-efficient than the <see cref="PerformanceOptimizedParser"/>.
        /// </summary>
        /// <remarks>Reads the whole text file at once counting word occurencies in parallel afterwards.</remarks>
        public PerformanceOptimizedParser()
            : this(new LazyTokenizer())
        {
        }

        public PerformanceOptimizedParser(ITokenizer tokenizer)
            : base(tokenizer)
        {
        }

        public override Task<WordCounting> ParseAsync(
            string path, Encoding encoding, CancellationToken cancellationToken = default)
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
                        globalCounting.AddOrUpdate(wordCount.Key, 1, (word, oldValue) => oldValue + wordCount.Value);
                    }
                });

            var counting = new WordCounting(globalCounting);
            return Task.FromResult(counting);
        }
    }
}
