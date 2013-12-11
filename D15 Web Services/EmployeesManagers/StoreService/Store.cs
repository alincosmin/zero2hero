using System.Linq;
using EmployeesManagers;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;

namespace StoreService
{
    public class Store
    {
        public IList<Employee> EmpList
        {
            get
            {
                var session = MySessionFactory.GetCurrentSession();
                return session.Query<Employee>().ToList();
            }
        }

        public IList<City> CitiesList
        {
            get
            {
                var session = MySessionFactory.GetCurrentSession();
                return session.Query<City>().ToList();
            }
        }

        public Employee FindEmployee(int id)
        {
            var session = MySessionFactory.GetCurrentSession();
            return session.Get<Employee>(id);
        }

        public City FindCity(int id)
        {
            var session = MySessionFactory.GetCurrentSession();
            return session.Get<City>(id);
        }

        public void AddOrUpdate(Employee employee)
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

        public void Delete(int id)
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