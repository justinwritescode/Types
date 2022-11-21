/* 
 * SoftwareLicenseEnum.cs
 * 
 *   Created: 2022-10-31-05:18:33
 *   Modified: 2022-11-11-03:44:07
 * 
 *   Author: Justin Chase <justin@justinwritescode.com>
 *   
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace JustinWritesCode.Enums;
using System.ComponentModel.DataAnnotations;
using JustinWritesCode.ComponentModel;
[GenerateEnumerationClass("SoftwareLicense")]
public enum SoftwareLicenseEnum
{

    [Display(Name = "The Unlicense", ShortName = "Unlicense")]
    [Uri("https://api.github.com/licenses/unlicense")]
    Unlicense = 0,
    None = 0,
    [Display(Name = "GNU Affero General Public License v3.0", ShortName = "AGPL-3.0")]
    [Uri("https://api.github.com/licenses/agpl-3.0")]
    AGPL3,
    [Display(Name = "Apache License 2.0", ShortName = "Apache-2.0")]
    [Uri("https://api.github.com/licenses/apache-2.0")]
    Apache2,
    [Display(Name = "BSD 2-Clause \\\"Simplified\\\" License", ShortName = "BSD-2-Clause")]
    [Uri("https://api.github.com/licenses/bsd-2-clause")]
    BSD2Clause,
    [Display(Name = "BSD 3-Clause \\\"New\\\" or \\\"Revised\\\" License", ShortName = "BSD-3-Clause")]
    [Uri("https://api.github.com/licenses/bsd-3-clause")]
    BSD3Clause,
    [Display(Name = "Boost Software License 1.0", ShortName = "BSL-1.0")]
    [Uri("https://api.github.com/licenses/bsl-1.0")]
    BSL1,
    [Display(Name = "Creative Commons Zero v1.0 Universal", ShortName = "CC0-1.0")]
    [Uri("https://api.github.com/licenses/cc0-1.0")]
    CC01,
    [Display(Name = "Eclipse Public License 2.0", ShortName = "EPL-2.0")]
    [Uri("https://api.github.com/licenses/epl-2.0")]
    EPL2,
    [Display(Name = "GNU General Public License v2.0", ShortName = "GPL-2.0")]
    [Uri("https://api.github.com/licenses/gpl-2.0")]
    GPL2,
    [Display(Name = "GNU General Public License v3.0", ShortName = "GPL-3.0")]
    [Uri("https://api.github.com/licenses/gpl-3.0")]
    GPL3,
    [Display(Name = "GNU Lesser General Public License v2.1", ShortName = "LGPL-2.1")]
    [Uri("https://api.github.com/licenses/lgpl-2.1")]
    LGPL21,
    [Display(Name = "MIT License", ShortName = "MIT")]
    [Uri("https://api.github.com/licenses/mit")]
    MIT,
    [Display(Name = "Mozilla Public License 2.0", ShortName = "MPL-2.0")]
    [Uri("https://api.github.com/licenses/mpl-2.0")]
    MPL2,
    [Display(Name = "Microsoft Public License", ShortName = "MS-PL")]
    [Uri("https://api.github.com/licenses/ms-pl")]
    MSPL
}


// public static class SoftwareLicenseEnumExtensions
// {
//     public static FieldInfo GetFieldInfo(this SoftwareLicenseEnum license)
//     {
//         return license.GetType().GetField(license.ToString());
//     }

//     public static TAttribute GetCustomAttribute<TAttribute>(this SoftwareLicenseEnum license)
//         where TAttribute : System.Attribute
//     {
//         return license.GetFieldInfo().GetCustomAttribute<TAttribute>();
//     }

//     private static IDictionary<SoftwareLicenseEnum, SoftwareLicense> LicensesCache = new Dictionary<SoftwareLicenseEnum, SoftwareLicense>();

//     public static async Task<SoftwareLicense> GetLicenseAsync(this SoftwareLicenseEnum license)
//     {
//         if (LicensesCache.ContainsKey(license))
//         {
//             return LicensesCache[license];
//         }
//         else
//         {

//             var resources = typeof(SoftwareLicenseEnum).Assembly.GetManifestResourceNames();
//             // Console.WriteLine(string.Join(Environment.NewLine, resources));
//             //var licenseJsonResponse = await new System.Net.Http.HttpClient().GetAsync(license.GetCustomAttribute<UriAttribute>().Uri);
//             var licenseInfo = typeof(SoftwareLicenseEnum).Assembly.GetManifestResourceInfo("MSBuild.EnsureFileHeaders.Licenses." + license.GetCustomAttribute<DisplayAttribute>().ShortName.ToLower() + ".json"); //await licenseJsonResponse.Content.ReadAsStringAsync();
//             // Console.WriteLine("LicenseInfo.filename: " + licenseInfo.ResourceLocation);
//             var licenseJsonStream = typeof(SoftwareLicenseEnum).Assembly.GetManifestResourceStream("MSBuild.EnsureFileHeaders.Licenses." + license.GetCustomAttribute<DisplayAttribute>().ShortName.ToLower() + ".json"); //await licenseJsonResponse.Content.ReadAsStringAsync();
//             // Console.WriteLine("licenseJsonStream?.Length: " + licenseJsonStream?.Length);
//             var licenseJson = new StreamReader(licenseJsonStream).ReadToEnd();
//             // Console.WriteLine("License JSON:" + licenseJson);
//             var licenseObject = SoftwareLicense.FromJson(licenseJson);
//             //LicensesCache.Add(license, licenseObject);
//             //var licenseObject = new SoftwareLicense();
//             return licenseObject;
//         }
//     }
// }
