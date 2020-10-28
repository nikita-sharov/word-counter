using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace WordCounter.Tests
{
    [TestClass]
    [Ignore("Exploratory testing")]
    public class FileTests
    {
        // https://datasets.imdbws.com/title.principals.tsv.gz
        ////public const string Path = "data/imdb_title-principals.tsv"; // 1.7 GB, uncompressed

        private static string BibleText;

        public static string GetBibleText()
        {
            if (BibleText == null)
            {
                BibleText = File.ReadAllText("data/gutenberg_king-james-bible.txt", Encoding.UTF8);
            }

            return BibleText;
        }

        [DataTestMethod]
        public void ReadAllBytes()
        {
            File.ReadAllBytes(FilePath.ImdbTitleAkasSubset);
        }

        [DataTestMethod]
        public void ReadAllText()
        {
            // OutOfMemoryException potential
            File.ReadAllText(FilePath.ImdbTitleAkasSubset);
        }

        [DataTestMethod]
        public void ReadAllLines()
        {
            File.ReadAllLines(FilePath.ImdbTitleAkasSubset);
        }
    }
}
