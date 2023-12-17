using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class MonthOfferModel
    {
        private int id, maxNumFreze, numOfMonth, price;

        public MonthOfferModel(int id = 0, int maxNumFreze = 0, int numOfMonth = 0, int price = 0) 
        { 
            Id = id;
            MaxNumFreze = maxNumFreze;
            NumOfMonth = numOfMonth;
            Price = price;
        }

        public int Id { get { return id; } set {  id = value; } }
        public int MaxNumFreze { get {  return maxNumFreze; } set {  maxNumFreze = value; } }
        public int NumOfMonth { get { return numOfMonth; } set { numOfMonth = value; } }
        public int Price { get { return price; } set { price = value; } }
    }
}
