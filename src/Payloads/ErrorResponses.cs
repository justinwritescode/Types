/*
 * ErrorResponsePayload.cs
 *
 *   Created: 2022-11-26-04:57:24
 *   Modified: 2022-11-26-04:57:24
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads;

public static class ErrorResponse
{
    public static ErrorResponsePayload FromException(Exception ex) => new ErrorResponsePayload(ex);
    public static ErrorResponsePayload ArgumentNullResponse(string argumentName) => new ErrorResponsePayload($"Argument '{argumentName}' cannot be null.");
}
