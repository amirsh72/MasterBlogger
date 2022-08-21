using MB.Domain.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Add(ArticleCategory entity)
        {
            _context.articleCategories.Add(entity);
            _context.SaveChanges();
        }

       

        public ArticleCategory Get(long id)
        {
            return _context.articleCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategory> GetAll()
        {
           return _context.articleCategories.OrderByDescending(x=>x.Id).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
