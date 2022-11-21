namespace JustinWritesCode.Security.Claims;
using System;
public class ClaimType : UriDescriptionTuple
{
	public virtual ClaimValueType ValueType { get; }

	public ClaimType(Uri uri, string? description = null, uri? claimValueType = null) : base(uri, description)
	{
		ValueType = claimValueType != null ? new ClaimValueType(claimValueType, null as string, null as IValidator<C>) : StringClaimValueType;
	}
	public ClaimType(string uri, string? description = null, string? claimValueType = null) : this(System.UriExtensions.ToUri(uri), description, System.UriExtensions.ToUri(claimValueType)) { }

	public override string ToString() => Uri.ToString();

	public static implicit operator string(ClaimType claimType) => claimType.Uri.ToString();
	public static implicit operator uri?(ClaimType claimType) => claimType.Uri;
	//public static implicit operator ClaimType((Uri, string) tuple) => new ClaimType(tuple.Item1, tuple.Item2, null as Uri);
	public static implicit operator ClaimType((string, string) tuple) => new ClaimType(tuple.Item1, tuple.Item2, null as string);
	public static implicit operator ClaimType((Uri, string) tuple) => new ClaimType(tuple.Item1, tuple.Item2, null as uri);
	public static implicit operator ClaimType((string, string, string) tuple) => new ClaimType(tuple.Item1, tuple.Item2, tuple.Item3);
	public static implicit operator ClaimType((Uri, string, ClaimValueType) tuple) => new ClaimType(tuple.Item1, tuple.Item2, tuple.Item3);
}
