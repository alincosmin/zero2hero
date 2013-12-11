using EmployeesManagers;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace StoreService
{
    public static class MySessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("EmpConnString")).ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            return CreateSessionFactory().OpenSession();
        }
    }
}
