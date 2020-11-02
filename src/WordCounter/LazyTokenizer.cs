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
                    bool isFirstAfterWord = wordStartIndex >= 0;
                    if (isFirstAfterWord)
                    {
                        int wordLength = charIndex - wordStartIndex;
                        string word = text.Substring(wordStartIndex, wordLength);
                        wordStartIndex = -1;
                        yield return word;
                    }
                }
                else
                {
                    bool isFirstOfNewWord = wordStartIndex < 0;
                    if (isFirstOfNewWord)
                    {
                        wordStartIndex = charIndex;
                    }
                }
            }
        }
    }
}
