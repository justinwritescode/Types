// 
#nullable enable
using System.CodeDom.Compiler;

namespace NAMESPACE;
using System.Runtime.CompilerServices;


/// <summary>
/// A strongly-typed enumeration of the values in the enum type ENUM_NAMESPACE.ENUM_TYPE.
/// </summary>
[CompilerGenerated]
public partial class ENUMERATION_CLASS_NAME : JustinWritesCode.Enumerations.Enumeration<ENUMERATION_CLASS_NAME, int, ENUM_NAMESPACE.ENUM_TYPE>
{
    public ENUMERATION_CLASS_NAME (int id, string name) : base(id, (ENUM_NAMESPACE.ENUM_TYPE)id, name) { }

    public static readonly ENUMERATION_CLASS_NAME [] Values = new ENUMERATION_CLASS_NAME[] { /*VALUES*/ };

    /*FIELDS*/
}
