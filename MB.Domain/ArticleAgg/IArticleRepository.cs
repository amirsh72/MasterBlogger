﻿using MB.Aplication.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article article);
        Article Get(long id);
        void Save();
    }
}
