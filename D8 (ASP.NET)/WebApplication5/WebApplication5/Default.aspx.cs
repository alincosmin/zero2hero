using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Employees : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Employee X = (Employee) HttpContext.Current.Session["Target"];
            if (X != null)
            {
                if (EmployeeService.GetAll().Find(y => y.Id == X.Id) != null)
                    EmployeeService.Edit(X, X.Name, X.Manager.Id, X.Salary);
                else
                    EmployeeService.Add(X);
                HttpContext.Current.Session["Target"] = null;
            }
            
        }

        protected void GoToAdd(object sender, EventArgs e)
        {
            Response.Redirect("Employees.aspx");
        }

        protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Employee X = EmployeeService.GetAll().Find(x => x.Id == Convert.ToInt32(e.CommandArgument));
            if (e.CommandName == "myDelete")
            {
                myLabel.Text = "Are you sure you want to delete (" +
                   e.CommandArgument + ") " +
                   X.Name + "?";
            }

            if (e.CommandName == "myEdit")
            {
                HttpContext.Current.Session["Target"] = X;
                Response.Redirect("Employees.aspx");
            }
        }



    }
}