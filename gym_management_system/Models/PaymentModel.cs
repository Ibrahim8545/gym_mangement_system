using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class PaymentModel
    {
        private int id, amount;
        private string name;
        private DateTime date;
        private MemberModel member;
        private EmployeeModel employee;
        public PaymentModel(int id = 0, string name = null, int amount = 0, DateTime date = default, MemberModel member = null, EmployeeModel employee = null)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Date = date;
            Member = member;
            Employee = employee;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Amount { get { return amount; } set { amount = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public MemberModel Member { get { return member; } set { member = value; } }
        public EmployeeModel Employee { get { return employee; } set { employee = value; } }
    }
}
