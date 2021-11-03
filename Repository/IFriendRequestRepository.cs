using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
	public interface IFriendRequestRepository : IBaseRepository<Friendrequest>
	{
		/**
		 * User acceptor => Logged in user!! Must be the same as the REQUESTED or ADMIN!!!
		 */
		public bool AcceptFriendRequest(int Id, User acceptor);
		public bool DeeclineFriendRequest(int Id, User decliner);
	}
}
