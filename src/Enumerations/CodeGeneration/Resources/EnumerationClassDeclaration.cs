/* 
 * EnumerationClassDeclaration.cs
 * 
 *   Created: 2022-10-30-07:17:08
 *   Modified: 2022-11-11-01:58:18
 * 
 *   Author: Justin Chase <justin@justinwritescode.com>
 *   
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 
namespace ENUM_NAMESPACE
{
    public enum ENUM_TYPE
    {

    }
}

// BEGIN

namespace NAMESPACE;
#nullable enable
using System.Runtime.CompilerServices;


/// <summary>
/// A strongly-typed enumeration of the values in the enum type <see cref="ENUM_NAMESPACE.ENUM_TYPE" />.
/// </summary>
[CompilerGenerated]
public partial class ENUMERATION_CLASS_NAME : JustinWritesCode.Enumerations.Enumeration<ENUMERATION_CLASS_NAME, int, ENUM_NAMESPACE.ENUM_TYPE>
{
    public ENUMERATION_CLASS_NAME (int id, string name) : base(id, (ENUM_NAMESPACE.ENUM_TYPE)id, name) { }

    public static readonly ENUMERATION_CLASS_NAME [] Values = new ENUMERATION_CLASS_NAME[] { /*VALUES*/ };

    /*FIELDS*/
}
