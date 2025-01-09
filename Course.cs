using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EsoftLastProject
{
    public partial class Course : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        String uname, Age, ID,CName,Fees,Duration,TID;

        public void LoadData()
        {
            con.Open();
            String sqlqry = "SELECT * FROM Course";
            SqlDataAdapter da = new SqlDataAdapter(sqlqry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Course");
            dgvCourse.DataSource = ds.Tables["Course"].DefaultView;
            con.Close();
        }

        public void clear()
        {
            txtCourseId.Clear();
            txtCourseName.Clear();
            txtTime.Clear();
            txtFee.Clear();
            txtTecherId.Clear();
        }

        public Course()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ID=txtCourseId.Text;
            CName=txtCourseName.Text;
            Duration = txtTime.Text;
            Fees = txtFee.Text;
            TID = txtTecherId.Text;

            string sqlqry = "SELECT* FROM Teachers WHERE TeacherId='" + TID + "'";
            cmd = new SqlCommand(sqlqry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                uname = dr["Name"].ToString();
              
            }
            con.Close();

            if (uname == "")
            {
                MessageBox.Show("Teacher Id Is Wrong.........!!!!!!!!!Please Enter Correct Teacher Id....... ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sqlqry = "INSERT INTO Course VALUES('" + ID + "','" + CName + "','" + Duration + "','" + Fees + "','" + TID + "');";
                cmd = new SqlCommand(sqlqry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfuly...!", "Success!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                con.Close();
                LoadData();
                clear();
            }
        }

        private void Course_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ID = txtCourseId.Text;
            CName = txtCourseName.Text;
            Duration = txtTime.Text;
            Fees = txtFee.Text;
            TID = txtTecherId.Text;

            string sqlqry = "SELECT* FROM Course WHERE CourseId='" + ID + "'";
            cmd = new SqlCommand(sqlqry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CName = dr["Course"].ToString();
                Duration = dr["Time"].ToString();
                Fees = dr["Fees"].ToString();
                TID = dr["TeacherId"].ToString();
            }
            txtCourseName.Text = CName;
            txtTime.Text = Duration;
            txtFee.Text = Fees;
            txtTecherId.Text = TID;

            con.Close();
            LoadData();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ID = txtCourseId.Text;
                CName = txtCourseName.Text;
                Duration = txtTime.Text;
                Fees = txtFee.Text;
                TID = txtTecherId.Text;

                string sqlqry = "UPDATE Course SET CourseId='" + ID +
                    "',Course='" + CName +
                    "',Time='" + Duration +
                    "',Fees='" + Fees +
                    "',TeacherId='" + TID +
                    "'WHERE CourseId='" + ID + "'";
                cmd = new SqlCommand(sqlqry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully..!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            finally
            {
                con.Close();
                LoadData();
                clear();

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ID = txtCourseId.Text;

            DialogResult rs = MessageBox.Show("Are You Sure?",
               "Warning",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    String sqlqry = "DELETE FROM Course WHERE CourseId='" + ID + "'";
                    con.Open();
                    cmd = new SqlCommand(sqlqry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Delected");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("ex.Message");
                }
                finally
                {
                    con.Close();
                    LoadData();
                    clear();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }
    }
}
