namespace JustinWritesCode.Extensions;

public static class UriExtensions
{
    public static uri? ToUri(this string uriString, bool throwOnInvalidUri = true)
    {
        if (uriString is null)
            throw new ArgumentNullException(nameof(uriString));
        if (Uri.TryCreate(uriString, UriKind.Absolute, out var uri))
            return uri;
        if (throwOnInvalidUri)
            throw new ArgumentException("The provided string is not a valid URI.", nameof(uriString));
        return null;
    }
}
