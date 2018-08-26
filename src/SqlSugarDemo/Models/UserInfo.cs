using System;
using SqlSugar;

namespace SqlSugarDemo.Models
{
    [SugarTable("UserInfo")]
    public class UserInfo
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public DateTime? RegTime { get; set; }
        public string Email { get; set; }
    }
}
