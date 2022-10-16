using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppForms
{
    public partial class frmLogin : Form
    {
        List<User> person = new List<User>();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterHere_Click(object sender, EventArgs e)
        {
            frmRegistraton register = new frmRegistraton();
            register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<User> useritem = new List<User>();

            string Name = txtUsern.Text;
            string Password = txtPassw.Text;
            bool isValid = false;

            User user = new User();
            useritem = user.CheckUser();
            foreach (User item in useritem)
            {
                if (item.UserName == Name && item.Password == Password)
                {
                    isValid = true;
                }
            }
            if (isValid)
            {
                frmMain home = new frmMain();
                this.Hide();
                home.Show();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Login failed. Username or password invalid.");
                if (dr == DialogResult.Retry)
                {
                    txtUsern.Clear();
                    txtPassw.Clear();
                    txtUsern.Focus();
                }
            }
        }
    }
}
