using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class MonthSubscriptionModel : SubscriptionModel<MonthOfferModel>
    {
        private int remainFrezeDay;
        MonthOfferModel monthOffer;
        public MonthSubscriptionModel(int id = 0, int numOfAttend = 0, DateTime startDate = default, DateTime endDate = default, MemberModel member = null, EmployeeModel employee = null, int remainFrezeDay = 0, MonthOfferModel monthOffer = null) : base(id,numOfAttend,startDate,endDate,member,employee)
        { 
            RemainFrezeDay = remainFrezeDay;
            MonthOffer = monthOffer;
        }

        public int RemainFrezeDay { get { return remainFrezeDay; } set { remainFrezeDay = value; } }
        public MonthOfferModel MonthOffer { get {  return monthOffer; } set {  monthOffer = value; } }

        public override MonthOfferModel getDataOfTybeOfSubscription()
        {
            return monthOffer;
        }
    }
}
