using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class MemberEmailModel
    {
        private int id;
        private string subject;
        DateTime date;
        MemberModel memberModel;
        EmployeeModel employeeModel;

        public MemberEmailModel(int id = 0, string subject = null, DateTime date = default, MemberModel memberModel = null, EmployeeModel employeeModel = null)
        {
            Id = id;
            Subject = subject;
            Date = date;
            MemberModel = memberModel;
            EmployeeModel = employeeModel;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Subject { get { return subject; } set { subject = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public MemberModel MemberModel { get {  return memberModel; } set {  memberModel = value; } }
        public EmployeeModel EmployeeModel { get { return employeeModel; } set {  employeeModel = value; } }
    }
}
