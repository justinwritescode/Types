namespace JustinWritesCode;

public static class Constants
{
	public static class Uris
	{
		public static class Strings
		{
			/// <summary>The base URI for justinwritesode, <inheritdoc cref="JustinWritesCodeUriBaseString" path="/value/node()" /></summary>
			/// <value>https://justinwritescode.com/</value>
			public const string JustinWritesCodeUriBaseString = "https://justinwritescode.com/";
		}

		/// <inheritdoc cref="Strings.JustinWritesCodeUriBaseString" />
		public static readonly uri JustinWritesCodeUriBase = new(Strings.JustinWritesCodeUriBaseString);
	}
}
