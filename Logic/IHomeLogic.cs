using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
	public interface IHomeLogic: IBaseLogic<Post>
	{
		public void LikePost(int postId, User user);
		public void MakeComment(int postId, User user, string comment);
#nullable enable
		public IList<Post>? GetFollowedPosts(User? user);
#nullable disable
	}
}
