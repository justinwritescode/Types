// 
// EnumerationFieldDeclaration.cs
// 
//   Created: 2022-10-30-07:19:16
//   Modified: 2022-11-11-04:45:38
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
using static Constants;
public abstract class ENUMERATION_CLASS_NAME : JustinWritesCode.Enumerations.Enumeration<ENUMERATION_CLASS_NAME, int>
{
    public ENUMERATION_CLASS_NAME(int id, string name) : base(id, name) { }
}
internal static class Constants 
{
    public const int ID = 0;
    public const string NAME = "NAME";
    public const string DISPLAY_NAME = nameof(DISPLAY_NAME);
    public const string SHORT_NAME = nameof(SHORT_NAME);
    public const int ORDER = 0;
    public const int ID = 0;
}

// BEGIN
[System.Runtime.CompilerServices.CompilerGenerated]
public sealed class FIELD_NAME : ENUMERATION_CLASS_NAME
{
    public FIELD_NAME() : base( ID, NAME)
    {
    }

    public static readonly FIELD_NAME Instance = new FIELD_NAME();

    public new const string Name = NAME;
    public new const string DisplayName = DISPLAY_NAME;
    public new const string ShortName = SHORT_NAME;
    public new const int Order = ORDER;
    public new const int Id = ID;
}
