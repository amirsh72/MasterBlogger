using MB.Aplication.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        List<CommentViewModel> GetList();
        void CreateAndSave(Comment Entity);
        Comment Get(long id);
        void Save();
    }
}
