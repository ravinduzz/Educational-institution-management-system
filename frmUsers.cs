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
    public partial class frmUsers : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        public static string ID, Uname, Type;

        public void LoadData()
        {
            con.Open();
            String sqlqry = "SELECT * FROM Logins";
            SqlDataAdapter da = new SqlDataAdapter(sqlqry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Logins");
            dgvUserd.DataSource = ds.Tables["Logins"].DefaultView;
            con.Close();
        }

        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
        }

        private void dgvUserd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ID = txtID.Text;
            String uname = txtuname.Text;
            String password = txtPasswords.Text;
            String type = cmbType.Text;

            string sqlqry = "INSERT INTO Logins VALUES('" + ID + "','" + uname + "','" + password + "','" + type + "');";

            cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfuly...!", "Success!!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            con.Close();
            LoadData();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                ID = txtID.Text;
                String uname = txtuname.Text;
                String password = txtPasswords.Text;
                String type = cmbType.Text;
   

                

                string sqlqry = "UPDATE Logins SET ID='" + ID +
                    "',UserName='" + uname +
                    "',Password='" + password +
                    "',Type='" + type +
                    "'WHERE ID='" + ID + "'";
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

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are You Sure?",
               "Warning",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    String sqlqry = "DELETE FROM Logins WHERE ID='" + txtID.Text + "'";
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
                }
            }
        }

        private void btnSearchtr_Click(object sender, EventArgs e)
        {
            try
            {
                ID = txtID.Text;
                String uname = txtuname.Text;
                String password = txtPasswords.Text;
                String type = cmbType.Text;


                string sqlqry = "SELECT* FROM Logins WHERE ID='" + ID + "'";
                cmd = new SqlCommand(sqlqry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    uname = dr["UserName"].ToString();
                    type = dr["Type"].ToString();
                    password = dr["Password"].ToString();

                }
                txtuname.Text = uname;
                txtPasswords.Text = password;
                cmbType.Text = type;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }
    }
}
