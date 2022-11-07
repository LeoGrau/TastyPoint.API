using Microsoft.EntityFrameworkCore;

namespace TastyPoint.API.Shared.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void SnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()!.ToSnakeCase());
            
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()!.ToSnakeCase());
            }
            
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()!.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}