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

[GenerateEnumerationClass("HttpMethod")]
public enum HttpMethodEnum
{
	GET,
	POST,
	PUT,
	DELETE,
	PATCH,
	HEAD,
	OPTIONS,
	TRACE
}

public static class HttpMethodConstants
{
	public const string GET = "GET";
	public const string POST = "POST";
	public const string PUT = "PUT";
	public const string DELETE = "DELETE";
	public const string PATCH = "PATCH";
	public const string HEAD = "HEAD";
	public const string OPTIONS = "OPTIONS";
	public const string TRACE = "TRACE";
}
