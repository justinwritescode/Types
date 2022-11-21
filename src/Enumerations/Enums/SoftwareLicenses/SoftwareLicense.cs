/* 
 * SoftwareLicense.cs
 * 
 *   Created: 2022-10-31-06:27:56
 *   Modified: 2022-11-17-08:49:57
 * 
 *   Author: Justin Chase <justin@justinwritescode.com>
 *   
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace JustinWritesCode.Enums;



using JustinWritesCode.ComponentModel;
using System.ComponentModel.DataAnnotations;
public partial class SoftwareLicense
{
    // public virtual string Name => this.GetCustomAttribute<DisplayAttribute>().Name;
    // public virtual string ShortName => this.GetCustomAttribute<DisplayAttribute>().ShortName;
    public virtual Uri Url => this.GetCustomAttribute<UriAttribute>().Uri;

    public SoftwareLicense():base(10, SoftwareLicenseEnum.None, "None")
    {
        Console.WriteLine(this.Name);
    }
}
