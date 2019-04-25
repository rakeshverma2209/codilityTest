using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace TaskManagement
{
    public class DataLayer
    {
        string connection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

        public bool authenticateUser(string userName,string password) {
            bool result = false;
            try
            {
                SqlConnection dbConnection = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("dbo.AuthenticateUser", dbConnection);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dbConnection.Open();
                da.Fill(dt);
                dbConnection.Close();
                if(Convert.ToInt32(dt.Rows[0][0]) == 1) {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            } 

            return result;
        }

        public bool saveTask(string title, string details, DateTime duedate, DateTime completedDate)
        {
            bool result = false;
            try
            {
                SqlConnection dbConnection = new SqlConnection(connection);
                dbConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_Tasks values('" + title + "','" + details +"','" + duedate + "','" + completedDate + "');", dbConnection);
                int r = cmd.ExecuteNonQuery();
                if(r == 1) {
                    result = true;
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool updateTask(int taskId , string title, string details, DateTime duedate, DateTime completedDate)
        {
            bool result = false;
            try
            {
                SqlConnection dbConnection = new SqlConnection(connection);
                dbConnection.Open();
                SqlCommand cmd = new SqlCommand("update tbl_Tasks set Title = '" + title + "',Details='" + details + "',DueDate = '" + duedate + "',CompletedDate='" + completedDate + "' where TaskId ="+taskId +";", dbConnection);
                int r = cmd.ExecuteNonQuery();
                if (r == 1)
                {
                    result = true;
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public DataTable getAllTasks()
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlConnection dbConnection = new SqlConnection(connection);
                dbConnection.Open();
                string query = "select * from tbl_Tasks order by DueDate desc";
                SqlCommand cmd = new SqlCommand(query, dbConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResult);
                dbConnection.Close();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtResult;
        }
    }
}