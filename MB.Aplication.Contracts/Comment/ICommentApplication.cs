using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Aplication.Contracts.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment comment);
    }
}
