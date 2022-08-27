using _01_Framework.Infrastructure;
using MB.Aplication.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Repositories
{
    public class ArticleRepository :BaseRepository<long,Article> ,IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context):base(context)
        {
            _context = context;
        }

        

       

        public List<ArticleViewModel> GetList()
        {
            var list = _context.articles.ToList();
            return _context.articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory=x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreationDate=x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).OrderByDescending(x=>x.Id).ToList();
        }
      
    }
}
