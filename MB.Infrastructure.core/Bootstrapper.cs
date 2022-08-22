using MB.Aplication.Contracts.ArticleCategory;
using MB.Application;
using MB.Domain.ArticleCategory;
using MB.Domain.ArticleCategory.Services;
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
            services.AddDbContext<MasterBloggerContext>(x => x.UseSqlServer(connectionstring));
           
        }
    }
}
