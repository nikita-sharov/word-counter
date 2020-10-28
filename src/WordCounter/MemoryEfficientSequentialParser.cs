using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public sealed class MemoryEfficientSequentialParser : IParser
    {
        ITokenizer Tokenizer { get; set; } = new RegexTokenizer();

        public async Task<WordCounting> ParseAsync(string path, Encoding encoding, CancellationToken cancellationToken)
        {
            var counting = new WordCounting();
            using (var reader = new StreamReader(path, encoding))
            {
                string line = await reader.ReadLineAsync();
                while (line != null)
                {
                    IEnumerable<string> words = Tokenizer.Tokenize(line);
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
                    }

                    cancellationToken.ThrowIfCancellationRequested();
                    line = await reader.ReadLineAsync();
                }
            }

            return counting;
        }
    }
}
