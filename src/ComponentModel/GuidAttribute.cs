namespace JustinWritesCode.ComponentModel;

public class GuidAttribute : Attribute
{
    public GuidAttribute(string guid) { Guid = Guid.Parse(guid); }
    public GuidAttribute(Guid guid) { Guid = guid; }

    public Guid Guid { get; }
}
