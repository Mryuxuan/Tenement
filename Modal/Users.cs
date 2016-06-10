using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modal
{
    public class Users
    {
        int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        int roleId;

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}