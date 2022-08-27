using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> articles { get; private set; }
        public ArticleCategory()
        {

        }
        public ArticleCategory(string title, IArticleCategoryValidatorService ValidatorService)
        {
            GuardAgainstEmptyTitle(title);
            ValidatorService.CheckThatThisRecordAlradyExists(title);
            Title = title;
            IsDeleted = false;
            
            articles = new List<Article>();
        }
        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }


    }
}
