using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class ClassModel
    {
        private int id, enrollmentNumber, maxEnrollmentNumber, price;
        private string name, sessionOneDayName, sessionTwoDayName, status;
        private TrainerModel trainerModel;

        public ClassModel(int id = 0, int enrollmentNumber = 0, int maxEnrollmentNumber = 0, int price = 0, string name = null, string sessionOneDayName = null, string sessionTwoDayName = null, string status = null, TrainerModel trainerModel = null)
        {
            Id = id;
            EnrollmentNumber = enrollmentNumber;
            MaxEnrollmentNumber = maxEnrollmentNumber;
            Price = price;
            Name = name;
            SessionOneDayName = sessionOneDayName;
            SessionTwoDayName = sessionTwoDayName;
            Status = status;
            TrainerModel = trainerModel;
        }

        public int Id { get { return id; } set {  id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int EnrollmentNumber { get {  return enrollmentNumber; } set {  enrollmentNumber = value; } }
        public int MaxEnrollmentNumber { get { return maxEnrollmentNumber; } set {  maxEnrollmentNumber = value; } }
        public int Price { get { return price; } set { price = value; } }
        public string SessionOneDayName { get {  return sessionOneDayName; } set {  sessionOneDayName = value; } }
        public string SessionTwoDayName { get { return sessionTwoDayName; } set { sessionTwoDayName = value; } }
        public string Status { get { return status; } set { status = value; } }
        public TrainerModel TrainerModel { get {  return trainerModel; } set {  trainerModel = value; } }
    }
}
