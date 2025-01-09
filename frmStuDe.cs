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
    public partial class frmStuDe : Form
    {
        public frmStuDe()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String qry,name,Address,nic;


        private void frmStuDe_Load(object sender, EventArgs e)
        {
            #region
            //txtAddress.Visible = false;
            //txtCourse.Visible = false;
            //txtDate.Visible = false;
            //txtDob.Visible = false;
            //txtName.Visible = false;
            //txtNic1.Visible = false;
            //txtSchool.Visible = false;
            //txtTutorsName.Visible = false;
            //txtTutorNic.Visible = false;
            //txtPayment.Visible = false;
            #endregion

            
            txtRegNo1.Text = frmMain.RegNo;
            qry = "SELECT * FROM StudentDetails WHERE RegNo='" + txtRegNo1.Text + "'";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtName.Text = dr["FullName"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtSchool.Text = dr["School"].ToString();
                txtDob.Text = dr["BirthOfDate"].ToString();
                txtNic1.Text = dr["NICNo"].ToString();
                txtDate.Text = dr["Date"].ToString();
                txtCourse.Text = dr["Course"].ToString();
                
            }
            dr.Close();
            con.Close();

            qry = "SELECT * FROM parent WHERE RegNo='" + txtRegNo1.Text + "'";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtTutorsName.Text = dr["TutorName"].ToString();
                txtTutorMobile.Text = dr["MobileNo"].ToString();

            }
            dr.Close();
            con.Close();



            qry = "SELECT * FROM Fee WHERE RegNo='" + txtRegNo1.Text + "'";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtPayment.Text = dr["Paid"].ToString();
                txtBalance1.Text = dr["Balance"].ToString();

            }
            dr.Close();
            con.Close();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region
            //txtAddress.Visible = true;
            //txtCourse.Visible = true;
            //txtDate.Visible = true;
            //txtDob.Visible = true;
            //txtName.Visible = true;
            //txtNic1.Visible = true;
            //txtSchool.Visible = true;
            //txtTutorsName.Visible = true;
            //txtTutorNic.Visible = true;
            //txtPayment.Visible = true;
            #endregion
            
      
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBalance1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if()
            //{

            //}
        }

        private void txtRegNo1_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyCode == Keys.Enter){
                btnCancel_Click(sender, e);
        }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}
