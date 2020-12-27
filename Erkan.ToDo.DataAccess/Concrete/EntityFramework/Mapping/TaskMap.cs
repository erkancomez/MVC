using Erkan.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Mapping
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(200);
            builder.Property(I => I.Explanation).HasColumnType("ntext");

            builder.HasOne(I => I.Importance).WithMany(I => I.Tasks).HasForeignKey(I => I.ImportanceId);
        }
    }
}
