using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class CommentRepository : BaseRepo, ICommentRepository
	{
		public CommentRepository(InstantgramDbContext _context) : base(_context) {}
		public void AddToCollection(Comment item)
		{
			Comment oldComment = GetOneById(item.CommentId);
			if (oldComment != null)
			{
				oldComment.LastModified = DateTime.Now;
				if (item.Message != "") oldComment.Message = item.Message;
				else RemoveFromCollection(oldComment);
			}
			else
			{
				context.Comments.Add(item);
			}
			context.SaveChanges();
		}

		public IList<Comment> GetAll()
		{
			return context.Comments.ToList();
		}

		public Comment GetOneById(int Id)
		{
			return context.Comments.FirstOrDefault(t => t.CommentId == Id);
		}

		public bool LikeComment(User user, Comment comment)
		{
			throw new NotImplementedException();
		}

		public void RemoveFromCollection(Comment item)
		{
			context.Comments.Remove(item);
			context.SaveChanges();
		}
	}
}
