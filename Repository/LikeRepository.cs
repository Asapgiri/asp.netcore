using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class LikeRepository: BaseRepo, ILikeRepository
	{
		public LikeRepository(InstantgramDbContext _context) : base(_context) { }
		public void AddToCollection(Like item)
		{
			context.Likes.Add(item);
			context.SaveChanges();
		}

		public IList<Like> GetAll()
		{
			return context.Likes.ToList();
		}

		public Like GetOneById(int Id)
		{
			return context.Likes.FirstOrDefault(t => t.LikeId == Id);
		}

		public IList<Like> GetLikesByPost(Post post)
		{
			return context.Likes.Where(t => t.Post.PostId == post.PostId).ToList();
		}

		public void RemoveFromCollection(Like item)
		{
			context.Likes.Remove(item);
			context.SaveChanges();
		}
	}
}
