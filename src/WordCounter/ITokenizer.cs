using System.Collections.Generic;

namespace WordCounter
{
    public interface ITokenizer
    {
        IEnumerable<string> Tokenize(string text);
    }
}
