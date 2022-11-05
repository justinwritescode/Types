// 
// EnumerationJsonSerializer.cs
// 
//   Created: 2022-11-02-01:19:42
//   Modified: 2022-11-02-01:19:43
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.Enumerations.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class EnumerationJsonConverter<TEnumeration> : JsonConverter<TEnumeration>
    where TEnumeration : class, IEnumeration
{
    public override TEnumeration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return Enumeration.Parse<TEnumeration>(value);
    }

    public override void Write(Utf8JsonWriter writer, TEnumeration value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
