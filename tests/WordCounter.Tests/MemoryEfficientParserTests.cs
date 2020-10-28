using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public sealed class MemoryEfficientParserTests : IParserTests
    {
        public MemoryEfficientParserTests()
            : base(new MemoryEfficientParser())
        {
        }
    }
}
