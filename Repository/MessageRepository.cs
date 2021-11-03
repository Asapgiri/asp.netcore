using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class MessageRepository: BaseRepo, IMessageRepository
	{
		public MessageRepository(InstantgramDbContext _context) : base(_context) { }
		public void AddToCollection(Message item)
		{
			Message msg = GetOneById(item.MessageId);
			if (msg == null)
			{
				context.Messages.Add(item);
			}
			else
			{
				msg.LeMessage = item.LeMessage;
				msg.LastModified = DateTime.Now;
			}
			context.SaveChanges();
		}

		public IList<Message> GetAll()
		{
			return context.Messages.ToList();
		}

		public Message GetOneById(int Id)
		{
			return context.Messages.FirstOrDefault(t => t.MessageId == Id);
		}

		public void RemoveFromCollection(Message item)
		{
			context.Messages.Remove(item);
			context.SaveChanges();
		}
	}
}
