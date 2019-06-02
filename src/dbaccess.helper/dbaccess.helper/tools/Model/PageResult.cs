using System;
using System.Collections.Generic;
using System.Text;

namespace dbaccess.helper.tools.Model
{

    
    public class PageResult<T>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
