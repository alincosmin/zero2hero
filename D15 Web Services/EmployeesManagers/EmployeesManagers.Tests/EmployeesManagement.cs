using System.Web.Mvc;
using EmployeesManagersMVC.Controllers;
using EmployeesManagersMVC.Models;
using NUnit.Framework;
using StoreService;

namespace EmployeesManagers.Tests
{
    [TestFixture]
    public class EmployeesManagement
    {
        [Test]
        public void AddEmployee()
        {
            var controller = new EMListController();
            var E = new EmpManModel();
            E.FirstName = "A";
            E.Salary = 1;
            var CurrentStorage = new Store();
            int count = CurrentStorage.EmpList.Count;
            controller.New(E);
            Assert.AreEqual(count+1,CurrentStorage.EmpList.Count);
        }
    }
}
