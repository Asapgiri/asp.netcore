using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class FriendRequestRepository: BaseRepo, IFriendRequestRepository
	{
		public FriendRequestRepository(InstantgramDbContext _context) : base(_context) {}
		public bool AcceptFriendRequest(int Id, User acceptor)
		{
			throw new NotImplementedException();
		}

		public void AddToCollection(Friendrequest item)
		{
			Friendrequest fr = GetOneById(item.FrndrqstId);
			if (fr == null)
			{
				context.Friendrequest.Add(item);
				context.SaveChanges();
			}
		}

		public bool DeeclineFriendRequest(int Id, User decliner)
		{
			Friendrequest fr = GetOneById(Id);
			if (fr.Requested.Id == decliner.Id)
			{
				RemoveFromCollection(fr);
				return true;
			}
			return false;
		}

		public IList<Friendrequest> GetAll()
		{
			return context.Friendrequest.ToList();
		}

		public Friendrequest GetOneById(int Id)
		{
			return context.Friendrequest.FirstOrDefault(t => t.FrndrqstId == Id);
		}

		public void RemoveFromCollection(Friendrequest item)
		{
			context.Friendrequest.Remove(item);
			context.SaveChanges();
		}
	}
}
