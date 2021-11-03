using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
	public interface IBaseRepository<T>
	{
		public IList<T> GetAll(); // READ ALL
		public T GetOneById(int Id); // READ
		public void AddToCollection(T item); // CREATE, UPDATE
		public void RemoveFromCollection(T item); // DELETE
	}
}
