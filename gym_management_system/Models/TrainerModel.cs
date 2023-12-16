using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class TrainerModel : PersonModel
    {
        private string specialization;
        private int privateLessonPrice;

        public TrainerModel(int id = 0, string firstName = null, string secondName = null, string gender = null, string email = null, string phoneNumber = null, DateTime brithday = default, Image picture = null, string specialization = null, int privateLessonPrice = 0) : base(id: id, firstName: firstName, secondName: secondName, gender: gender, email: email, phoneNumber: phoneNumber, brithday: brithday, picture: picture)
        { 
            Specialization = specialization;
            PrivateLessonPrice = privateLessonPrice;
        }

        public string Specialization { get { return specialization; } set { specialization = value; } }
        public int PrivateLessonPrice { get { return privateLessonPrice; } set { privateLessonPrice = value; } }
        
        public override int generateId()
        {
            int id;
            double currentYear = DateTime.Now.Year;
            currentYear = (((currentYear % 100) / 100.0) + 3) * 1000000;
            int y = (int)currentYear;
            int last_id = 0;
            if (last_id == -1)
            {
                return -1;
            }
            if (last_id == 0 || (last_id / 1000000) != (y / 1000000))
            {
                id = ++y;
            }
            else
            {
                id = last_id + 1;
            }
            this.id = id;
            return id;
        }
    }
}
