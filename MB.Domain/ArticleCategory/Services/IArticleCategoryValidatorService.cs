using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategory.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThatThisRecordAlradyExists(string title);
    }
}
