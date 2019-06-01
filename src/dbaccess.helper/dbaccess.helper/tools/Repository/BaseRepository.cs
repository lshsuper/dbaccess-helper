using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib;
using System.Linq;
using Dapper.Contrib.Extensions;

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

        public bool Delete(string connStr, T obj)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
               return  conn.Delete(obj);
            }
        }

        public bool Delete(string connStr, IEnumerable<T> list)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.Delete(list);
            }
        }

        public bool DeleteAll(string connStr)
        {
            using (var conn=_dbSession.GetDbConn(connStr))
            {
                return conn.DeleteAll<T>();
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
                return conn.GetAll<T>();
            }
        }

        public int Insert(string connStr, T obj)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
                return Convert.ToInt32(conn.Insert(obj));
            }
        }

        public int Insert(string connStr, IEnumerable<T> list)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
                return Convert.ToInt32(conn.Insert(list));
            }
        }

        public bool Update(string connStr, T obj)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
                return conn.Update(obj);
            }
        }

        public bool Update(string connStr, IEnumerable<T> list)
        {
            using (var conn = _dbSession.GetDbConn(connStr))
            {
                return conn.Update(list);
            }
        }
    }
}
