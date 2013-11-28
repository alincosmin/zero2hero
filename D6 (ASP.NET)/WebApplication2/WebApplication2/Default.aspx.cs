using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    
    public partial class Default : System.Web.UI.Page
    {
        DropDownList myDDL = new DropDownList();
        Button myButton4 = new Button();
        Button myButton3 = new Button();
                      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                myCheckBox.Checked = true;
            else
            {
                myButton3.Text = "Buton dinamic";
                myButton3.ID = "myButton3";
                myButton3.Click += new System.EventHandler(this.myButton3_Click);
                myPlaceHolder.Controls.Add(myButton3);

                myButton4.Text = "Sparge-l pe celalalt!";
                myButton4.ID = "myButton4";
                myButton4.Click += new System.EventHandler(this.myButton4_Click);
                myPlaceHolder2.Controls.Add(myButton4);

            }

            myDDL.Items.Add("Element1");
            myDDL.Items.Add("Element2");
            myDDL.Items.Add("Element3");
            myDDL.Items.Add("Element4");
            myDDL.Items.Add("Element5");
            myDDL.SelectedIndexChanged += new System.EventHandler(this.myDDL_Selected_Change);
            myDDL.AutoPostBack = true;
            myPlaceHolder3.Controls.Add(myDDL);
        }

        protected void myButton_Click(object sender, EventArgs e)
        {
            myLabel.Text = myTextBox.Text;
            myTextBox.Text = string.Empty;
        }

        protected void myButton2_Click(object sender, EventArgs e)
        {
            Page.Title = Request.Form["myTextBox"];
            myTextBox.Text = string.Empty;
        }

        protected void myButton3_Click(object sender, EventArgs e)
        {
            myLabel.Text = "Butonu' dinamic in actiune!";
        }

        protected void myButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Page.FindControl("myButton3").Parent.Controls.Remove(Page.FindControl("myButton3"));
            }
            catch { }
        }

        protected void myDDL_Selected_Change(object sender, EventArgs e)
        {
            myLabel.Text = myDDL.Text;
        }

        protected void myCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            myPanel.Visible = myCheckBox.Checked;
        }
    }

}