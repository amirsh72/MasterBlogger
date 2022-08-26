using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.Query
{
    public class ArticleQueryview : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQueryview(MasterBloggerContext context)
        {
            _context = context;
        }



        public List<ArticleQueryView> GetArticles()
        {
            return _context.articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.comments)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    Articlecategory = x.ArticleCategory.Title,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    Content = x.Content,
                    CommentCount = x.comments.Count(x => x.Status == Statuses.Confirmed)
                }).ToList();

        }
        public ArticleQueryView GetArticle(long id)
        {
            return _context.articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.comments)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Articlecategory = x.ArticleCategory.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
                Content = x.Content,
                CommentCount = x.comments.Count(x => x.Status == Statuses.Confirmed),
                    comments = MapComments(x.comments.Where(x => x.Status == Statuses.Confirmed))
            }).FirstOrDefault(x => x.Id == id);
        }

       public static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(x => new CommentQueryView
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Name = x.Name,
                Message = x.Message,

            }).ToList();
        }
       
    }
}
