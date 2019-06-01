using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using static Dapper.SimpleCRUD;

namespace dbaccess.helper.tools
{
    /// <summary>
    /// dapper连接工厂
    /// </summary>
    internal class DapperFactory
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <param name="dbConnStr"></param>
        /// <returns></returns>
        public static IDbConnection Conn(string dbConnStr)
        {
            //可读数据库配置
            Dialect _dataBaseType = Dialect.PostgreSQL;
            IDbConnection conn = null;
            switch (_dataBaseType)
            {
                case Dialect.SQLServer:
                    conn= new SqlConnection(dbConnStr);
                    break;
                case Dialect.MySQL:
                    conn= new MySqlConnection(dbConnStr);
                    break;
                case Dialect.PostgreSQL:
                    conn= new NpgsqlConnection(dbConnStr);
                    break;
                default:
                    throw new NotImplementedException("未实现");
            }
            if (conn != null)
                SetDialect(_dataBaseType);
            return conn;
        }
    }
}
