using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SqlSugar;
using SqlSugarDemo.Data;
using SqlSugarDemo.IRepository;
using SqlSugarDemo.Models;

namespace SqlSugarDemo.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private SqlSugarClient db = DbConfig.GetClient();

        public SimpleClient<UserInfo> sdb = new SimpleClient<UserInfo>(DbConfig.GetClient());

        public TableModel<UserInfo> GetPageList(int pageindex, int pageSize)
        {
            PageModel pageModel = new PageModel() { PageIndex = pageindex, PageSize = pageSize };
            Expression<Func<UserInfo, bool>> ex = (n => true);
            List<UserInfo> data = sdb.GetPageList(ex, pageModel);
            TableModel<UserInfo> table = new TableModel<UserInfo>
            {
                Code = 200,
                Count = pageModel.PageCount,
                Data = data,
                Msg = "Successful"
            };
            return table;
        }

        public UserInfo GetById(int id)
        {
            return sdb.GetById(id);
        }

        public List<UserInfo> GetAll()
        {
            return sdb.GetList();
        }

        public bool Add(UserInfo entity)
        {
            return sdb.Insert(entity);
        }

        public bool Update(UserInfo entity)
        {
            return sdb.Update(entity);
        }

        public bool DeleteById(int id)
        {
            return sdb.DeleteById(id);
        }

        public bool DelAll(dynamic[] ids)
        {
            return sdb.DeleteByIds(ids);
        }
    }
}
