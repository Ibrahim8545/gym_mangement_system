using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Models
{
    public abstract class PersonModel
    {
        protected int id, age;
        protected string firstName, secondName, gender, email, phoneNumber, base64Image;
        protected DateTime brithday;
        protected Image picture;
        public PersonModel(int id = 0, string firstName = null, string secondName = null, string gender = null, string email = null, string phoneNumber = null, DateTime brithday = default, Image picture = null, string base64Image = null)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Brithday = brithday;
            Picture = picture;
            Base64Image = base64Image;
        }
        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string SecondName { get { return secondName; } set { secondName = value; } }
        public string Name { get { return (firstName + " " + secondName); } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public DateTime Brithday { get { return brithday; } set { brithday = value; } }
        public Image Picture { get { return picture; } set { picture = value; } }
        public string Base64Image { get { return base64Image; } set { base64Image = value; } }
        public int Age { get { try { return CalculateAge(); } catch { Console.WriteLine("Error! to get age"); return 0; } } }
        private int CalculateAge()
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - Brithday.Year;
            if (Brithday.Date > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
        public abstract int generateId();
    }
}
