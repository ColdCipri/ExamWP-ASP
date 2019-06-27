using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ExamWP_ASP
{
    public partial class index : System.Web.UI.Page
    {
        string conn = @"Server=localhost;Database=webdb;Uid=root;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridFill();
            }
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conn))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("AddOrEditCourse", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_ID", Convert.ToInt32(hiddenfieldID.Value == "" ? "0" : hiddenfieldID.Value));
                    sqlCmd.Parameters.AddWithValue("_Name", textName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_Professor", textProfessor.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_Duration", Convert.ToInt32(textDuration.Text.Trim()));
                    sqlCmd.ExecuteNonQuery();

                    GridFill();
                    Clear();

                    labelSuccessMessage.Text = "Submitted Sucessfully!";
                }
            }
            catch (Exception ex)
            {
                labelErrorMessage.Text = ex.Message;
            }

        }
        protected void buttonSaveRestriction_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conn))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("AddOrEditRestriction", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_ID", TextBoxCourseID.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_Restriction", TextBoxRestriction.Text.Trim());
                    sqlCmd.ExecuteNonQuery();

                    GridFill();
                    Clear();

                    label1.Text = "Submitted Sucessfully!";
                }
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
            }

        }
        
        private void LoadCourses()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                DataTable courses = new DataTable();
                sqlCon.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT name FROM courses", conn);
                adapter.Fill(courses);

                CourseList.DataSource = courses;
                CourseList.DataTextField = "name";
                CourseList.DataValueField = "name";
                CourseList.DataBind();
            }
        }


        protected void linkSelect_OnClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("coursesviewbyid", sqlCon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("_ID", ID);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                textName.Text = dataTable.Rows[0][1].ToString();
                textProfessor.Text = dataTable.Rows[0][2].ToString();
                textDuration.Text = dataTable.Rows[0][3].ToString();

                hiddenfieldID.Value = dataTable.Rows[0][0].ToString();

                buttonSave.Text = "Update";
            }
        }

        protected void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void GridFill()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("coursesviewall", sqlCon);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                gvName.DataSource = dataTable;
                gvName.DataBind();
            }
        }

        void Clear()
        {
            hiddenfieldID.Value = "";
            textName.Text = textProfessor.Text = textDuration.Text = "";
            buttonSave.Text = "Save";
            labelErrorMessage.Text = labelSuccessMessage.Text = "";
        }
    }
}