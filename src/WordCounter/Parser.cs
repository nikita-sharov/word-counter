using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public abstract class Parser : IParser
    {
        public Parser(ITokenizer tokenizer)
        {
            Tokenizer = tokenizer;
        }

        public ITokenizer Tokenizer { get; private set; }

        public virtual Task<WordCounting> ParseAsync(
            string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
