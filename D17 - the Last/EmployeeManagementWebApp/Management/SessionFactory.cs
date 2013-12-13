using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Management
{
    public static class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("EmployeeDatabase")).ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            return CreateSessionFactory().OpenSession();
        }
    }
}
