using Infrastructure.Data.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Entity.Map
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post", "webforum");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Topic).WithOne(x => x.Post).HasForeignKey<Post>(x => x.TopicId);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(p => p.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate(); builder.Property(p => p.Title).IsRequired().HasMaxLength(255);

        }
    }
}
