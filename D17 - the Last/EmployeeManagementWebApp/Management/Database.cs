using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Mapping;
using EmployeeEntity;

namespace Management
{
    public class Database
    {
        public List<Employee> EmployeeList
        {
            get
            {
                var session = SessionFactory.GetCurrentSession();
                return session.Query<Employee>().ToList();
            }
        }

        public Employee Get(int id)
        {
            var session = SessionFactory.GetCurrentSession();
            return session.Get<Employee>(id);
        }

        public void Add(Employee employee)
        {
            var session = SessionFactory.GetCurrentSession();
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

        public void Update(Employee employee)
        {
            Add(employee);
        }

        public void Delete(int id)
        {
            var session = SessionFactory.GetCurrentSession();
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
