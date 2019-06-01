﻿using System;
using System.Collections.Generic;
using System.Text;

namespace dbaccess.helper.tools
{
    /// <summary>
    /// 基础仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepository<T>where T:class,new()
    {
        /// <summary>
        /// 单条数据
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(string connStr,object id);
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(string connStr);
        /// <summary>
        /// 插入单条
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Insert(string connStr,T obj);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        int Insert(string connStr,IEnumerable<T> list);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Update(string connStr,T obj);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        bool Update(string connStr,IEnumerable<T> list);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Delete(string connStr,T obj);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        bool Delete(string connStr,IEnumerable<T> list);
        /// <summary>
        /// 删除所有
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        bool DeleteAll(string connStr);
    }
}
