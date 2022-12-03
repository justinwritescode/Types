namespace JustinWritesCode;

public static class Constants
{
    public static class Uris
    {
        public static class Strings
        {
            /// <summary>The base URI for justinwritesode, <inheritdoc cref="JustinWritesCodeUriBaseString" path="/value/node()" /></summary>
            /// <value><c>https://justinwritescode.com/</c></value>
            public const string JustinWritesCodeBaseUriString = "https://justinwritescode.com/";
        }

        /// <inheritdoc cref="Strings.JustinWritesCodeBaseUriString" />
        public static readonly uri JustinWritesCodeBaseUri = new(Strings.JustinWritesCodeBaseUriString);
    }
}
