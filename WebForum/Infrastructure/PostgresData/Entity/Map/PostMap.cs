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
            builder.HasOne(x => x.Topic).WithOne(x => x.Post).HasForeignKey<Post>(x => x.TopicId);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Content).IsRequired();
        }
    }
}
