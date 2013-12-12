using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using EmployeesManagers;
using EmployeesManagersMVC.Models;
using StoreService;

namespace WebServices
{
    /// <summary>
    /// Summary description for EmployeesWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeesWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Employee> GetAll()
        {
            var store = new Store();
            var _temp = new List<Employee>();
            Employee _emp = null;
            foreach (Employee employee in store.EmpList)
            {
                _emp = new Employee();
                _emp.FirstName = employee.FirstName;
                _emp.LastName = employee.LastName;
                _emp.Salary = employee.Salary;
                _emp.Manager = employee.Manager;
                _emp.City = employee.City;
                _temp.Add(_emp);
            }
            return _temp;
        }

        [WebMethod]
        public Employee Get(int id)
        {
            var store = new Store();
            return store.FindEmployee(id);
        }

        [WebMethod]
        public void CreateOrUpdate(Employee employee)
        {
            var store = new Store();
            store.AddOrUpdate(employee);
        }

        [WebMethod]
        public void Delete(int id)
        {
            var store = new Store();
            store.Delete(id);
        }

    }
}
