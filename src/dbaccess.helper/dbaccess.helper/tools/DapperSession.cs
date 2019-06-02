using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;
using dbaccess.helper.tools.Model;

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
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Excute(string connStr, string sql)
        {
            using (var conn= DapperFactory.Conn(connStr))
            {
                return conn.Execute(sql);
            }
            
        }
        /// <summary>
        /// 查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> Query<T>(string connStr, string sql)
        {
            using (var conn = DapperFactory.Conn(connStr))
            {
                return conn.Query<T>(sql).ToList();
            }
        }
        /// <summary>
        /// 查单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string connStr, string sql)
        {
            using (var conn = DapperFactory.Conn(connStr))
            {
                return conn.QueryFirstOrDefault<T>(sql);
            }
              
        }
        /// <summary>
        /// 分页查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public PageResult<T> Page<T>(string connStr,string sql,object param=null)
        {
            PageResult<T> model = new PageResult<T>();
            using (var conn = DapperFactory.Conn(connStr))
            {
                using (var muilt = conn.QueryMultiple(sql, param))
                {
                    model.Total = muilt.Read<int>().FirstOrDefault();
                    model.Data = muilt.Read<T>();
                    return model;
                }
               
            }
        }
    }
}
