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
    public partial class Fee : Form
    {
        SqlConnection mk = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String sqlqry = "";
        String regNo, Course, FullFee, Paid, Balance, NewPay;
        int balances;

        public Fee()
        {
            InitializeComponent();
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Fee_Load(object sender, EventArgs e)
        {
            txtRegNo.Focus();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try 
            {
                regNo = txtRegNo.Text;
                Course = "";

                string sqlqry = "SELECT * FROM StudentDetails WHERE RegNo='" + regNo + "'";
                cmd = new SqlCommand(sqlqry, mk);
                mk.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Course = dr["Course"].ToString();
                }
                txtCourse.Text=Course;
                mk.Close();
                //dr.Close();

                sqlqry = "SELECT * FROM Course WHERE Course='" + Course + "'";
                cmd = new SqlCommand(sqlqry, mk);
                mk.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    FullFee = dr["Fees"].ToString();
                }
                txtFull.Text = FullFee;
                mk.Close();


                sqlqry = "SELECT * FROM Fee WHERE RegNo='" + regNo + "'";
                cmd = new SqlCommand(sqlqry, mk);
                mk.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                        txtPaid.Text = dr["Paid"].ToString();
                        txtBalace.Text = dr["Balance"].ToString(); 
                }
                if (txtPaid.Text == "") 
                {
                    txtPaid.Text = frmParents.Paid;
                }
                //if (txtBalace.Text == "")
                //{
                //    txtBalace.Text = int.Parse(FullFee) - int.Parse(txtPaid.Text);
                //}
                //if (txtBalace.Text == "") 
                //{
                //    txtBalace.Text=
                //}

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                mk.Close();

            }
            //balances = txtBalance.Text;
            //balances = int.Parse(txtFull.Text)-int.Parse(txtPaid.Text);
            //txtBalace.Text = balances.ToString();
            #region
            //try
            //{
            //    FullFee = txtFull.Text;
            //    sqlqry = "SELECT* FROM Course WHERE Course='" + Course + "'";
            //    cmd = new SqlCommand(sqlqry, mk);
            //    mk.Open();
            //    SqlDataReader dt = cmd.ExecuteReader();

            //    while (dt.Read())
            //    {
            //        FullFee = dt["fees"].ToString();

            //    }
            //    txtFull.Text = FullFee;


            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.ToString());
            //}
            //finally
            //{
            //    mk.Close();

            //}
            #endregion

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int paidAmount = int.Parse(txtPay.Text);
            int totalPaid = int.Parse(txtPaid.Text) + paidAmount;

            int balance = int.Parse(txtFull.Text) - totalPaid;
            txtBalace.Text = balance.ToString();
            //MessageBox.Show(paidAmount + " " + totalPaid + " " + balance);

            #region

            //regNo = txtRegNo.Text;

                //string sqlqry = "SELECT* FROM Fee WHERE RegNo='" + regNo + "'";
                //cmd = new SqlCommand(sqlqry, mk);
                //mk.Open();
                //SqlDataReader dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    regNo = dr["RegNo"].ToString();

                //}

                //if (regNo == "") 
                //{
                //    sqlqry = "INSERT INTO Fee VALUES('"+regNo+"','"+FullFee+"','"+paidAmount+"','"+balance+"')";
                //    cmd = new SqlCommand(sqlqry, mk);
                //    mk.Open();
                //    cmd.ExecuteNonQuery();
                //    mk.Close();

                //}
                //else
                //{
#endregion
                sqlqry = "UPDATE Fee SET RegNo='" + regNo +
                    "',Fullfee='" + FullFee +
                    "',Paid='" + totalPaid +
                    "',Balance='" + balance +
                    "'WHERE RegNo='" + regNo + "'";
                cmd = new SqlCommand(sqlqry, mk);
                mk.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Paid Successfully..!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mk.Close();
            #region
            //    }

                //}
                //catch (Exception er)
                //{
                //    MessageBox.Show(er.ToString());
                //}
                //finally
                //{
                //    mk.Close();


            //}
            #endregion

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

                txtRegNo.Clear();
                txtPay.Clear();
                txtCourse.Clear();
                txtBalace.Clear();
                txtFull.Clear();
                txtPaid.Clear();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Skills International school",new Font("Arial",32,FontStyle.Underline),Brushes.Black,new Point(10,10));
        }

        private void txtRegNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheck_Click(sender, e);
            }
        }

        private void txtPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
