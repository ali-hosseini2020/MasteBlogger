using System;

namespace Mb.Domain.ArticleCategoryAgg.Exceptions
{
    class DuplicatedRecordException : Exception
    {
        public DuplicatedRecordException()
        {
        }

        public DuplicatedRecordException(string massage) : base(massage)
        {

        }
    }
}