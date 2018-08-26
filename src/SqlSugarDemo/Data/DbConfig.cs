using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace SqlSugarDemo.Data
{
    public static class DbConfig
    {
        //private static string DefaultSqlConnectionString = @"server=localhost;User Id=root;password=wx0604;Database=OnlineStore;SslMode=none";
        private static readonly string DefaultSqlConnectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                                              .AddJsonFile("appsettings.json")
                                                                                              .Build()["ConnectionStrings:Mysql"];

        public static SqlSugarClient GetClient()
        {
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = DefaultSqlConnectionString,
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true
                }
            );
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Debug.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };
            return db;
        }
    }
}
