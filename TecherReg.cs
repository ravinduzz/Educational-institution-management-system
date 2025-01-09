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
    public partial class TecherReg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        String uname, Age, ID;


        public void LoadData()
        {
            con.Open();
            String sqlqry = "SELECT * FROM Teachers";
            SqlDataAdapter da = new SqlDataAdapter(sqlqry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Teachers");
            dgvTeacher.DataSource = ds.Tables["Teachers"].DefaultView;
            con.Close();
        }
        public void clear() 
        {
            txtID.Clear();
            txtAge.Clear();
            txtuname.Clear();
        }
        public TecherReg()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ID = txtID.Text;
            uname = txtuname.Text;
            Age = txtAge.Text;

            string sqlqry = "INSERT INTO Teachers VALUES('" + ID + "','" + uname + "','" + Age + "');";
            cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfuly...!", "Success!!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            con.Close();
            LoadData();
            clear();
        }

        private void btnSearchtr_Click(object sender, EventArgs e)
        {
            try
            {
                ID = txtID.Text;
                uname = txtuname.Text;
                Age = txtAge.Text;

                string sqlqry = "SELECT* FROM Teachers WHERE TeacherId='" + ID + "'";
                cmd = new SqlCommand(sqlqry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    uname = dr["Name"].ToString();
                    Age = dr["Age"].ToString();
                }
                txtuname.Text = uname;
                txtAge.Text = Age;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ID = txtID.Text;
                uname = txtuname.Text;
                Age = txtAge.Text;
                
                string sqlqry = "UPDATE Teachers SET TeacherId='" + ID +
                    "',Name='" + uname +
                    "',Age='" + Age +
                    "'WHERE TeacherId='" + ID + "'";
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
            DialogResult rs = MessageBox.Show("Are You Sure?",
              "Warning",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    ID = txtID.Text;
                    uname = txtuname.Text;
                    Age = txtAge.Text;

                    String sqlqry = "DELETE FROM Teachers WHERE TeacherId='" + ID + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void TecherReg_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
