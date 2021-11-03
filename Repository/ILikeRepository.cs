using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
	public interface ILikeRepository : IBaseRepository<Like>
	{
		public IList<Like> GetLikesByPost(Post post);
	}
}
