using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogic.Repositories
{
	public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext, new()
	{
		private readonly DbContext _Context;
		private readonly Dictionary<Type, object> _Repositories;
		private bool _IsDisposed;

		public UnitOfWork()
		{
			this._Context = new TContext();
			this._Repositories = new Dictionary<Type, object>();
			this._IsDisposed = false;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._IsDisposed)
			{
				if (disposing)
				{
					this._Context.Dispose();
				}

				this._IsDisposed = true;
			}
		}

		public IRepository<TContext> GetRepository<TContext>() where TContext : class
		{
			if (this._Repositories.Keys.Contains(typeof(TContext)))
				return this._Repositories[typeof(TContext)] as IRepository<TContext>;

			var repository = new Repository<TContext>(this._Context);
			this._Repositories.Add(typeof(TContext), repository);
			return repository;
		}

		public void SaveChanges()
		{
			this._Context.SaveChanges();
			this._Context.Dispose();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~UnitOfWork()
		{
			this._Context.Dispose();
		}
	}
}