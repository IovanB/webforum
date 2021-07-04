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
            builder.HasOne(f => f.Post).WithOne(x => x.Comment).HasForeignKey<Comment>(x => x.PostId);
            builder.HasOne(f => f.User).WithOne(x => x.Comment).HasForeignKey<Comment>(x => x.UserId);
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
