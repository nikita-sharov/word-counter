using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public sealed class PerformanceOptimizedParserTests : IParserTests
    {
        public PerformanceOptimizedParserTests()
            : base(new PerformanceOptimizedParser())
        {
        }
    }
}
