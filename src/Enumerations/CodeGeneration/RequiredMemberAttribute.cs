/*
 * RequiredMemberAttribute.cs
 *
 *   Created: 2022-12-24-04:23:44
 *   Modified: 2022-12-24-04:23:44
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Runtime.CompilerServices;

public class RequiredMemberAttribute : Attribute
{
    public RequiredMemberAttribute()
    {
    }

    public RequiredMemberAttribute(string memberName)
    {
        MemberName = memberName;
    }

    public string MemberName { get; }
}

public class CompilerFeatureRequiredAttribute : Attribute
{
    public CompilerFeatureRequiredAttribute() { }
    public CompilerFeatureRequiredAttribute(string memberName)
    {
        MemberName = memberName;
    }

    public string MemberName { get; }
}
