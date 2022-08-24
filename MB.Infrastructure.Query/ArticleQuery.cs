using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.Query
{
    public class ArticleQueryview : IArticleQuery
    {
        private readonly MasterBloggerContext _context ;

        public ArticleQueryview(MasterBloggerContext context)
        {
            _context = context;
        }

        

        public List<ArticleQueryView> GetArticles()
        {
            return _context.articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Articlecategory = x.ArticleCategory.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
            }).ToList();

        }
        public ArticleQueryView GetArticle(long id)
        {
            return _context.articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Articlecategory = x.ArticleCategory.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}
