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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String qry="";
        public static string fname, school, address, dob, nic, date, course, mobile,RegNo;


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dta = new SqlDataAdapter("select isnull(max(cast(RegNo as int)),0)+1 from StudentDetails",con);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            txtRegNo.Text=dt.Rows[0][0].ToString();
            this.ActiveControl = txtName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            fname = txtName.Text;
            school = txtSchool.Text;
            address = txtAddress.Text;
            dob = dtpDOB.Text;
            nic = txtNic.Text;
            date = dtpDate.Text;
            course = chbCourse.Text;
            RegNo = txtRegNo.Text;

            if (fname == "" || school == "" || address == "" || dob == "" || nic == "" || date == "" || course == "" || RegNo == "")
            {
                MessageBox.Show("Data Submited UnSuccessfully...Please Insert All Data In The Form....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                fname = txtName.Text;
                school = txtSchool.Text;
                address = txtAddress.Text;
                dob = dtpDOB.Text;
                nic = txtNic.Text;
                date = dtpDate.Text;
                course = chbCourse.Text;
                RegNo = txtRegNo.Text;

                try
                {
                    qry = "INSERT INTO StudentDetails VALUES('" + RegNo + "','" + fname + "','" + address + "','" + school + "','" + dob + "','" + nic + "','" + date + "','" + course + "');";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    frmParents pera = new frmParents();
                    pera.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();

                }

            }
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {  
            
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
