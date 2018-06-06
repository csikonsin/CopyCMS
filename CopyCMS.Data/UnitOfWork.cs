using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();

        IWebsiteRepository WebsiteRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IMenuRepository MenuRepository { get;  }

        IContentRepository ContentRepository { get; }
    }

    public sealed class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Id = Guid.NewGuid();
            Connection = Data.Connection.GetSql();
        }

        internal UnitOfWork(IDbConnection connection)
        {
            Id = Guid.NewGuid();
            Connection = connection;
        }

        internal UnitOfWork(string connectionString)
        {
            Id = Guid.NewGuid();
            Connection = new System.Data.SqlClient.SqlConnection(connectionString);
        }

        public Guid Id { get; } = Guid.Empty;
        public IDbConnection Connection { get; private set; } = null;
        public IDbTransaction Transaction { get; private set; } = null;
        private bool _disposed;

        private IWebsiteRepository _websiteRepository;
        private IModuleRepository _moduleRepository;
        private IMenuRepository _menuRepository;
        private IContentRepository _contentRepository;

        public IWebsiteRepository WebsiteRepository { get { return _websiteRepository ?? (_websiteRepository = new WebsiteRepository(this)); } }
        public IModuleRepository ModuleRepository { get { return _moduleRepository ?? (_moduleRepository = new ModuleRepository(this)); } }
        public IMenuRepository MenuRepository { get { return _menuRepository ?? (_menuRepository = new MenuRepository(this)); } }

        public IContentRepository ContentRepository {  get { return _contentRepository ?? (_contentRepository = new ContentRepository(this)); } }

        private void ResetRepositories()
        {
            _websiteRepository = null;
            _moduleRepository = null;
            _menuRepository = null;
            _contentRepository = null;
        }

        public void Begin()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch (Exception)
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = Connection.BeginTransaction();
                ResetRepositories();
            }

        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}