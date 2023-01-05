/*
 * SoftwareLicense.cs
 *
 *   Created: 2022-10-31-06:27:56
 *   Modified: 2022-11-17-08:49:57
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Enums;



using System.ComponentModel.DataAnnotations;
public partial record struct SoftwareLicense// : IEnumeration, IEnumeration<SoftwareLicense, Int32>, IEquatable<SoftwareLicenseEnum>, IComparable<SoftwareLicenseEnum>, IHaveAValue<SoftwareLicenseEnum>, IHaveAValue, IIdentifiable<Int32>, IIdentifiable, IComparable<SoftwareLicense>, IEquatable<SoftwareLicense>
{
    // public virtual string Name => this.GetCustomAttribute<DisplayAttribute>().Name;
    // public virtual string ShortName => this.GetCustomAttribute<DisplayAttribute>().ShortName;
    public Uri Url => GetCustomAttribute<UriAttribute>().Uri;
}
