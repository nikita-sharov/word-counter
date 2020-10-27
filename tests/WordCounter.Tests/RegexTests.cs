using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace WordCounter.Tests
{
    [TestClass]
    ////[Ignore("Exploratory testing")]
    public class RegexTests
    {
        [TestMethod]
        public void Split()
        {
            string[] words = Regex.Split("a\n b  c", @"\s+");
            CollectionAssert.AreEquivalent(new string[] { "a", "b", "c" }, words);
        }

        [TestMethod]
        public void Split_Untrimmed()
        {
            string[] words = Regex.Split(" a\n b  c ", @"\s+");
            CollectionAssert.AreEquivalent(new string[] { "", "a", "b", "c" }, words);
        }
    }
}
