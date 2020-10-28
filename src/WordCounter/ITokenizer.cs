using System.Collections.Generic;

namespace WordCounter
{
    public interface ITokenizer
    {
        /// <summary>
        /// Splits given text in words separated by white space, ignoring any punctuation marks.
        /// </summary>
        IEnumerable<string> Tokenize(string text);
    }
}
