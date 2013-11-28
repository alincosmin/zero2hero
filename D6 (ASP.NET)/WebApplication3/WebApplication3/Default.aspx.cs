using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                myLabel.Text += "[Page_Load() - IsPostBack]";
            else
                myLabel.Text += "[Page_Load() - IsNotPostBack]";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            myLabel.Text += "[Page_Init()]";
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            myLabel.Text += "[Page_Unload()]";
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            myLabel.Text += "[Page_PreInit()]";
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            myLabel.Text += "[Page_Prerender()]";
        }

        protected void myButton_Click(object sender, EventArgs e)
        {
            myLabel.Text += "[Button_Click()]";
        }

        protected void myButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect(myLink.NavigateUrl);
        }
    }
}