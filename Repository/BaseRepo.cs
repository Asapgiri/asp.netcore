using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public abstract class BaseRepo
	{
		protected InstantgramDbContext context;
		public BaseRepo(InstantgramDbContext _context)
		{
			this.context = _context;
		}
	}
}
