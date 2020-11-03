using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace WordCounter.Tests
{
    [TestClass]
    [Ignore("Exploratory testing")]
    public class FileTests
    {
        private static string BibleText;

        public static string GetBibleText()
        {
            if (BibleText == null)
            {
                BibleText = File.ReadAllText(FilePath.KingJamesBible, Encoding.UTF8);
            }

            return BibleText;
        }

        [TestMethod]
        public void ReadAllBytes()
        {
            File.ReadAllBytes(FilePath.ImdbTitleAkasSubset);
        }

        [TestMethod]
        public void ReadAllText()
        {
            // OutOfMemoryException potential
            File.ReadAllText(FilePath.ImdbTitleAkasSubset);
        }

        [TestMethod]
        public void ReadAllLines()
        {
            File.ReadAllLines(FilePath.ImdbTitleAkasSubset);
        }
    }
}
