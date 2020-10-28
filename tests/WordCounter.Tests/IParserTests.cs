using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Tests
{
    public abstract class IParserTests
    {
        public IParserTests(IParser parser)
        {
            Parser = parser;
        }

        protected IParser Parser { get; private set; }

        [TestMethod]
        public async Task ParseBibleAsync()
        {
            WordCounting counting = await Parser.ParseAsync(FilePath.KingJamesBible, Encoding.UTF8);
            Assert.IsNotNull(counting);
            Assert.AreEqual(30_141, counting.Count);
            Assert.AreEqual(749_264, counting.TotalWordCount);
        }

        [TestMethod]
        [Ignore("Very long-running test; requires the full dataset")]
        public async Task ParseImdbTitleAkasAsync()
        {
            WordCounting counting = await Parser.ParseAsync(FilePath.ImdbTitleAkas, Encoding.UTF8);
            Assert.IsNotNull(counting);
        }

        [TestMethod]
        [Ignore("Long-running test")]
        public async Task ParseImdbTitleAkasSubsetAsync()
        {
            WordCounting counting = await Parser.ParseAsync(FilePath.ImdbTitleAkasSubset, Encoding.UTF8);
            Assert.IsNotNull(counting);
        }
    }
}
