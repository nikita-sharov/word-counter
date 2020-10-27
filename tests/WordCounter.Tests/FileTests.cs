using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace WordCounter.Tests
{
    [TestClass]
    public class FileTests
    {
        // https://datasets.imdbws.com/title.principals.tsv.gz (1.7 GB, uncompressed)
        private const string Path = "data/imdb_title-principals.tsv";

        [DataTestMethod]
        [DataRow(Path)]
        public void ReadAllBytes(string path)
        {
            File.ReadAllBytes(path);
        }

        [DataTestMethod]
        [DataRow(Path)]
        public void ReadAllText(string path)
        {
            // OutOfMemoryException potential
            File.ReadAllText(path);
        }

        [DataTestMethod]
        [DataRow(Path)]
        public void ReadAllLines(string path)
        {
            File.ReadAllLines(path);
        }
    }
}
