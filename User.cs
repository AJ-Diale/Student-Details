using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForms
{
    class User
    {
        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public User()
        {

        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public override string ToString()
        {
            return string.Format("{0},{1}", username, password);
        }
        public List<User> CheckUser()
        {
            List<User> usercheck = new List<User>();
            Filehandler fh = new Filehandler();
            List<string> person = fh.ReadData("Users");

            foreach (string item in person)
            {
                string[] data = item.Split(',');
                usercheck.Add(new User(data[0], data[1]));
            }

            return usercheck;
        }

    }
}
