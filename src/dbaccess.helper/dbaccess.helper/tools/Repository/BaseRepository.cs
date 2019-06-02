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

        public bool Remove(string connStr, object id)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                
               return  conn.Delete<T>(id)>0;
            }
        }

        public bool Remove(string connStr, string conditions, object param)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.DeleteList<T>(conditions, param)>0;
            }
        }
        public T Find(string connStr, object id)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.Get<T>(id);
            }
        }

        public IEnumerable<T> Query(string connStr)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.GetList<T>();
            }
        }

        public TKey Add<TKey>(string connStr, T obj)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
               return conn.Insert<TKey,T>(obj);
            }
        }

       

        public bool Modify(string connStr, T obj)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
                return conn.Update(obj)>0;
            }
        }

        public int Count(string connStr, string conditions = "", object parameters = null)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.RecordCount<T>();
            }
        }
    }
}
