﻿using System.Collections.Generic;

namespace BusinessLogic.Repositories
{
	public interface IRepository<T>
	{
		void Add(T entity);

		List<T> GetAll();

		T GetByID(int? ID);

		void Edit(T entity);

		void Delete(int ID);
	}
}