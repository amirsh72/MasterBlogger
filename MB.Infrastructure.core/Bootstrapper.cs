using MB.Aplication.Contracts.Article;
using MB.Aplication.Contracts.ArticleCategory;
using MB.Aplication.Contracts.Comment;
using MB.Application;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.Query;
using MB.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MB.Infrastructure.core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>(); 
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();
            services.AddTransient<IArticleQuery, ArticleQueryview>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddDbContext<MasterBloggerContext>(x => x.UseSqlServer(connectionstring));
           
        }
    }
}
