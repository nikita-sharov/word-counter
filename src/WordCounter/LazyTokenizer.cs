using System.Collections.Generic;

namespace WordCounter
{
    public sealed class LazyTokenizer : ITokenizer
    {
        public IEnumerable<string> Tokenize(string text)
        {
            int wordStartIndex = -1;
            for (int charIndex = 0; charIndex < text.Length; charIndex++)
            {
                if (char.IsWhiteSpace(text[charIndex]))
                {
                    if (wordStartIndex >= 0)
                    {

                        string word = text.Substring(wordStartIndex, charIndex - wordStartIndex);
                        wordStartIndex = -1;
                        yield return word;
                    }
                }
                else
                {
                    if (wordStartIndex < 0)
                    {
                        wordStartIndex = charIndex;
                    }
                }
            }
        }
    }
}
