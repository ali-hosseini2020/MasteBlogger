using System.Collections.Generic;
using MB.Application.Contracts.Comment;

namespace Mb.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);
        List<CommentViewModel> GetList();
    }
}