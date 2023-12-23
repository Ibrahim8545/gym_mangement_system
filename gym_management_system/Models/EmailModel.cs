using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public abstract class EmailModel
    {
        protected int id;
        protected string subject;
        protected string body;
        protected DateTime date;
        protected EmployeeModel employeeModel;
        protected PersonModel personModel;

        protected EmailModel(int id = 0, string subject = null, DateTime date = default, EmployeeModel employeeModel = null, PersonModel personModel = null) { 
            Id = id;
            Subject = subject;
            Date = date;
            EmployeeModel = employeeModel;
            PersonModel = personModel;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Subject { get { return subject; } set { subject = value; } }
        public string Body { get { return body; } set { body = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public EmployeeModel EmployeeModel { get { return employeeModel; } set { employeeModel = value; } }
        public PersonModel PersonModel { get { return personModel; } set {  personModel = value; } }

        public EmployeeModel getEmployeeData()
        {
            List<EmployeeModel> employeeModels = Global.employeeService.Search(employeeModel.Id.ToString(), false, byId: false);
            if (employeeModels != null)
            {
                employeeModel = employeeModels[0];
                return employeeModel;
            }
            else
            {
                Console.WriteLine("Error getting from getEmployeeData in Email Model: no employee found");
                return null;
            }
        }

        public abstract PersonModel getreciverData();
    }
}
