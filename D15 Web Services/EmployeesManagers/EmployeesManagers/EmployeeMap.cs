using FluentNHibernate.Mapping;

namespace EmployeesManagers
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Table("Cities");
            Id(x => x.Id).Column("cityid");
            Map(x => x.Name).Column("name");
        }
    }

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
            References(x => x.City).Column("city").Nullable();
        }
    }
}
