using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class PostRepository: BaseRepo, IPostRepository
	{
		private CommentRepository commRepo;
		private LikeRepository likeRepo;
		public PostRepository(InstantgramDbContext _context) : base(_context)
		{
			commRepo = new CommentRepository(_context);
			likeRepo = new LikeRepository(_context);
		}
		public void AddToCollection(Post item)
		{
			context.Posts.Add(item);
			context.SaveChanges();
		}

		public void CommentPost(User user, Comment comment)
		{
			commRepo.AddToCollection(comment);
		}

		public IList<Post> GetAll()
		{
			return context.Posts.OrderByDescending(x => x.PostId).ToList();
		}

		public Post GetOneById(int Id)
		{
			return context.Posts.FirstOrDefault(t => t.PostId == Id);
		}

		public void LikePost(User user, Post post)
		{
			List<Like> likes = (List<Like>)likeRepo.GetLikesByPost(post);
			Like oneLike = likes.FirstOrDefault(t => t.Author.Id == user.Id);
			if (oneLike == null)
			{
				oneLike = new Like();
				oneLike.Author = user;
				oneLike.Post = post;
				likeRepo.AddToCollection(oneLike);
			}
			else
			{
				likeRepo.RemoveFromCollection(oneLike);
			}
			post.Likes = likeRepo.GetAll().Count;
			context.SaveChanges();
		}

		public void RemoveFromCollection(Post item)
		{
			context.Posts.Remove(item);
			context.SaveChanges();
		}
	}
}
