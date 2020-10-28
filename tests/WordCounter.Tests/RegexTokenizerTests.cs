using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public sealed class RegexTokenizerTests : ITokenizerTests
    {
        public RegexTokenizerTests()
            : base(new RegexTokenizer())
        {
        }
    }
}
