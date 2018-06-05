using CopyCMS.Domain;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Data
{
    public interface IBaseRepository<T> where T : BasePoco
    {
        void Delete(int id);
        void Delete(T entity);
        T GetById(int id);
        int GetCount();
        IEnumerable<T> GetList();
        void Save(T entity);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BasePoco
    {
        IUnitOfWork unitOfWork = null;

        protected IDbTransaction Transaction
        {
            get
            {
                return unitOfWork?.Transaction;
            }
        }

        protected IDbConnection Connection
        {
            get
            {
                return unitOfWork?.Connection;
            }
        }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int GetCount()
        {
            var result = unitOfWork.Connection.Count<T>(null, Transaction);
            return result;
        }

        public T GetById(int id)
        {
            var result = unitOfWork.Connection.Get<T>(id, Transaction);
            return result;
        }

        public IEnumerable<T> GetList()
        {
            var result = unitOfWork.Connection.GetList<T>(null,null, Transaction);
            return result;
        }

        public void Save(T entity)
        {
            if(entity.Id == 0)
            {
                unitOfWork.Connection.Insert(entity, Transaction);
            }
            else
            {
                unitOfWork.Connection.Update(entity, Transaction);
            }
        }

        public void Delete(T entity)
        {
            unitOfWork.Connection.Delete<T>(entity, Transaction);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

    }
}
