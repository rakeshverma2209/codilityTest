using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TaskManagement
{
    public partial class TaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        public void refreshGrid() {
            DataLayer dl = new TaskManagement.DataLayer();
            DataTable dt = dl.getAllTasks();
            grdTaskList.DataSource = dt;
            grdTaskList.DataBind();
        }

        protected void grdTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grdTaskList.EditIndex = e.;
        }

        protected void grdTaskList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //grdTaskList.EditIndex = e.NewEditIndex;
            txtTaskTitle.Text = "";
            txtTaskDetails.Text = "";
            cldDueDate.SelectedDates.Clear();
            cldCompletedDate.SelectedDates.Clear();
            Session["selectedId"] = "0";
            Session["selectedId"] = Convert.ToInt32(grdTaskList.Rows[e.NewEditIndex].Cells[1].Text);
            txtTaskTitle.Text = grdTaskList.Rows[e.NewEditIndex].Cells[2].Text;
            txtTaskDetails.Text = grdTaskList.Rows[e.NewEditIndex].Cells[3].Text;
            cldDueDate.SelectedDate = Convert.ToDateTime(grdTaskList.Rows[e.NewEditIndex].Cells[4].Text);
            cldCompletedDate.SelectedDate = Convert.ToDateTime(grdTaskList.Rows[e.NewEditIndex].Cells[5].Text);
        }

        public void fillDetails() {
            
        }

        protected void btnUpdateTask_Click(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer();
            dl.updateTask(Convert.ToInt32(Session["selectedId"]), txtTaskTitle.Text, txtTaskDetails.Text, cldDueDate.SelectedDate, cldCompletedDate.SelectedDate);
            refreshGrid();
        }
    }
}