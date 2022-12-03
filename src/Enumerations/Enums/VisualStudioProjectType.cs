//
// VisualStudioProjectType.cs
//
//   Created: 2022-10-16-05:52:39
//   Modified: 2022-10-30-05:21:21
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace JustinWritesCode.Enums;

public partial class VisualStudioProjectType //: Enumerations.Enumeration<VisualStudioProjectTypeEnumeration, VisualStudioProjectType>
{
    public virtual Guid Guid => this.GetCustomAttribute<GuidAttribute>().Guid;
}
