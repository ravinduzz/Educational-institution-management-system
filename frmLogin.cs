using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EsoftLastProject
{
    public partial class frmLogin : Form
    {
        SqlConnection con=new SqlConnection(@"Data Source=LAPTOP-UNSBE5AJ\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String qry="";
        String Password,Type,Uname;
        
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            try
            {
                this.ActiveControl = txtName;
                qry = "SELECT * FROM User WHERE Name='" + txtName.Text + "' AND Password='" + txtPassword.Text + "'";
                con.Open();
                cmd = new SqlCommand(qry,con);
                dr =cmd.ExecuteReader();

                while (dr.Read())
                {
                    Uname = (dr["Name"].ToString());
                    Type = (dr["Type"].ToString());
                    Password = (dr["Password"].ToString());
                }

                if (Uname == txtName.Text && Password == txtPassword.Text)
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
                        frmLogin log = new frmLogin();
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
                con.Close();
            }
        }

        private void btmCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
