// 
// SoftwareLicense.cs
// 
//   Created: 2022-10-31-03:27:56
//   Modified: 2022-10-31-03:28:26
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enums;
using System.ComponentModel.DataAnnotations;
using JustinWritesCode.ComponentModel;
public partial class SoftwareLicense
{
    public virtual string Name => this.GetCustomAttribute<DisplayAttribute>().Name;
    public virtual string ShortName => this.GetCustomAttribute<DisplayAttribute>().ShortName;
    public virtual Uri Url => this.GetCustomAttribute<UriAttribute>().Uri;
}
