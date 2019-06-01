using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            DapperTypeEnum _dataBaseType = DapperTypeEnum.SqlServer;
            switch (_dataBaseType)
            {
                case DapperTypeEnum.SqlServer:
                    return new SqlConnection(dbConnStr);

                case DapperTypeEnum.MySql:
                    throw new NotImplementedException("未实现");
                default:
                    throw new NotImplementedException("未实现");
            }

        }
    }
}
