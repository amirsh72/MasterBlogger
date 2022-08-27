using _01_Framework.Infrastructure;
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
        private readonly IUnitOfWork _unitOfWork;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articlecategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);
            _articleCategoryRepository.Create(articlecategory);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Activate();
            _unitOfWork.CommitTran();
           
        }
        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Remove();
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articlecategory = _articleCategoryRepository.Get(command.Id);
            articlecategory.Rename(command.Title);
            _unitOfWork.CommitTran();
        }
        public void Save()
        {
            //_articleCategoryRepository.Save();
        }

    }
}
