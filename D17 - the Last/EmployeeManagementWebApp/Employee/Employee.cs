namespace EmployeeEntity
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Salary { get; set; }
        public virtual Employee Manager { get; set; }
    }
}
