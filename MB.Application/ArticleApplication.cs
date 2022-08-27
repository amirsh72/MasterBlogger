using _01_Framework.Infrastructure;
using MB.Aplication.Contracts.Article;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;

      

        public ArticleApplication(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
        {
            _unitOfWork = unitOfWork;
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.ShortDescription, command.Image,
                command.Content, command.ArticleCategoryId);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article=_articleRepository.Get(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _unitOfWork.CommitTran();

        }

        public EditArticle Get(long id)
        {
            var article=_articleRepository.Get(id);
            return new EditArticle
            {
                Id = id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId

            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
            
        }
        public void Activete(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }
    }
}
