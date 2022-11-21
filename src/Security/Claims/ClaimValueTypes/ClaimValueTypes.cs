
namespace JustinWritesCode.Security.Claims;
public static class ClaimValueTypes
{
	public static class Namespaces
	{
		/// <value><c>TR/</c></value>
		public const string TR = $"{nameof(TR)}/";
		/// <value><c>xmlschema11-2/</c></value>
		public const string XmlSchema11_2 = $"xmlschema11-2/";
		/// <value><c>#anyURI</c></value>
		public const string AnyUriAnchor = "#anyURI";
		public const string Schema = "schema/";
		public const string PhoneNumber = "#phoneNumber";
		public const string Json = "#json";
	}

	public static class Strings
	{
		/// <summary>The base URI for the w3c, <inheritdoc cref="W3CBaseUriString" path="/value/node()"/></summary>
		/// <value><c>https://www.w3.org/</c></value>
		public const string W3CBaseUriString = "https://www.w3.org/";
		/// <summary>The base URI for the XML schema version 11-2, <inheritdoc cref="XmlSchema11_2UriString" path="/value/node()"/></summary>
		/// <value><inheritdoc cref="W3CBaseUriString"/><inheritdoc cref="Namespaces.TR"/><inheritdoc cref="Namespaces.XmlSchema11_2"/></value>
		public const string XmlSchema11_2UriString = $"{W3CBaseUriString}{Namespaces.TR}{Namespaces.XmlSchema11_2}";
		/// <summary>
		/// A URI for representing URI claim value types, <inheritdoc cref="AnyUriClaimValueTypeString" path="/value/node()" />
		/// </summary>
		/// <value><inheritdoc cref="XmlSchema11_2UriString" path="/value/node()" /><inheritdoc cref="Namespaces.AnyUriAnchor" path="/value/node()" /></value>
		public const string AnyUriClaimValueTypeString = $"{XmlSchema11_2UriString}{Namespaces.AnyUriAnchor}";
		/// <summary>A URI for representing a phone number</summary>
		/// <value><inheritdoc cref="JustinWritesCodeUriBaseString" path="/value/node()" /><inheritdoc cref="Namespaces.Schema" path-=/value/node()" /><inheritdoc cref="Namespaces.PhoneNumber" path-=/value/node()" /></value>
		public const string JsonValueTypeUriString =	$"{JustinWritesCodeUriBaseString}{Namespaces.Schema}{Namespaces.Json}";
		/// <summary>A URI for representing a phone number</summary>
		/// <value><inheritdoc cref="JustinWritesCodeUriBaseString" path="/value/node()" /><inheritdoc cref="Namespaces.Schema" path-=/value/node()" /><inheritdoc cref="Namespaces.PhoneNumber" path-=/value/node()" /></value>
		public const string PhoneNumberValueTypeUriString = $"{JustinWritesCodeUriBaseString}{Namespaces.Schema}{Namespaces.PhoneNumber}";
	}

	public static class Uris
	{
		/// <inheritdoc cref="Strings.W3CBaseUriString" path="//node()" />
		public static readonly Uri W3CBaseUri = new(Strings.W3CBaseUriString);
		/// <inheritdoc cref="Strings.XmlSchema11_2UriString" path="/node()" />
		public static readonly Uri XmlSchema11_2Uri = new(Strings.XmlSchema11_2UriString);
		/// <inheritdoc cref="Strings.AnyUriClaimValueTypeString" path="/node()" />
		public static readonly Uri AnyUriClaimValueType = new(Strings.AnyUriClaimValueTypeString);
	}

	/// <summary>A URI that represents a null claim value type</summary>
	/// <value><c>null</c></value>
	public static readonly ClaimValueType NullClaimValueType = (null as Uri)!;

	/// <summary>
	/// A URI that represents the boolean XML data type.
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#boolean</value>
	public static readonly ClaimValueType BooleanClaimValueType = new(SysSecVt.Boolean, "A URI that represents the boolean XML data type.", v => v.RuleFor(c => c.Value).Must(v => bool.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the emailaddress SOAP data type.
	/// </summary>
	/// <value>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</value>
	public static readonly ClaimValueType EmailClaimValueType = new(SysSecVt.Email, "A URI that represents the emailaddress SOAP data type.", v => v.RuleFor(c => c.Value).EmailAddress());
	/// <summary>
	/// A URI that represents the string XML data type.
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#string</value>
	public static readonly ClaimValueType StringClaimValueType = new(SysSecVt.String, "A URI that represents the string XML data type.", v => v.RuleFor(c => c.Value));
	/// <summary>
	/// A URI that represents the sid XML data type.  http://www.w3.org/2001/XMLSchema#sid
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#sid</value>
	public static readonly ClaimValueType SidClaimValueType = new(SysSecVt.Sid, "A URI that represents the sid XML data type.", v => v.RuleFor(c => c.Value));
	/// <summary>
	/// A URI that represents the date XML data type.  http://www.w3.org/2001/XMLSchema#date
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#date</value>
	public static readonly ClaimValueType DateClaimValueType = new(SysSecVt.Date, "A URI that represents the date XML data type.", v => v.RuleFor(c => c.Value).Must(v => System.DateTime.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the date XML data type.  http://www.w3.org/2001/XMLSchema#dateTime
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#dateTime</value>
	public static readonly ClaimValueType DateTimeClaimValueType = new(SysSecVt.DateTime, "A URI that represents the date XML data type.", v => v.RuleFor(c => c.Value).Must(v => System.DateTime.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the integer32 XML data type.  http://www.w3.org/2001/XMLSchema#integer32
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#integer32</value>
	public static readonly ClaimValueType Integer64ClaimValueType = new(SysSecVt.Integer64, "A URI that represents the integer64 XML data type.", v => v.RuleFor(c => c.Value).Must(v => long.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the integer32 XML data type.  http://www.w3.org/2001/XMLSchema#integer32"
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#integer32</value>
	public static readonly ClaimValueType Integer32ClaimValueType = new(SysSecVt.Integer32, "A URI that represents the integer32 XML data type.", v => v.RuleFor(c => c.Value).Must(v => int.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the unsigned integer64 XML data type.  http://www.w3.org/2001/XMLSchema#uinteger64
	/// </summary>
	// <value>http://www.w3.org/2001/XMLSchema#uinteger64</value>
	public static readonly ClaimValueType UnsignedInteger64ClaimValueType = new(SysSecVt.UInteger64, "A URI that represents the integer64 XML data type.", v => v.RuleFor(c => c.Value).Must(v => long.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the unsigned integer32 XML data type.  http://www.w3.org/2001/XMLSchema#uinteger32"
	/// </summary>
	/// <value>http://www.w3.org/2001/XMLSchema#uinteger32</value>
	public static readonly ClaimValueType UnsignedInteger32ClaimValueType = new(SysSecVt.UInteger32, "A URI that represents the integer32 XML data type.", v => v.RuleFor(c => c.Value).Must(v => int.TryParse(v, out var result)));
	/// <summary>
	/// A URI that represents the base64Binary XML data type.  http://www.w3.org/2001/XMLSchema#base64Binary
	/// </summary>
	// <value>http://www.w3.org/2001/XMLSchema#base64Binary</value>
	public static readonly ClaimValueType Base64BinaryClaimValueType = new(SysSecVt.Base64Binary, "A URI that represents the base64Binary XML data type.", v => v.RuleFor(c => c.Value).Must(c => true));

	/// <summary>
	/// A URI that represents the URI data type. <inheritdoc cref="Strings.AnyUriClaimValueTypeString" />
	/// </summary>
	/// <value><inheritdoc cref="Strings.AnyUriClaimValueTypeString"/></value>
	public const string UriClaimValueTypeString = Strings.AnyUriClaimValueTypeString;
	/// <summary>
	/// <inheritdoc cref="UriClaimValueTypeString"/>
	/// </summary>
	public static readonly ClaimValueType UriClaimValueType = new(UriClaimValueTypeString, "A URI that represents the URI data type.", v => v.RuleFor(c => c.Value).Must(v => System.Uri.TryCreate(v, RelativeOrAbsolute, out Uri? result)));
	/// <summary>
	/// A URI that represents the phone number XML data type.  See <inheritdoc cref="Strings.PhoneNumberValueTypeUriString"/>
	/// </summary>
	public const string PhoneNumberClaimValueTypeString = Strings.PhoneNumberValueTypeUriString;
	/// <summary>
	/// A URI that represents the phone number XML data type.
	/// </summary>
	public static readonly ClaimValueType PhoneNumberClaimValueType = new(PhoneNumberClaimValueTypeString, "A URI that represents the phone number XML data type.", v => v.RuleFor(c => c.Value).Must(c => true));
	/// <summary>
	/// A URI that represents a JSON data type.  <inheritdoc cref="Strings.JsonValueTypeUriString"/>schema#JSON
	/// </summary>
	public const string JsonClaimValueTypeString = Strings.JsonValueTypeUriString;
	/// <summary>
	/// <inheritdoc cref="Strings.JsonValueTypeUriString"/>
	/// </summary>
	public static readonly ClaimValueType JsonClaimValueType = new(JsonClaimValueTypeString, "A URI that represents the JSON data type.", v => v.RuleFor(c => c.Value).Must(claim =>
	{
		try { var deserializedResult = Deserialize<JElem>(claim); return true; }
		catch { return false; }
	}));
}
