using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataLayer dl = new TaskManagement.DataLayer();
            if(txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "") {
                bool result = dl.authenticateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if(result) {
                    Session["IsGuest"] = false;
                    Response.Redirect("Tasks.aspx");
                }
            }
        }

        protected void btnGuestUser_Click(object sender, EventArgs e)
        {
            Session["IsGuest"] = true;
            Response.Redirect("TaskList.aspx");
        }
    }
}