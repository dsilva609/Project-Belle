﻿using BusinessLogic.Repositories;

namespace BusinessLogic.Components.CrudComponents
{
	public class AddEntityComponent
	{
		public void Execute<T>(IRepository<T> repo, T entity) where T : class
		{
			repo.Add(entity);
		}
	}
}