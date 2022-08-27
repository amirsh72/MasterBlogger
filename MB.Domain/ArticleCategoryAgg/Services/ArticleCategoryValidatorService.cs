using MB.Domain.ArticleCategoryAgg.Exceptions;
using System;

namespace MB.Domain.ArticleCategoryAgg.Services
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
            if (_articleCategoryRepository.Exists(x=>x.Title==title))
                throw new DuplicatedRecordException("This reccord is exists");
        }
    }
}
