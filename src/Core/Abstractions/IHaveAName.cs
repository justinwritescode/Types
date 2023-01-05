//
// IHaveAName.cs
//
//   Created: 2022-11-04-09:29:32
//   Modified: 2022-11-04-09:29:32
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace JustinWritesCode.Abstractions;
using System.ComponentModel.DataAnnotations;

public interface IHaveAName
{
    [FromString]
    string Name { get; }
}

public interface IHaveAWritableName : IHaveAName
{
    [FromString]
    new string Name { get; set; }
}
