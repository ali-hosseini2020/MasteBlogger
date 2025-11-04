using System;
using System.Collections.Generic;
using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        //Represents the 'Many' side of the One-to-Many relationship with Article.
        // A single ArticleCategoryId can contain multiple Articles.
        // Collection of articles belonging to this category. Used for navigation and ensuring Domain integrity.
        public ICollection<Article> Articles { get; private set; }


        public ArticleCategory()
        {
        }


        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);

            validatorService.CheckThatThisRecordAlreadyExists(title);

            Title = title;

            // So, when we create the desired record at the beginning,
            // it hasn't been deleted.Initializes the record as active (not soft-deleted).
            IsDeleted = false;

            // The date our target record is created                  
            CreationDate = DateTime.Now;

            Articles = new List<Article>();
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