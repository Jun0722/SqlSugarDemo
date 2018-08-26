using System;
using System.Collections.Generic;

namespace SqlSugarDemo.Models
{
    /// <summary>
    /// 表格数据 支持分页
    /// </summary>
    public class TableModel<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
