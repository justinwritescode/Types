// 
// ConditionEnum.cs
// 
//   Created: 2022-10-31-03:30:13
//   Modified: 2022-10-31-03:30:13
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.Enums.SoftwareLicenses;
using System.ComponentModel.DataAnnotations;

[GenerateEnumerationClass("LicenseCondition")]
public enum LicenseConditionEnum
{
    [Display(Name = "No Conditions", ShortName = "No Conditions")]
    None = 0,
    [Display(Name = "include-copyright")]
    IncludeCopyright = 1,
    [Display(Name = "document-changes")]
    DocumentChanges = 2,
    [Display(Name = "disclose-source")]
    DiscloseSource = 4,
    [Display(Name = "network-use-disclose")]
    NetworkUseDisclose = 16,
    [Display(Name = "same-license")]
    SameLicense = 32,
    [Display(Name = "same-license--library")]
    SameLicenseLibrary = 64
}
