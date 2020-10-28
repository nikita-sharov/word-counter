using System;
using System.Text;

namespace WordCounter
{
    public static class SupportedEncoding
    {
        private static readonly CustomEncodingInfo[] Encodings = new CustomEncodingInfo[]
        {
            CustomEncodingInfo.ANSI,
            CustomEncodingInfo.UTF8
        };

        /// <summary>
        /// Provides .NET Core support for additional code-page based encodings, including Windows-1252 (aka ANSI).
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netcore-3.1#list-of-encodings"/>
        static SupportedEncoding() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        /// <summary>
        /// Returns all encodings supported by the application.
        /// </summary>
        /// <seealso cref="Encoding.GetEncodings"/>
        public static CustomEncodingInfo[] GetEncodings() => Encodings;

        public static Encoding GetEncoding(CustomEncodingInfo encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            return Encoding.GetEncoding(encoding.Name);
        }
    }
}
