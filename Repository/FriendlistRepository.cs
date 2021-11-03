using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class FriendlistRepository: BaseRepo, IFriendlistRepository
	{
		public FriendlistRepository(InstantgramDbContext _context) : base(_context) { }
		public void AddToCollection(Friendlist item)
		{
			Friendlist friend = GetOneById(item.FriendlistId);
			if (friend ==  null)
			{
				context.Friendlist.Add(item);
				context.SaveChanges();
			}
		}

		public IList<Friendlist> GetAll()
		{
			return context.Friendlist.ToList();
		}

		public Friendlist GetOneById(int Id)
		{
			return context.Friendlist.FirstOrDefault(t => t.FriendlistId == Id);
		}

		public void RemoveFromCollection(Friendlist item)
		{
			context.Friendlist.Remove(item);
			context.SaveChanges();
		}
	}
}
