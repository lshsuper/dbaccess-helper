using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Dapper;
namespace dbaccess.helper.tools.Repository
{
    /// <summary>
    /// 基础仓储实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        protected DapperSession _dbSession;
        public BaseRepository()
        {
            _dbSession = DapperSession.DbSession;
        }

        public bool Delete(string connStr, object id)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                
               return  conn.Delete<T>(id)>0;
            }
        }

        public bool Delete(string connStr, string conditions, object param)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.DeleteList<T>(conditions, param)>0;
            }
        }
        public T Get(string connStr, object id)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.Get<T>(id);
            }
        }

        public IEnumerable<T> GetAll(string connStr)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.GetList<T>();
            }
        }

        public TKey Insert<TKey>(string connStr, T obj)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
               return conn.Insert<TKey,T>(obj);
            }
        }

       

        public bool Update(string connStr, T obj)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
                return conn.Update(obj)>0;
            }
        }
    }
}
