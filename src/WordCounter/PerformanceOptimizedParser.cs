using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// sluggish in cancelation and less memory-efficient than the <see cref="PerformanceOptimizedParser"/>.
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
            string[] lines = File.ReadAllLines(path, encoding);
            cancellationToken.ThrowIfCancellationRequested();

            var countings = new ConcurrentBag<WordCounting>();
            var options = new ParallelOptions
            {
                CancellationToken = cancellationToken
            };

            ParallelLoopResult loopResult = Parallel.For(
                fromInclusive: 0,
                toExclusive: lines.Length,
                parallelOptions: options,
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
                    countings.Add(localCounting);
                });

            Debug.Assert(loopResult.IsCompleted);
            cancellationToken.ThrowIfCancellationRequested();
            WordCounting mergedCountings = WordCounting.Merge(countings);
            return Task.FromResult(mergedCountings);
        }
    }
}
