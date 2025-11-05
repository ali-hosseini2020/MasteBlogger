using System;

namespace Mb.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string title);
    }
}
