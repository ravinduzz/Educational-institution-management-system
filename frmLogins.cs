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
    public partial class frmLogins : Form
    {
        SqlConnection mk = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String qry = "";
        public static String Password,Type,name,id;

        public frmLogins()
        {
            InitializeComponent();
        }

        private void frmLogins_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnLoGinD_Click(object sender, EventArgs e)
        {
            try
            {
                
                qry = "SELECT * FROM Logins WHERE UserName='" + txtName.Text + "'AND Password='" + txtPassword.Text + "'";
                cmd = new SqlCommand(qry, mk);
                mk.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id=(dr["ID"].ToString());
                    name = (dr["UserName"].ToString());
                    Type = (dr["Type"].ToString());
                    Password = (dr["Password"].ToString());
                }

                if (name == txtName.Text && Password == txtPassword.Text)
                {
                    frmMain main = new frmMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    if (MessageBox.Show("Invalied Name Or Password", "Error", MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        frmLogins log = new frmLogins();
                        log.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                mk.Close();
            }
        }

        private void btnCANCel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogins_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLoGinD_Click(sender, e);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
