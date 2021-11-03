using Models;

namespace Repository
{
	public interface ICommentRepository: IBaseRepository<Comment>
	{
		public bool LikeComment(User user, Comment comment);
	}
}
