namespace WordCounter.Tests
{
    public static class FilePath
    {
        /// <summary>
        /// The King James Version of the Bible (UTF-8, 4.3 MB)
        /// </summary>
        /// <seealso href="http://www.gutenberg.org/ebooks/10"/>
        public const string KingJamesBible = @"..\..\..\data\gutenberg_king-james-bible.txt";

        /// <summary>
        /// Les Misérables by Victor Hugo (UTF-8, 3.2 MB)
        /// </summary>
        /// <seealso href="http://www.gutenberg.org/ebooks/135"/>
        public const string LesMiserables = @"..\..\..\data\gutenberg_les-miserables.txt";

        /// <summary>
        /// War and Peace by Leo Tolstoy (UTF-8, 3.2 MB)
        /// </summary>
        /// <seealso href="http://www.gutenberg.org/ebooks/2600"/>
        public const string WarAndPiece = @"..\..\..\data\gutenberg_war-and-piece.txt";

        /// <summary>
        /// Localized IMDB titles (UTF-8, 1.1 GB, uncompressed)
        /// </summary>
        /// <seealso href="https://datasets.imdbws.com/title.akas.tsv.gz"/>
        public const string ImdbTitleAkas = @"..\..\..\data\imdb_title-akas.tsv";

        /// <summary>
        /// Localized IMDB titles (UTF-8, 50 MB subset)
        /// </summary>
        /// <seealso href="https://datasets.imdbws.com/title.akas.tsv.gz"/>
        public const string ImdbTitleAkasSubset = @"..\..\..\data\imdb_title-akas_subset.tsv";
    }
}
