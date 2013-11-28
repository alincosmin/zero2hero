using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public Employee(string fn, string ln, string ct, string dpt, int sal)
        {
            FirstName = fn;
            LastName = ln;
            City = ct;
            Department = dpt;
            Salary = sal;
        }
    }

    public class EmployeeService
    {
        public static List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee("Coleman", "Kosloski", "Buffalo", "Marketing", 1900));
            employees.Add(new Employee("Annetta", "Jager", "Boston", "Human Resources", 1300));
            employees.Add(new Employee("Denny", "Peranio", "Madison", "Marketing", 900));
            employees.Add(new Employee("Kassie", "Duwe", "Irvine", "Human Resources", 2500));
            employees.Add(new Employee("Sean", "Hamiter", "Boston", "Quality Assurance", 2800));
            employees.Add(new Employee("Concha", "Anders", "Henderson", "IT", 2300));
            employees.Add(new Employee("Shemika", "Midgett", "Irving", "IT", 2100));
            employees.Add(new Employee("Cordie", "Crisler", "Plano", "Sales", 2700));
            employees.Add(new Employee("Mabelle", "Chewning", "New Jersey", "Services", 1700));
            employees.Add(new Employee("Lucien", "Schor", "Madison", "Sales", 500));
            employees.Add(new Employee("Elvie", "Coonrod", "Henderson", "IT", 1900));
            employees.Add(new Employee("Lynetta", "Wallner", "Lincoln", "Services", 1400));
            employees.Add(new Employee("Malcolm", "Spry", "Boston", "Quality Assurance", 1200));
            employees.Add(new Employee("Pamella", "Milo", "Lincoln", "Services", 1900));
            employees.Add(new Employee("Laine", "Gardin", "Plano", "Marketing", 2700));
            employees.Add(new Employee("Lilia", "Vanness", "Glendale", "Human Resources", 2500));
            employees.Add(new Employee("Travis", "Blecha", "Anchorage", "Human Resources", 3000));
            employees.Add(new Employee("Lenita", "Turco", "Plano", "Marketing", 1700));
            employees.Add(new Employee("Simone", "Deaton", "Boston", "Human Resources", 200));
            employees.Add(new Employee("Shemeka", "Vallee", "Newark", "Marketing", 1300));
            employees.Add(new Employee("Loma", "Chill", "Boston", "Marketing", 2200));
            employees.Add(new Employee("Lianne", "Borger", "Newark", "Quality Assurance", 1100));
            employees.Add(new Employee("Kiesha", "Barboza", "Irvine", "Marketing", 2400));
            employees.Add(new Employee("Cherilyn", "Burkley", "Fremont", "Human Resources", 2700));
            employees.Add(new Employee("Jacalyn", "Slowik", "Lubbock", "Services", 300));
            employees.Add(new Employee("Gino", "Sisk", "New Jersey", "Marketing", 2100));
            employees.Add(new Employee("Kristy", "Welborn", "Madison", "Services", 3000));
            employees.Add(new Employee("Arielle", "Traywick", "Glendale", "Sales", 2000));
            employees.Add(new Employee("Porsche", "Teeple", "Lincoln", "Marketing", 2600));
            employees.Add(new Employee("Rodger", "Willey", "Glendale", "Marketing", 3000));
            employees.Add(new Employee("Myesha", "Osby", "Madison", "IT", 900));
            employees.Add(new Employee("Will", "Cardone", "Anchorage", "Human Resources", 1600));
            employees.Add(new Employee("Norine", "Zuniga", "Madison", "IT", 2500));
            employees.Add(new Employee("Easter", "Hornberger", "Anchorage", "IT", 2600));
            employees.Add(new Employee("Rosendo", "Shiffer", "Buffalo", "Services", 900));
            employees.Add(new Employee("Coleen", "Rowell", "Toledo", "Services", 900));
            employees.Add(new Employee("Lamonica", "Kingrey", "Plano", "Quality Assurance", 200));
            employees.Add(new Employee("Anamaria", "Dugas", "Anchorage", "Quality Assurance", 2000));
            employees.Add(new Employee("Morton", "Miguez", "Plano", "Quality Assurance", 200));
            employees.Add(new Employee("Nicolas", "Pendergast", "Glendale", "Marketing", 2000));
            employees.Add(new Employee("Tom", "Gale", "Buffalo", "IT", 1000));
            employees.Add(new Employee("Gianna", "Hillman", "Stockton", "Human Resources", 700));
            employees.Add(new Employee("Myrtis", "Workman", "Newark", "Quality Assurance", 2300));
            employees.Add(new Employee("Morris", "Banegas", "Buffalo", "Sales", 200));
            employees.Add(new Employee("Tarsha", "Aronowitz", "Henderson", "Marketing", 400));
            employees.Add(new Employee("Rosanna", "Mckim", "Stockton", "Human Resources", 900));
            employees.Add(new Employee("Meta", "Meehan", "Lubbock", "Human Resources", 2200));
            employees.Add(new Employee("Tommie", "Border", "Lubbock", "IT", 2500));
            
            return employees;
        }
    }

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myRepeater.DataSource = EmployeeService.GetAll();
                myRepeater.DataBind();
            }
        }

    }
}