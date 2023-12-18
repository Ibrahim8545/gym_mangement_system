using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public abstract class SubscriptionModel<T>
    {
        protected int id, numOfAttend;
        protected DateTime startDate, endDate;
        protected MemberModel member;
        protected EmployeeModel employee;

        protected SubscriptionModel(int id = 0, int numOfAttend = 0, DateTime startDate = default, DateTime endDate = default, MemberModel member = null, EmployeeModel employee = null) 
        { 
            Id = id;
            NumberOfAttend = numOfAttend;
            StartDate = startDate;
            EndDate = endDate;
            Member = member;
            Employee = employee;
        }

        public int Id { get { return id; } set { id = value; } }
        public int NumberOfAttend { get { return numOfAttend; } set { numOfAttend = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public MemberModel Member { get { return member; } set { member = value; } }
        public EmployeeModel Employee { get {  return employee; } set {  employee = value; } }

        public EmployeeModel getEmployeeDate()
        {
            List<EmployeeModel> employeeModels = Global.employeeService.Search(employee.Id.ToString(), false, byId: false);
            if (employeeModels != null)
            {
                employee = employeeModels[0];
                return employee;
            }
            else
            {
                Console.WriteLine("Error getting from getEmployeeDate in Subscription Model: no employee found");
                return null;
            }
        }

        public MemberModel getMemberData()
        {
            List<MemberModel> memberModels = Global.memberService.Search(member.Id.ToString(), false, byId: false);
            if (memberModels != null)
            {
                member = memberModels[0];
                return member;
            }
            else
            {
                Console.WriteLine("Error getting from getMemberData in Subscription Model: no member found");
                return null;
            }
        }

        public abstract T getDataOfTybeOfSubscription();
    }
}
