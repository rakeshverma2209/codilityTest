using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManagement
{
    public partial class Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IsGuest = Session["IsGuest"].ToString();
            if(IsGuest == "True") {
                Response.Redirect("TaskList.aspx");
            }
        }

        protected void btnSaveTask_Click(object sender, EventArgs e)
        {
            DateTime duedate = cldDueDate.SelectedDate;
            DateTime completedate = cldCompletedDate.SelectedDate;
            DataLayer dl = new TaskManagement.DataLayer();
            if (txtTaskTitle.Text.Trim() != "" && txtTaskDetails.Text.Trim() !="") {
                bool resul = dl.saveTask(txtTaskTitle.Text.Trim(), txtTaskDetails.Text.Trim(), duedate, completedate);
            }
        }

        protected void btnTaskList_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaskList.aspx");
        }
    }
}