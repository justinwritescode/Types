/*
 * EnumerationToLookupTable.cs
 *
 *   Created: 2022-12-23-09:55:49
 *   Modified: 2022-12-23-09:55:49
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Enumerations.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
public static class EnumerationToLookupTableExtensions
{
    public static ModelBuilder ToLookupTable<TEnum>(this ModelBuilder modelBuilder, string tableName = null)
        where TEnum : class, IEnumeration
    {
        tableName ??= typeof(TEnum).Name;
        modelBuilder.Entity<TEnum>(e =>
        {
            e.ToTable(tableName).HasKey(e => e.Id);
            e.HasIndex(e => e.Name);
            e.HasIndex(e => e.Value);
            e.HasData(typeof(TEnum).GetEnumValues().OfType<TEnum>());
        });
        return modelBuilder;
    }
}
