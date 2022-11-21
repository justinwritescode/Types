//
// IEnumeration.cs
//
//   Created: 2022-11-02-01:22:22
//   Modified: 2022-11-02-01:22:22
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace JustinWritesCode.Enumerations.Abstractions;
using JustinWritesCode.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
public interface IEnumeration : IConvertible, IComparable, IHaveAValue, IHaveAName, IHaveADescription, IIdentifiable
{
    FieldInfo FieldInfo {get;}//=> GetType().GetField(Name);
    [FromString]
    string DisplayName {get;}//=> Name;
    [FromString]
    string ShortName{get;}// => Name;
    string GroupName {get;}// => NoGroup;
    int Order{get;}// => DefaultOrder;
    TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute;// => FieldInfo.GetCustomAttribute<TAttribute>();
    //static abstract IEnumeration FromValue(Type t, object value);// => Parse(t, x => x.Value.Equals(value));
    //static abstract TEnumeration FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration;// => FromValue(typeof(TEnumeration), value) as TEnumeration;
    //static abstract IEnumeration[] GetValues(Type t);// => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
    //static abstract TEnumeration[] GetValues<TEnumeration>();// => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
    //protected static abstract IEnumerable<PropertyInfo> GetFromStringProperties(Type t);
        // => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);
    /*protected static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
        => GetFromStringProperties(typeof(TEnumeration));*/
    //static abstract IEnumeration Parse(Type t, string value);// => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) == value));
    //static abstract TEnumeration Parse<TEnumeration>(string value) where TEnumeration : IEnumeration;
        //=> Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) == value));
    //static abstract TEnumeration Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration;
        //=> GetValues<TEnumeration>().FirstOrDefault(matchPredicate);
    //static abstract IEnumeration Parse(Type t, Func<IEnumeration, bool> matchPredicate);
        //=> GetValues(t).FirstOrDefault(matchPredicate);
    //static abstract bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration;
        //=> (value = Parse<TEnumeration>(s) as TEnumeration) != null;
}
