// 
// IHaveAName.cs
// 
//   Created: 2022-11-04-09:29:32
//   Modified: 2022-11-04-09:29:32
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.Abstractions;

public interface IHaveAName
{
    string Name { get; }
}

public interface IHaveAWritableName : IHaveAName
{
    new string Name { get; set; }
}
