using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class PrivateSubscriptionModel : SubscriptionModel<TrainerModel>
    {
        private int lessonsNum;
        private TrainerModel trainer;

        public PrivateSubscriptionModel(int id = 0, int numOfAttened = 0, int lessonsNum = 0, DateTime startDate = default, DateTime endDate = default, MemberModel member = null, EmployeeModel employee = null, TrainerModel trainer = null) : base(id, numOfAttened, startDate, endDate, member, employee)
        {

            LessonsNum = lessonsNum;
            Trainer = trainer;

        }
        public int LessonsNum { get { return lessonsNum; } set { lessonsNum = value; } }

        public TrainerModel Trainer { get { return trainer; } set { trainer = value; } }
        public override TrainerModel getDataOfTybeOfSubscription()
        {
            return trainer;
        }
    }
}
