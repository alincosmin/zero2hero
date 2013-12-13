using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using EmployeeEntity;
using Management;

namespace EmployeeWebServices
{
    /// <summary>
    /// Summary description for Employees
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Employees : WebService
    {
        public static StorageSystem Storage;

        static Employees()
        {
            Storage = new StorageSystem();
        }

        [WebMethod]
        public List<Employee> GetAll()
        {
            return Storage.EmployeeList;
        }

        [WebMethod]
        public Employee Get(int id)
        {
            return Storage.Get(id);
        }

        [WebMethod]
        public void Create(Employee employee)
        {
            Storage.Add(employee);
        }

        [WebMethod]
        public void Update(Employee employee)
        {
            Storage.Update(employee);
        }

        [WebMethod]
        public void Delete(int id)
        {
            Storage.Delete(id);
        }
    }
}
