using Infrastructure.Data.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Entity.Map
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment", "webforum");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
           .ValueGeneratedOnAdd();
            builder.HasOne(f => f.Post).WithOne(x => x.Comment).HasForeignKey<Comment>(x => x.PostId);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
