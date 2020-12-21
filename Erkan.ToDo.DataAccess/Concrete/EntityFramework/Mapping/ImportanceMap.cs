using Erkan.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ImportanceMap : IEntityTypeConfiguration<Importance>
    {
        public void Configure(EntityTypeBuilder<Importance> builder)
        {
            builder.Property(I => I.Definition).HasMaxLength(100);
        }
    }
}
