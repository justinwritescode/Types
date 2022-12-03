/*
 * HttpMethod.cs
 *
 *   Created: 2022-11-19-09:29:46
 *   Modified: 2022-11-19-09:29:47
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace System.Net.Http;

[GenerateEnumerationClass("HttpRequestMethod")]
public enum HttpRequestMethodEnum
{
    Get,
    Post,
    Put,
    Delete,
    Patch,
    Head,
    Options,
    Trace
}
