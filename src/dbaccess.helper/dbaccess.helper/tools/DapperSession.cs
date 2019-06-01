using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;

namespace dbaccess.helper.tools
{
    /// <summary>
    /// 数据库基本操作方法
    /// </summary>
    public class DapperSession
    {
        private static readonly object _lockDapper = new object();
        private static DapperSession _dbSession;
        /// <summary>
        /// dbSession单例
        /// </summary>
        public  static DapperSession DbSession
        {
            get
            {
                if (_dbSession != null)
                    return _dbSession;
                lock (_lockDapper)
                {
                    if (_dbSession != null)
                        return _dbSession;
                    _dbSession = new DapperSession();
                }
                return _dbSession;
            }
        }
        public IDbConnection GetDbConn(string connStr)
        {
            return DapperFactory.Conn(connStr);
        }
        public bool Excute(string connStr, string sql)
        {
            using (var conn= DapperFactory.Conn(connStr))
            {
                return conn.Execute(sql) > 0;
            }
            
        }

        public List<T> Query<T>(string connStr, string sql)
        {
            using (var conn = DapperFactory.Conn(connStr))
            {
                return conn.Query<T>(sql).ToList();
            }
        }

        public T QueryFirst<T>(string connStr, string sql)
        {
            using (var conn = DapperFactory.Conn(connStr))
            {
                return conn.QueryFirstOrDefault<T>(sql);
            }
              
        }
    }
}
