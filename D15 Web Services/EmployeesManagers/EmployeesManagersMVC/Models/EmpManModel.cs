using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EmployeesManagers;
using StoreService;

namespace EmployeesManagersMVC.Models
{
    public class EmpManModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name="Salary")]
        public double Salary { get; set; }

        [Required(AllowEmptyStrings = true)]
        [HiddenInput]
        public int ManagerId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name="Manager")]
        public string ManagerName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [HiddenInput]
        public int CityId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "City")]
        public string City { get; set; }
    }

    public class EMList
    {
        public static EmpManModel Find(int id)
        {
            EmpManModel _temp = null;
            var CurrentStorage = new Store();
            Employee _temp2 = CurrentStorage.FindEmployee(id);
            if (_temp2 != null)
            {
                _temp = new EmpManModel();
                _temp.FirstName = _temp2.FirstName;
                _temp.LastName = _temp2.LastName;
                _temp.Salary = _temp2.Salary;
                if (_temp2.Manager != null)
                    _temp.ManagerId = _temp2.Manager.Id;
                if (_temp2.City != null)
                    _temp.CityId = _temp2.City.Id;
                return _temp;
            }

            return _temp;
        }
        public static List<EmpManModel> List
        {
            get
            {
                EmpManModel _temp;
                List<EmpManModel> _list = new List<EmpManModel>();
                var CurrentStorage = new Store();
                foreach(Employee emp in CurrentStorage.EmpList)
                {
                    _temp = new EmpManModel();
                    _temp.Id = emp.Id;
                    _temp.FirstName = emp.FirstName;
                    _temp.LastName = emp.LastName;
                    _temp.Salary = emp.Salary;
                    if (emp.Manager != null)
                    {
                        _temp.ManagerId = emp.Manager.Id;
                        _temp.ManagerName = emp.Manager.FirstName + ' ' + emp.Manager.LastName;
                    }
                    if (emp.City != null)
                    {
                        _temp.CityId = emp.City.Id;
                        _temp.City = emp.City.Name;
                    }               
                    _list.Add(_temp);
                }
                return _list;
            }

        }

        public static void Add(EmpManModel _employee)
        {
            Employee E = new Employee();
            E.FirstName = _employee.FirstName;
            E.LastName = _employee.LastName;
            E.Salary = _employee.Salary;
            var CurrentStorage = new Store();
            if (_employee.ManagerId > 0)
                E.Manager = CurrentStorage.FindEmployee(_employee.ManagerId);
            if (_employee.CityId > 0)
                E.City = CurrentStorage.FindCity(_employee.CityId);
            CurrentStorage.AddOrUpdate(E);
        }

        public static void Update(EmpManModel _employee)
        {
            var CurrentStorage = new Store();
            Employee E = CurrentStorage.FindEmployee(_employee.Id);
            E.FirstName = _employee.FirstName;
            E.LastName = _employee.LastName;
            E.Salary = _employee.Salary;
            if (_employee.ManagerId > 0)
                E.Manager = CurrentStorage.FindEmployee(_employee.ManagerId);
            else E.Manager = null;
            if (_employee.CityId > 0)
                E.City = CurrentStorage.FindCity(_employee.CityId);
            else E.City = null;
            CurrentStorage.AddOrUpdate(E);
        }

        public static void Delete(int id)
        {
            var CurrentStorage = new Store();
            CurrentStorage.Delete(id);
        }
    }

    public class EmployeeName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EList
    {
        public static List<EmployeeName> List(int eid = 0)
        {
            EmployeeName _temp;
            List<EmployeeName> _list = new List<EmployeeName>();
            var CurrentStorage = new Store();
            foreach (Employee E in CurrentStorage.EmpList)
            {
                if (E.Id == eid)
                    continue;
                _temp = new EmployeeName();
                _temp.Id = E.Id;
                _temp.Name = E.FirstName + ' ' + E.LastName;
                _list.Add(_temp);
            }
            return _list;
        }
    }

    public class CList
    {
        public static List<City> List
        {
            get
            {
                List<City> _list = new List<City>();
                var CurrentStorage = new Store();
                foreach (City city in CurrentStorage.CitiesList)
                    _list.Add(city);
                return _list;
            }
        } 
    }
}