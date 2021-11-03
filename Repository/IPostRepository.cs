using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
	public interface IPostRepository : IBaseRepository<Post>
	{
		public void LikePost(User user, Post post);
		public void CommentPost(User user, Comment comment);
	}
}
