using System;
using System.Text;

namespace WordCounter
{
    /// <summary>
    /// Allows custom <see cref="EncodingInfo.DisplayName"/>s.
    /// </summary>
    /// <seealso cref="EncodingInfo"/>
    public sealed class CustomEncodingInfo
    {
        public static readonly CustomEncodingInfo UTF8 =
            new CustomEncodingInfo("utf-8", "Unicode (UTF-8)");

        public static readonly CustomEncodingInfo ANSI =
            new CustomEncodingInfo("windows-1252", "Western European (Windows-1252 aka ANSI)");

        private CustomEncodingInfo(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        public string Name { get; private set; }

        public string DisplayName { get; private set;  }

        public override bool Equals(object obj) => Equals(obj as CustomEncodingInfo);

        public bool Equals(CustomEncodingInfo other) =>
            (other != null) && Name.Equals(other.Name, StringComparison.Ordinal);

        public override int GetHashCode() => Name.GetHashCode();
    }
}
