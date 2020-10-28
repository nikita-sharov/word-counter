using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordCounter
{
    public sealed class RegexTokenizer : ITokenizer
    {
        public IEnumerable<string> Tokenize(string text)
        {
            const string AdjacentWhiteSpace = @"\s+";
            string trimmedText = text.Trim(); // avoids empty string tokens
            return Regex.Split(trimmedText, AdjacentWhiteSpace);
        }
    }
}
