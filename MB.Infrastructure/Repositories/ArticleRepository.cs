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
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Article article)
        {
            _context.articles.Add(article);
            Save();
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
        public Article Get(long id)
        {
         return  _context.articles.FirstOrDefault(x=>x.Id==id);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _context.articleCategories.Any(x => x.Title == title);
        }
    }
}
