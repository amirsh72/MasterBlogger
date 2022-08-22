using MB.Domain.ArticleCategory.Exceptions;
using System;

namespace MB.Domain.ArticleCategory.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlradyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
                throw new DuplicatedRecordException("This reccord is exists");
        }
    }
}
