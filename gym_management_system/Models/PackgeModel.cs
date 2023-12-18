using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class PackgeModel
    {
        private int id, numOfClass, numOfInvatation, discountPercentage;
        private string name, status;
        private MonthOfferModel monthOffer;

        public PackgeModel(int id = 0, int numOfClass = 0, int numOfInvatation = 0, int discountPercentage = 0, string name = null, string status = null, MonthOfferModel monthOffer = null)
        {
            Id = id;
            NumOfClass = numOfClass;
            NumOfInvatation = numOfInvatation;
            Name = name;
            Status = status;
            MonthOffer = monthOffer;
        }

        public int Id { get => id; set => id = value; }
        public int NumOfClass { get => numOfClass; set => numOfClass = value; }
        public int NumOfInvatation { get => numOfInvatation; set => numOfInvatation = value; }
        public int DiscountPercentage { get => discountPercentage; set => discountPercentage = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public MonthOfferModel MonthOffer { get => monthOffer; set => monthOffer = value; }
    }
}
