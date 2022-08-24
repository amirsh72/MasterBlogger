﻿using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;
        public void CheckThatThisRecordAlradyExists(string title)
        {
            if (_articleRepository.Exists(title))
                throw new DuplicatedRecordException();
        }
    }
}
