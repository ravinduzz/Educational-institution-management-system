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
    public partial class frmSearchResult : Form
    {
        public frmSearchResult()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Have you any Other managemnt users????", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                frmUsers us = new frmUsers();
                us.Show();
                this.Hide();
            }
            else {
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }

            
        }

        private void frmSearchResult_Load(object sender, EventArgs e)
        {
            txtId.Text = frmUsers.ID;
            txtName.Text = frmUsers.Uname;
            txtType.Text = frmUsers.Type;
        }
    }
}
