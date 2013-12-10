namespace EmployeesManagers
{
    public class Employee
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual double Salary { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual City City { get; set; }
    }
}
