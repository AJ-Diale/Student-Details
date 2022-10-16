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
    public partial class frmMain : Form
    {
        int ID = 0;
        DataHandler handler = new DataHandler();
        BindingSource bindingSource = new BindingSource();
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            handler.SqlInsert(txtName.Text, txtModuleLinks.Text, txtModuleName.Text,txtModuleDescription.Text,txtPhone.Text, txtAddress.Text, txtGender.Text, txtSurname.Text, DateTime.Parse(dtpDOB.Text),txtModuleCode.Text);
            MessageBox.Show("Inserted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            handler.Sqlupdate(txtName.Text, txtModuleLinks.Text, txtModuleName.Text, txtModuleDescription.Text, txtPhone.Text, txtAddress.Text, txtGender.Text, txtSurname.Text, DateTime.Parse(dtpDOB.Text), txtModuleCode.Text); // Edit here
            MessageBox.Show("Information updated");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = handler.SQLsearch(txtName.Text,txtSurname.Text); 
            dgvDisplay.DataSource = bindingSource;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            handler.SQLdelete(txtName.Text,txtSurname.Text);
            MessageBox.Show("Deleted");
        }

        private void dgStudents_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView dr = bindingSource.Current as DataRowView; 

            DataRow selectStudent = dr.Row; 
            if (selectStudent != null)

                txtName.Text = selectStudent["Name"].ToString();
                txtSurname.Text = selectStudent["Surname"].ToString();
                txtModuleCode.Text = selectStudent["ModuleCode"].ToString();
        }
    }
}
