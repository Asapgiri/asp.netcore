using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
	public interface IExplorerLogic: IBaseLogic<Post>
	{
#nullable enable
		/**
		 * User user => current user if any
		 */
		public IList<Post>? GetExplorablePosts(User? user);
#nullable disable
	}
}
