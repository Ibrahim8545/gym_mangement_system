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

        public EmployeeModel EmployeeModel1 { get { return employeeModel1; } set { employeeModel1 = value; PersonModel = employeeModel; } }
        
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

        public string createEmployeeEmail()
        {
            body = $"Hi {employeeModel1.Name}\n\n" +
                $"Welcome to the PulseUp Gym team! We are excited to have you on board as a new member of our staff. Your dedication and expertise will undoubtedly contribute to the success of our gym.\n\n" +
                $"Here are the details of your employee profile:\n\n"+
                $"ID: {employeeModel1.Id}]\n"+
                $"Name: {employeeModel1.Name}\n"+
                $"Username: {employeeModel1.Username}\n"+
                $"Password: {employeeModel1.Password}\n" +
                $"Email: {employeeModel1.Email}\n" +
                $"Phone: {employeeModel1.PhoneNumber}\n\n"+
                $"Contact Information:\n"+
                $"Phone: 01xxxxxxxxxx\n"+
                $"Email: pulseupgym@gmail.com\n\n"+
                $"We are thrilled to have you join the PulseUp Gym family and look forward to working together to provide an exceptional experience for our members.\n\nBest regards,\nPulseUp Gym";
            return body;
        }

        public string updateEmployeeEmail(EmployeeModel updatedEmployee)
        {
            body = $"Hi {updatedEmployee.Name}\n\n" +
                $"We hope this message finds you well. This is to inform you that your employee information has been updated in our system. Thank you for keeping your details current.\n\n" +
                $"Here are the updated details of your employee profile:\n\n" +
                $"ID: {updatedEmployee.Id}\n" +
                $"Name: {updatedEmployee.Name}\n" +
                $"Username: {updatedEmployee.Username}\n" +
                $"Email: {updatedEmployee.Email}\n" +
                $"Phone: {updatedEmployee.PhoneNumber}\n\n" +
                $"Contact Information:\n" +
                $"Phone: 01xxxxxxxxxx\n" +
                $"Email: pulseupgym@gmail.com\n\n" +
                $"If you have any questions or notice any discrepancies, please contact our HR department at hr@pulseupgym.com.\n\n" +
                $"Thank you for being a valuable member of the PulseUp Gym team!\n\nBest regards,\nPulseUp Gym";
            return body;
        }

        public string sendMessageToEmployee(EmployeeModel employee, string message)
        {
            body = $"Hi {employee.Name}\n\n" +
                $"We hope this message finds you well. +{message}\n\n" +
                $"Here are some details related to your profile:\n\n" +
                $"ID: {employee.Id}\n" +
                $"Name: {employee.Name}\n" +
                $"Username: {employee.Username}\n" +
                $"Email: {employee.Email}\n" +
                $"Phone: {employee.PhoneNumber}\n\n" +
                $"If you have any questions or concerns, please don't hesitate to reach out to us. Your contributions are integral to the success of our gym, and we are grateful to have you on our team.\n\n" +
                $"Thank you for your continued efforts!\n\nBest regards,\nPulseUp Gym";
            return body;
        }
    }
}
