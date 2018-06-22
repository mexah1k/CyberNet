using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void SeedEnumEntities<TEntity, TEnum>(this EntityTypeBuilder<TEntity> entityTypeBuilder,
                                                                Func<TEnum, TEntity> converter)
            where TEnum : struct, IConvertible
            where TEntity : class
        {
            var entities = Enum.GetValues(typeof(TEnum))
                              .Cast<object>()
                              .Select(value => converter((TEnum)value))
                              .ToArray();

            entityTypeBuilder.HasData(entities);
        }
    }
}