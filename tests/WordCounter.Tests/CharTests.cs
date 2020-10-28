using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    [Ignore("Exploratory testing")]
    public sealed class CharTests
    {
        [TestMethod]
        public void IsWhiteSpace()
        {
            // See: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace#remarks
            // See: https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions#character-escapes-in-net
            Assert.IsTrue(char.IsWhiteSpace('\t')); // CHARACTER TABULATION (U+0009 / 0x09)
            Assert.IsTrue(char.IsWhiteSpace('\n')); // LINE FEED (U+000A / 0x0A)
            Assert.IsTrue(char.IsWhiteSpace('\r')); // CARRIAGE RETURN (U+000D / 0x0D)
        }
    }
}
