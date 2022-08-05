using Infrastructure.Data.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Entity.Map
{
    public class TopicMap : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic", "webforum");
            builder.HasKey(k => k.Id);
            builder.HasOne(x => x.Category).WithOne().HasForeignKey<Topic>(s => s.CategoryId);
        }
    }
}
