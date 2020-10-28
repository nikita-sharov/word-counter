using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordCounter.Tests
{
    public abstract class ITokenizerTests
    {
        public ITokenizerTests(ITokenizer tokenizer)
        {
            Tokenizer = tokenizer;
        }

        protected ITokenizer Tokenizer { get; private set; }

        [TestMethod]
        public void Tokenize()
        {
            string[] words = Tokenizer.Tokenize(" a\n  b \t c  ").ToArray();
            CollectionAssert.AreEquivalent(new string[] { "a", "b", "c" }, words);
        }

        [TestMethod]
        public void TokenizeBible()
        {
            string text = FileTests.GetBibleText();

            string[] allWords = Tokenizer.Tokenize(text).ToArray();
            Assert.IsNotNull(allWords);
            Assert.AreEqual(824_225, allWords.Length); // compare to 749_264 from the IParserTests.cs

            string[] uniqueWords = allWords.Distinct().ToArray();
            Assert.AreEqual(34_081, uniqueWords.Length); // compare to 30_141, respectively
        }
    }
}
