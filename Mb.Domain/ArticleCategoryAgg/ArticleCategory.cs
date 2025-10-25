using System;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.Domain.ArticleCategoryAgg
{
   public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory()
        {
        }

        public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);

            Title = title;
            IsDeleted = false; // So, when we create the desired record at the beginning,
                               // it hasn't been deleted.Initializes the record as active (not soft-deleted).

            CreationDate = DateTime.Now; // The date our target record is created
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }
        }

        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}