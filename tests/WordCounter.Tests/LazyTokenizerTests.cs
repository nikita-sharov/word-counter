using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public sealed class LazyTokenizerTests : ITokenizerTests
    {
        public LazyTokenizerTests()
            : base(new LazyTokenizer())
        {
        }
    }
}
