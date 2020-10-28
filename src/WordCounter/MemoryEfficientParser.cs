using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    /// <summary>
    /// A sequential implementation of an <see cref="IParser"/>, being more memory-efficient and
    /// snappier in cancelation but less performant than the <see cref="HighPerformanceParser"/>.
    /// </summary>
    /// <remarks>Reads the text file line by line counting word occurencies.</remarks>
    public sealed class MemoryEfficientParser : Parser
    {
        public MemoryEfficientParser()
            : this(new LazyTokenizer())
        {
        }

        public MemoryEfficientParser(ITokenizer tokenizer)
            : base(tokenizer)
        {
        }

        public override async Task<WordCounting> ParseAsync(
            string path, Encoding encoding, CancellationToken cancellationToken = default)
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
