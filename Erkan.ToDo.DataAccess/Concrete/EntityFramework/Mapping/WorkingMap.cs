﻿using Erkan.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Mapping
{
    public class WorkingMap : IEntityTypeConfiguration<Working>
    {
        public void Configure(EntityTypeBuilder<Working> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(200);
            builder.Property(I => I.Statement).HasColumnType("ntext");
        }
    }
}
