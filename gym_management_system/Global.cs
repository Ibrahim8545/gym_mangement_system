using gym_management_system.Manger;
using gym_management_system.Models;
using gym_management_system.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system
{
    public static class Global
    {
        public static SqlService sqlService = new SqlService();
        public static EmployeeService employeeService = new EmployeeService();
        public static MemberService memberService = new MemberService();
        public static TrainerService trainerService = new TrainerService();
        public static ClassService classService = new ClassService();
        public static EmployeeModel employeeModel = EmployeeModel.Instance;
        public static MangePassword mangePassword = new MangePassword();
        public static MangeImage mangeImage = new MangeImage();
    }
}
