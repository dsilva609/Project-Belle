using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _Context;
		private readonly DbSet<T> _DBSet;

		public Repository(DbContext context)
		{
			this._Context = context;
			this._DBSet = context.Set<T>();
		}

		public virtual void Add(T entity)
		{
			this._DBSet.Add(entity);
			this._Context.SaveChanges();
		}

		public virtual void Delete(int ID)
		{
			var entry = this._DBSet.Find(ID);
			this._DBSet.Remove(entry);
			this._Context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return this._DBSet.ToList();
		}

		public T GetByID(int? ID)
		{
			return this._DBSet.Find(ID);
		}

		public void Edit(T entity)
		{
			this._Context.Entry(entity).State = EntityState.Modified;
			this._Context.SaveChanges();
		}

		private IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return this._DBSet.Where(predicate);
		}
	}
}