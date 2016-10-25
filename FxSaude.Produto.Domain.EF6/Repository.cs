using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FxSaude.Core.Domain;

namespace FxSaude.Produto.Domain.EF6
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entidade
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(IDataContextProvider dataContextProvider)
        {
            var dbContext = dataContextProvider.GetDataContext() as DbContext;
            _dbSet = dbContext?.Set<TEntity>();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
    