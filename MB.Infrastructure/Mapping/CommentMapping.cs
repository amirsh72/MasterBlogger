using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Email);
            builder.Property(x => x.Message);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.ArticleId);
            builder.HasOne(x => x.article).WithMany(x => x.comments).HasForeignKey(x => x.ArticleId);

            

        }
    }
}
