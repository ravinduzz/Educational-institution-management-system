using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsoftLastProject
{
    public partial class frmMain : Form
    {
        public static String RegNo;
        public frmMain()
        {
            InitializeComponent();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            if(MessageBox.Show("Are You Sure???", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes){
                this.Close();
            }
            
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            //lblName.Text = "Hi "+frmLogins.name;
            lblType.Text = frmLogins.Type;

            if (lblType.Text == "User")
            {
                btnMUsers.Enabled = false;
            }
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent stu = new frmStudent();
            stu.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //private void managementUsersToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //   frmUsers user = new frmUsers();
         //   user.Show();
         //   this.Hide();
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmStudent stu = new frmStudent();
            stu.Show();
            this.Hide();
        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void btnMUsers_Click(object sender, EventArgs e)
        {
            frmUsers us = new frmUsers();
            us.Show();
            this.Hide();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            RegNo = txtRegNo.Text;
            frmStuDe stuw = new frmStuDe();
            stuw.Show();
            this.Hide();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            Fee fee = new Fee();
            this.Hide();
            fee.Show();
        }

        private void btnTReg_Click(object sender, EventArgs e)
        {
            TecherReg tech = new TecherReg();
            tech.Show();
            this.Hide();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            Course courses = new Course();
            courses.Show();
            this.Hide();
        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegNo_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyCode == Keys.Enter)
                btnSubmit_Click(sender, e);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogins log = new frmLogins();
            log.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        }
    }
