using System;

namespace MB.Domain.ArticleCategory.Services
{
    public class ArticleCategoryValidatorSeevice : IArticleCategoryValidatorSeevice
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorSeevice(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlradyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
                throw new Exception();
        }
    }
}
