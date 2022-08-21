
using MB.Domain.ArticleCategory;
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
        public MasterBloggerContext( DbContextOptions<MasterBloggerContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
