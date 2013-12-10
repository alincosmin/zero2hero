using System.Linq;
using EmployeesManagers;
using NHibernate;
using NHibernate.Engine.Loading;
using NHibernate.Linq;
using System.Collections.Generic;

namespace StoreService
{
    public class Store
    {
        public static IList<Employee> EmpList
        {
            get
            {
                var session = MySessionFactory.GetCurrentSession();
                return session.Query<Employee>().ToList();
            }
        }

        public static IList<City> CitiesList
        {
            get
            {
                var session = MySessionFactory.GetCurrentSession();
                return session.Query<City>().ToList();
            }
        }

        public static Employee FindEmployee(int id)
        {
            var session = MySessionFactory.GetCurrentSession();
            return session.Get<Employee>(id);
        }

        public static City FindCity(int id)
        {
            var session = MySessionFactory.GetCurrentSession();
            return session.Get<City>(id);
        }

        public static void AddOrUpdate(Employee employee)
        {
            var session = MySessionFactory.GetCurrentSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(employee);
                    session.Flush();
                    session.Clear();
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public static void Delete(int id)
        {
            var session = MySessionFactory.GetCurrentSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(session.Load<Employee>(id));
                    session.Flush();
                    session.Clear();
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}