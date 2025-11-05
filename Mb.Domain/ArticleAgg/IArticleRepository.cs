using System.Collections.Generic;
using MB.Application.Contracts.Article;
using Mb.Domain.ArticleAgg;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();

        void CreateAndSave(Article entity);

        Article Get(long id);

        void Save();

        bool Exists(string title);

    }
}