using MB.Aplication.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment Entity)
        {
           _context.comments.Add(Entity);
            Save();
        }

       

        public List<CommentViewModel> GetList()
        {
           return _context.comments.Include(x=>x.article).Select(x=>new CommentViewModel
           {
              Id = x.Id,
              Name = x.Name,
              Email = x.Email,
              Message = x.Message,
              CreationDate = x.CreationDate.ToString(),
              Status = x.Status,
              Article=x.article.Title,
           }).ToList();
        }
        public Comment Get(long id)
        {
          return _context.comments.FirstOrDefault(x=>x.Id == id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
