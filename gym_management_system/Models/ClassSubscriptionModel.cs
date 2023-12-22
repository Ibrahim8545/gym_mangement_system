    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace gym_management_system.Models
    {
        public class ClassSubscriptionModel : SubscriptionModel<ClassModel>
        {
            private ClassModel classModel;

            public ClassSubscriptionModel(int id = 0, int numOfAttend = 0, DateTime startDate = default,DateTime endDate = default, MemberModel member = null, EmployeeModel employee = null, ClassModel classModel = null) : base(id, numOfAttend, startDate, endDate, member, employee)
            {
                ClassModel = classModel;

            }
            public ClassModel ClassModel { get { return classModel; } set { classModel = value; } }
            public override ClassModel getDataOfTybeOfSubscription()
            {
                return classModel;
            }
        }
    }
