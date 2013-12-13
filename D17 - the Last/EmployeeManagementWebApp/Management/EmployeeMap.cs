using EmployeeEntity;
using FluentNHibernate.Mapping;

namespace Management
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            Id(x => x.Id).Column("empid");
            Map(x => x.FirstName).Column("firstname");
            Map(x => x.LastName).Column("lastname").Nullable();
            Map(x => x.Salary).Column("Salary");
            References(x => x.Manager).Column("mgr").Nullable();
        }
    }
}
