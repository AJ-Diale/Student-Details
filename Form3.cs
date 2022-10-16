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
    public partial class frmRegistraton : Form
    {
        List<User> listuse = new List<User>();
        Filehandler fh = new Filehandler();
        public frmRegistraton()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "" && txtConfirm.Text == txtPassword.Text)
            {
                string name = txtUsername.Text;
                string password = txtPassword.Text;

                User newuser = new User(name, password);

                listuse.Add(newuser);
                fh.Writer(listuse);
                MessageBox.Show("User registered");
            }
            else
            {
                if (txtConfirm.Text != txtPassword.Text)
                {
                    MessageBox.Show("Passwords do not match");

                    txtConfirm.Clear();
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields");
                }
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            log.Show();
            this.Hide();
        }
    }
}
