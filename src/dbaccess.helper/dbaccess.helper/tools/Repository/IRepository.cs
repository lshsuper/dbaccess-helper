using System;
using System.Collections.Generic;
using System.Text;

namespace dbaccess.helper.tools
{
    /// <summary>
    /// 基础仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// 单条数据
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(string connStr, object id);
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        IEnumerable<T> Query(string connStr);
        /// <summary>
        /// 插入单条
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        TKey Add<TKey>(string connStr, T obj);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Modify(string connStr, T obj);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Remove(string connStr, object id);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="conditions"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Remove(string connStr, string conditions, object param);
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name=""></param>
        /// <returns></returns>
        int Count(string connStr, string conditions = "", object parameters = null);
        
    }
}
