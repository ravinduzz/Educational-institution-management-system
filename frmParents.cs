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
    public partial class frmParents : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ORQ0RRK\SQLEXPRESS;Initial Catalog=Esoft;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String qry;
        String Tname, Taddress, Tnic, Tmobile, Course, FullFee;
        String RegNo;
        int Balances, FullFeess, Paidss;
        public static String Paid,Balance;

        public frmParents()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Tname = txtTutorsName.Text;
            Taddress = txtTutorAddress.Text;
            Tnic = txtTutorNic.Text;
            Tmobile = txtTutorMobile.Text;
            RegNo = txtRegNo.Text;
            

            try {

                if (Tname == "" || Taddress == "" || Tnic == "" || Tmobile == "")
                {
                    MessageBox.Show("Data Submited UnSuccessfully...Please Insert All Data In The Form....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                     Paid = txtPayment.Text;
                     Course = frmStudent.course;

                     qry = "SELECT * FROM Course WHERE Course='" + Course + "'";
                     cmd = new SqlCommand(qry, con);
                     con.Open();
                     dr = cmd.ExecuteReader();

                     while (dr.Read())
                     {
                         FullFee = dr["Fees"].ToString();
                     }
                     dr.Close();
                     con.Close();

                     Balances = int.Parse(FullFee) - int.Parse(Paid);
                     Balance = Balances.ToString();

                     qry = "INSERT INTO Fee VALUES('" + RegNo + "','" + FullFee + "','" + Paid + "','" + Balance + "');";
                     cmd = new SqlCommand(qry, con);
                     con.Open();
                     cmd.ExecuteNonQuery();
                     con.Close();

                    #region
                    //try
                    //{
                    //    int Paid = int.Parse(txtPayment.Text);
                        
                    //    qry = "INSERT INTO Fee VALUES('" + RegNo + "','" + FullFee + "','" + Paid + "','"+balance+"')";
                    //    cmd = new SqlCommand(qry, con);
                    //    con.Open();
                    //    cmd.ExecuteNonQuery();

                    //}
                    //catch (Exception Ex)
                    //{
                    //    MessageBox.Show("this.................."+Ex.ToString());
                    //}
                    //finally
                    //{
                    //    dr.Close();
                    //    con.Close();

                    //}
                    #endregion

                    qry = "INSERT INTO parent VALUES('" + Tname + "','" + Taddress + "','" + Tnic + "','" + Tmobile + "','" + RegNo + "');";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (MessageBox.Show("Have You Any Other Student Registration????", "Other Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmStudent stu = new frmStudent();
                        this.Hide();
                        stu.Show();
                    }
                    else
                    {
                        frmMain main = new frmMain();
                        main.Show();
                        this.Hide();
                    }
                }
          
            
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
                con.Close();
                if (Tname == "" || Taddress == "" || Tnic == "" || Tmobile == "")
                {
                    this.Hide();
                    frmParents fp = new frmParents();
                    fp.Show();

                }
                //else {

                //    frmMain main = new frmMain();
                //    main.Show();
                //    this.Hide();

                //}
            }

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void frmParents_Load(object sender, EventArgs e)
        {
            txtRegNo.Text = frmStudent.RegNo.ToString();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //frmStudent stu = new frmStudent();
            //this.Hide();
            //stu.Show();
        }
    }
}
