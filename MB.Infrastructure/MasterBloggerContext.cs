
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure
{
    public class MasterBloggerContext : DbContext
    {
        public DbSet<ArticleCategory> articleCategories { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> comments { get; set; }
        public MasterBloggerContext( DbContextOptions<MasterBloggerContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new CommentMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
