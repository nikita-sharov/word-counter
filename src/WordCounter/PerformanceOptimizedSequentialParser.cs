using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public sealed class PerformanceOptimizedSequentialParser : IParser
    {
        public ITokenizer Tokenizer { get; set; } = new LazyTokenizer();

        public Task<WordCounting> ParseAsync(
            string path, Encoding encoding, CancellationToken cancellationToken)
        {
            var counting = new WordCounting();

            byte[] bytes = File.ReadAllBytes(path);
            cancellationToken.ThrowIfCancellationRequested();

            string text = encoding.GetString(bytes);
            cancellationToken.ThrowIfCancellationRequested();

            IEnumerable<string> words = Tokenizer.Tokenize(text);
            foreach (string word in words)
            {
                if (counting.ContainsKey(word))
                {
                    counting[word] += 1;
                }
                else
                {
                    counting.Add(word, 1);
                }

                cancellationToken.ThrowIfCancellationRequested();
            }

            return Task.FromResult(counting);
        }
    }
}
