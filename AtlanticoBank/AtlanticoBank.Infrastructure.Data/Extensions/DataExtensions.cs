using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Infrastructure.Data.Extensions
{
    public static class DataExtensions
    {
        public static void LowercaseRelationalTableAndPropertyNames(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLowerInvariant());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToLowerInvariant());
                }
            }
        }


    }


}
