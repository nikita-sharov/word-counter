using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public sealed class HighPerformanceParserTests : IParserTests
    {
        public HighPerformanceParserTests()
            : base(new HighPerformanceParser())
        {
        }
    }
}
