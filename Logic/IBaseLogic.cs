using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
	public interface IBaseLogic<T>
	{
		public void Create(T item);
		public void Update(T item);
		public void Delete(T item);
		public T GetOne(int itemId);
		public IList<T> GetAll();
	}
}
