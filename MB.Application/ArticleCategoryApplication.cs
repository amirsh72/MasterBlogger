using MB.Aplication.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Create(CreateArticleCategory command)
        {
            var articlecategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);
            _articleCategoryRepository.Create(articlecategory);
        }

        public RenameArticleCategory Get(long id)
        {
            var articlecategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articlecategory.Id,
                Title = articlecategory.Title
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return (articleCategories.Select(articleCategory => new ArticleCategoryViewModel
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
                CreationDate = articleCategory.CreationDate.ToString(),
                IsDeleted = articleCategory.IsDeleted,
            })).OrderByDescending(x=>x.Id).ToList();
        }
        public void Activate(long id)
        {
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Activate();
            //_articleCategoryRepository.Save();
        }
        public void Remove(long id)
        {
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Remove();
            //_articleCategoryRepository.Save();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articlecategory = _articleCategoryRepository.Get(command.Id);
            articlecategory.Rename(command.Title);
            Save();
        }
        public void Save()
        {
            //_articleCategoryRepository.Save();
        }

    }
}
