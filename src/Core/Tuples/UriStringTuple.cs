namespace JustinWritesCode.Tuples;

public abstract class UriStringTuple : Tuple<uri?, string?>
{
    public UriStringTuple(uri? uri = default, string? value = default) : base(uri, value) { }
    public uri? Uri => Item1;
    public UriStringTuple(string? uri = default, string? value = default) : this(uri?.ToUri(), value) { }
    public UriStringTuple(UriStringTuple? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
#if NETSTANDARD2_0_OR_GREATER
    public UriStringTuple((uri?, string?)? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
    public UriStringTuple((string?, string?)? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
#endif
    public UriStringTuple() : this(null as uri?, null as string) { }
}

public abstract class UriDescriptionTuple : UriStringTuple
{
    public virtual string? Description => Item2;
    protected UriDescriptionTuple(uri? uri, string? description = default) : base(uri, description) { }
    protected UriDescriptionTuple(string uri, string? description = default) : this(uri.ToUri(), description) { }
#if NETSTANDARD2_0_OR_GREATER
    protected UriDescriptionTuple((uri?, string?)? tuple = default) : base(tuple?.Item1, tuple?.Item2) { }
    protected UriDescriptionTuple((string?, string?)? tuple = default) : base(tuple?.Item1, tuple?.Item2) { }

#endif
    public static implicit operator string?(UriDescriptionTuple tuple) => tuple.Uri.ToString();
    public static implicit operator uri?(UriDescriptionTuple tuple) => tuple.Uri;
}
