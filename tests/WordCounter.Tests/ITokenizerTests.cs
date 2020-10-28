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
            string[] words = Tokenizer.Tokenize(text).ToArray();
            Assert.IsNotNull(words);
            Assert.AreEqual(824225, words.Length);
        }
    }
}
