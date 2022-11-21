namespace System.Text;

/// <summary>A collection of methods that expose the functionality of <see cref="System.Text.Encoding"/>'s public static instance members statically.</summary>
public static class TextEncodingExtensions
{
    /// <summary>Calls <see cref="Encoding.UTF8" />.GetBytes(<paramref name="s"/>)</summary>
    /// <param name="s">The string to encode</param>
    /// <returns>The UTF8 encoded byte array</returns>
    public static byte[] GetUTF8Bytes(string s) => UTF8.GetBytes(s);
    /// <inheritdoc cref="GetUTF8Bytes(string)" />
    public static byte[] ToUTF8Bytes(this string s) => GetUTF8Bytes(s);
    /// <summary>Calls <see cref="Encoding.UTF8" />.GetString(<paramref name="bytes"/>)</summary>
    /// <param name="bytes">The byte array to decode</param>
    /// <returns>The UTF8 decoded string</returns>
    public static string GetUTF8String(byte[] bytes) => UTF8.GetString(bytes);
    /// <inheritdoc cref="GetUTF8String(byte[])" />
    public static string ToUTF8String(this byte[] bytes) => GetUTF8String(bytes);

    /// <summary>Calls <see cref="Encoding.Unicode" />.GetBytes(<paramref name="s"/>)</summary>
    /// <param name="s">The string to encode</param>
    /// <returns>The Unicode encoded byte string</returns>
    public static byte[] GetUnicodeBytes(string s) => Encoding.Unicode.GetBytes(s);
    /// <inheritdoc cref="GetUnicodeBytes(string)" />
    public static byte[] ToUnicodeBytes(this string s) => GetUnicodeBytes(s);
    /// <summary>Calls <see cref="Encoding.Unicode" />.GetString(<paramref name="bytes"/>)</summary>
    /// <param name="bytes">The byte array to decode</param>
    /// <returns>The Unicode decoded string</returns>
    public static string GetUnicodeString(byte[] bytes) => Encoding.Unicode.GetString(bytes);
    /// <inheritdoc cref="GetUnicodeString(byte[])" />
    public static string ToUnicodeString(this byte[] bytes) => GetUnicodeString(bytes);

    /// <summary>Calls <see cref="Encoding.ASCII" />.GetBytes(<paramref name="s"/>)</summary>
    /// <param name="s">The string to encode</param>
    /// <returns>The ASCII encoded byte string</returns>
    public static byte[] GetAsciiBytes(string s) => ASCII.GetBytes(s);
    /// <summary>Calls <see cref="Encoding.ASCII" />.GetString(<paramref name="bytes"/>)</summary>
    /// <param name="bytes">The byte array to decode</param>
    /// <returns>The ASCII decoded string</returns>
    public static string GetAsciiString(byte[] bytes) => ASCII.GetString(bytes);

    /// <summary>Calls <see cref="Encoding.UTF7" />.GetBytes(<paramref name="s"/>)</summary>
    /// <param name="s">The string to encode</param>
    /// <returns>The UTF7 encoded byte string</returns>
#if NET6_0_OR_GREATER
    [Obsolete("Encoding.UTF7' is obsolete: The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead.", DiagnosticId = "SYSLIB0001", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
#else
    [Obsolete("Encoding.UTF7' is obsolete: The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead.")]
#endif
    public static byte[] GetUTF7Bytes(string s) => UTF7.GetBytes(s);
    /// <summary>Calls <see cref="UTF7" />.GetString(<paramref name="bytes"/>)</summary>
    /// <param name="bytes">The byte array to decode</param>
    /// <returns>The UTF7 decoded string</returns>
#if NET6_0_OR_GREATER
    [Obsolete("Encoding.UTF7' is obsolete: The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead.", DiagnosticId = "SYSLIB0001", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
#else
    [Obsolete("Encoding.UTF7' is obsolete: The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead.")]
#endif
    public static string GetUTF7String(byte[] bytes) => UTF7.GetString(bytes);
}
