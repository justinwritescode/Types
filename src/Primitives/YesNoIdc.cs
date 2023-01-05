/*
 * YesNoIdc.cs
 *
 *   Created: 2022-12-17-12:47:12
 *   Modified: 2022-12-17-12:47:12
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#if NETSTANDARD2_0_OR_GREATER
namespace System;

[GenerateEnumerationRecordClassAttribute]
public enum YesNoIdcEnum
{
    No = 0,
    Yes = 1,
    Idc = -1,
    Idgaf = Idc,
}

[GenerateEnumerationRecordClassAttribute]
public enum YesNoEnum
{
    No = 0,
    Yes = 1,
}

#endif
