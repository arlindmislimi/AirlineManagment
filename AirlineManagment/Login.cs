using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineManagment
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                Dashbord db = new Dashbord();
                db.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter Valid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
