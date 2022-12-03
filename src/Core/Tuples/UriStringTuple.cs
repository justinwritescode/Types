namespace JustinWritesCode.Tuples;

public abstract class UriStringTuple : Tuple<uri?, string?>
{
    public UriStringTuple(Uri? uri = default, string? value = default) : base(uri, value) { }
    public Uri? Uri => Item1;
    public UriStringTuple(string? uri = default, string? value = default) : this(uri?.ToUri(), value) { }
    public UriStringTuple(UriStringTuple? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
    public UriStringTuple((Uri?, string?)? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
    public UriStringTuple((string?, string?)? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
    public UriStringTuple() : this(null as uri, null as string) { }
}

public abstract class UriDescriptionTuple : UriStringTuple
{
    public virtual string? Description => Item2;
    protected UriDescriptionTuple(Uri uri, string? description = default) : base(uri, description) { }
    protected UriDescriptionTuple(string uri, string? description = default) : this(uri.ToUri(), description) { }
    protected UriDescriptionTuple((uri?, string?)? tuple = default) : base(tuple?.Item1, tuple?.Item2) { }
    protected UriDescriptionTuple((string?, string?)? tuple = default) : base(tuple?.Item1, tuple?.Item2) { }

    public static implicit operator string?(UriDescriptionTuple tuple) => tuple.Uri.ToString();
    public static implicit operator Uri?(UriDescriptionTuple tuple) => tuple.Uri;
}
