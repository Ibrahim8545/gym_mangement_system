using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class EmployeeModel : PersonModel
    {
        private static EmployeeModel instance;
        private string username, password;
        private bool admin, accountStatus;

        public EmployeeModel(int id = 0, string firstName = null, string secondName = null, string username = null, string password = null, string gender = null, string email = null, string phoneNumber = null, bool admin = false, bool accountStatus = false, DateTime brithday = default, Image picture = null) : base(id: id, firstName: firstName, secondName: secondName, gender: gender, email: email, phoneNumber: phoneNumber, brithday: brithday, picture: picture)
        {
            Username = username;
            Password = password;
            Admin = admin;
            AccountStatus = accountStatus;
        }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public bool Admin { get { return admin; } set { admin = value; } }
        public bool AccountStatus { get { return accountStatus; } set { accountStatus = value; } }

        public static EmployeeModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeModel();
                }
                return instance;
            }
        }

        public override int generateId()
        {
            int id;
            double currentYear = DateTime.Now.Year;
            currentYear = (((currentYear % 100) / 100.0) + 1) * 1000000;
            int y = (int)currentYear;
            int last_id = Global.employeeService.getLastId();
            if (last_id == -1)
            {
                return -1;
            }
            if (last_id == 0 || (last_id / 1000000) != (y / 1000000))
            {
                id = ++y;
            }
            else
            {
                id = last_id + 1;
            }
            this.id = id;
            return id;
        }

    }
}
