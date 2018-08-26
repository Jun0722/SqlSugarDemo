using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSugarDemo.Models;

namespace SqlSugarDemo.IRepository
{
    public interface IRepository<T> where T:class
    {
        TableModel<T>  GetPageList(int pageindex, int pageSize);
        T GetById(int id);
        List<T>  GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool DeleteById(int id);
        bool DelAll(dynamic[] ids);

    }
}
