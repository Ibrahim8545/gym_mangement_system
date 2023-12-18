using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class EmployeeEmailModel : EmailModel
    {
        private EmployeeModel employeeModel1;

        public EmployeeEmailModel(int id = 0, string subject = null, DateTime date = default, EmployeeModel employeeModel1 = null, EmployeeModel employeeModel = null) : base(id, subject, date, employeeModel)
        {
            EmployeeModel = employeeModel1;
        }

        public EmployeeModel EmployeeModel1 { get { return employeeModel1; } set { employeeModel1 = value; } }

        public override PersonModel getreciverData()
        {
            List<EmployeeModel> employeeModels = Global.employeeService.Search(employeeModel1.Id.ToString(), false, byId: false);
            if (employeeModels != null)
            {
                employeeModel1 = employeeModels[0];
                return employeeModel1;
            }
            else
            {
                Console.WriteLine("Error getting from getReciverData in EmployeeEmail Model: no employee found");
                return null;
            }
        }
    }
}
