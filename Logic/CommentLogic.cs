using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repository;

namespace Logic
{
    public class CommentLogic : ICommentRepository
    {
        ICommentRepository commentrepo;

        public CommentLogic(ICommentRepository commentRepository)
        {
            this.commentrepo = commentRepository;
        }

        public void AddToCollection(Comment item)
        {
            commentrepo.AddToCollection(item);
        }

        public IList<Comment> GetAll()
        {
            return commentrepo.GetAll();
        }

        public Comment GetOneById(int Id)
        {
            return commentrepo.GetOneById(Id);
        }

        public bool LikeComment(User user, Comment comment)
        {
            return commentrepo.LikeComment(user, comment);
        }

        public void RemoveFromCollection(Comment item)
        {
            commentrepo.AddToCollection(item);
        }


    }
}
