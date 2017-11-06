using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using FxSaude.Core.Domain;
using FxSaude.Core.Domain.Data;
using FxSaude.Core.Domain.Patterns;
using FxSaude.Produto.Domain.EF6.Data;
using FxSaude.Produto.Domain.Patterns;
using Microsoft.Practices.ServiceLocation;

namespace FxSaude.Produto.Domain.EF6.Patterns
{
    public class ProductUnityOfWork : IProductUnitOfWork
    {
        private readonly IDataContextProvider _dataContextProvider;
        private DbContext _dbContext;
        private bool _disposed;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private readonly Dictionary<string, dynamic> _repositories;

        public ProductUnityOfWork(ProductDataContextProvider dataContextProvider)
        {
            _dataContextProvider = dataContextProvider;
            _dbContext = dataContextProvider.GetDataContext() as DbContext;
            _repositories = new Dictionary<string, dynamic>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entidade
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IRepository<TEntity>>();
            }

            var key = GetRepositoryKey<TEntity>();
            if (_repositories.ContainsKey(key))
            {
                return _repositories[key];
            }

            var repositoryType = typeof(Repository<>);
            _repositories.Add(key, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContextProvider));

            return _repositories[key];
        }

        private static string GetRepositoryKey<TEntity>() where TEntity : Entidade
        {
            return typeof(TEntity).Name;
        }

        #region Transaction operations

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)_dbContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }

            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                CloseConnection();
                DisposeDbContext();
            }

            _disposed = true;
        }

        private void CloseConnection()
        {
            try
            {
                if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                {
                    _objectContext.Connection.Close();
                }
            }
            catch (ObjectDisposedException)
            {
                // do nothing, the objectContext has already been disposed
            }
        }

        private void DisposeDbContext()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
        #endregion


    }
}
