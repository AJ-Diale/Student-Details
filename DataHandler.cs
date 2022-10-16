using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AppForms
{
    internal class DataHandler
    {
        static string connServer = @"Data Source=MALICIOUS_DUCK\SQLEXPRESS;Initial Catalog=StudentDetailsDb;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connServer);
        string sqlStatement;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public DataSet set = new DataSet();
        public DataTable data = new DataTable();

        //Display all 
        public DataTable dplyStudents()
        {
            SqlConnection sqlcon = new SqlConnection(connServer);
            SqlDataAdapter adapter = new SqlDataAdapter("Students", sqlcon);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        //Add data to database
        public void SqlInsert(string name, string moduleLink, string moduleName, string moduleDescript, string phoneNum, string address, string gender, string surname, DateTime dob, string moduleCode)
        {
            using (SqlConnection sqlcon = new SqlConnection(connServer))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@PhoneNum", phoneNum);
                cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
                cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                cmd.Parameters.AddWithValue("@ModuleDescript", moduleDescript);
                cmd.Parameters.AddWithValue("@ModuleLink", moduleLink);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Update data on database
        public void Sqlupdate(string name, string moduleLink, string moduleName, string moduleDescript, string phoneNum, string address, string gender, string surname, DateTime dob, string moduleCode)
        {
            using (SqlConnection sqlcon = new SqlConnection(connServer))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@PhoneNum", phoneNum);
                cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
                cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                cmd.Parameters.AddWithValue("@ModuleDescript", moduleDescript);
                cmd.Parameters.AddWithValue("@ModuleLink", moduleLink);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Delete data on database
        public void SQLdelete(string studentName, string studentSurname)
        {
            using (SqlConnection sqlcon = new SqlConnection(connServer))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", studentName);
                cmd.Parameters.AddWithValue("@Surname", studentSurname);

                sqlcon.Open();
                cmd.ExecuteNonQuery();
            }

        }

        //Search for data on database
        public DataTable SQLsearch(string studentName, string studentSurname)
        {
            using (SqlConnection sqlcon = new SqlConnection(connServer))
            {
                SqlCommand cmd = new SqlCommand("spSearchStudent", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", studentName);
                cmd.Parameters.AddWithValue("@Surname", studentSurname);

                sqlcon.Open();
                DataTable dt = new DataTable(); // Return this Datatable

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                    return dt;
                }
            }
        }

    
}
}
