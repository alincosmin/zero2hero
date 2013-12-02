using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication5
{
    public partial class Employees1 : System.Web.UI.Page
    {
        protected void LoadEmployees()
        {
            ListItem x = new ListItem();
            x.Value = "0";
            x.Text = "- is manager -";
            
            ddlMgr.DataTextField = "Name";
            ddlMgr.DataValueField = "Id";
            ddlMgr.DataSource = EmployeeService.GetAll();
            ddlMgr.DataBind();
            ddlMgr.Items.Insert(0, x);
           
        }

        private void LoadEmployeesOnEdit(Employee E)
        {
            saveBtn.Click -= Save_Emp;
            saveBtn.Click += Save_Changes;
            txtName.Text = E.Name;
            txtSal.Text = E.Salary.ToString();
            //ddlMgr.Items.RemoveAt(EmployeeService.GetAll().IndexOf(E)+1);
            ddlMgr.SelectedValue = (E.Manager != null ? E.Manager.Id.ToString() : "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            Employee X = (Employee)HttpContext.Current.Session["Target"];
            HttpContext.Current.Session["Target"] = null;
            if (X != null)
            {
                LoadEmployeesOnEdit(X);
            }
        }

        protected void Save_Emp(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int mgr = 0;
            if (ddlMgr.SelectedValue == "0")
                mgr = Convert.ToInt32(ddlMgr.SelectedItem.Value);
            string pattern = @"0|([1-9]+[0-9]*)";
            double sal;
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            if (rgx.IsMatch(txtSal.Text))
                sal = Convert.ToDouble(txtSal.Text);
            else sal = 0;
            Random rnd = new Random();
            int id = rnd.Next(1, 100);
            List<Employee> X = EmployeeService.GetAll();
            while (X != null && X.Find(i => i.Id == id) != null)
                    id = rnd.Next(1, 100);
            EmployeeService.Add(new Employee(id, name,(mgr != 0)?X.Find(x => x.Id == mgr):null, sal));
            txtName.Text = string.Empty;
            txtSal.Text = string.Empty;
            Response.Redirect("Default.aspx");
        }

        protected void Save_Changes(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int mgr = 0;
            if (ddlMgr.SelectedValue != "")
                mgr = Convert.ToInt32(ddlMgr.SelectedItem.Value);
            string pattern = @"0|([1-9]+[0-9]*)";
            double sal = 0;
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            if (rgx.IsMatch(txtSal.Text))
                sal = Convert.ToDouble(txtSal.Text);
            
            Employee Y = (Employee)HttpContext.Current.Session["Target"];
            Y.Name = name;
            Y.Salary = sal;
            Y.Manager = EmployeeService.GetAll().Find(x => x.Id == mgr);
            HttpContext.Current.Session["Target"] = Y;
            Response.Redirect("Default.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Target"] == null)
                Save_Emp(sender, e);
            else
                Save_Changes(sender, e);
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}