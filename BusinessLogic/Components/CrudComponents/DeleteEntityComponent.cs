﻿using BusinessLogic.Repositories;

namespace BusinessLogic.Components.CrudComponents
{
	public class DeleteEntityComponent
	{
		public void Execute<T>(IRepository<T> repo, int ID) where T : class
		{
			repo.Delete(ID);
		}
	}
}