using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class TrainerEmailModel : EmailModel
    {
        private TrainerModel trainerModel;

        public TrainerEmailModel(int id = 0, string subject = null, DateTime date = default, TrainerModel trainerModel = null, EmployeeModel employeeModel = null) : base(id, subject, date, employeeModel)
        {
            TrainerModel = trainerModel;
        }

        public TrainerModel TrainerModel { get { return trainerModel; } set { trainerModel = value; } }

        public override PersonModel getreciverData()
        {
            List<TrainerModel> trainerModels = Global.trainerService.Search(trainerModel.Id.ToString(), false, byId: false);
            if (trainerModels != null)
            {
                trainerModel = trainerModels[0];
                return trainerModel;
            }
            else
            {
                Console.WriteLine("Error getting from getMemberData in TrainerEmail Model: no trainer found");
                return null;
            }
        }
        public string createTrainerEmail(TrainerModel trainerModel)
        {
            body = $"Hi {trainerModel.FirstName} {trainerModel.SecondName}\n\n" +
                $"Welcome to the PulseUp Gym team! We are excited to have you on board as a new member of our staff. Your dedication and expertise as a {trainerModel.Specialization} will undoubtedly contribute to the success of our gym.\n\n" +
                $"Here are the details of your trainer profile:\n\n" +
                $"ID: {trainerModel.Id}\n" +
                $"Name: {trainerModel.FirstName} {trainerModel.SecondName}\n" +
                $"Email: {trainerModel.Email}\n" +
                $"Phone: {trainerModel.PhoneNumber}\n" +
                $"Specialization: {trainerModel.Specialization}\n" +
                $"Private Lesson Price: {trainerModel.PrivateLessonPrice}\n\n" +
                $"Contact Information:\n" +
                $"Phone: 01xxxxxxxxxx\n" +
                $"Email: pulseupgym@gmail.com\n\n" +
                $"We are thrilled to have you join the PulseUp Gym family and look forward to working together to provide exceptional fitness experiences for our members.\n\nBest regards,\nPulseUp Gym";
            return body;
        }

        public string updateTrainerEmail(TrainerModel updatedTrainer)
        {
            body = $"Hi {updatedTrainer.FirstName} {updatedTrainer.SecondName}\n\n" +
                $"We hope this message finds you well. This is to inform you that your trainer information has been updated in our system. Thank you for keeping your details current.\n\n" +
                $"Here are the updated details of your trainer profile:\n\n" +
                $"ID: {updatedTrainer.Id}\n" +
                $"Name: {updatedTrainer.FirstName} {updatedTrainer.SecondName}\n" +
                $"Email: {updatedTrainer.Email}\n" +
                $"Phone: {updatedTrainer.PhoneNumber}\n" +
                $"Specialization: {updatedTrainer.Specialization}\n" +
                $"Private Lesson Price: {updatedTrainer.PrivateLessonPrice}\n\n" +
                $"Contact Information:\n" +
                $"Phone: 01xxxxxxxxxx\n" +
                $"Email: pulseupgym@gmail.com\n\n" +
                $"If you have any questions or notice any discrepancies, please contact our HR department at hr@pulseupgym.com.\n\n" +
                $"Thank you for being a valuable member of the PulseUp Gym team!\n\nBest regards,\nPulseUp Gym";
            return body;
        }

        public string sendMessageToTrainer(TrainerModel trainer, string message)
        {
            body = $"Hi {trainer.FirstName} {trainer.SecondName}\n\n" +
                $"We hope this message finds you well. +{message}\n\n" +
                $"Here are some details related to your profile:\n\n" +
                $"ID: {trainer.Id}\n" +
                $"Name: {trainer.FirstName} {trainer.SecondName}\n" +
                $"Email: {trainer.Email}\n" +
                $"Phone: {trainer.PhoneNumber}\n" +
                $"Specialization: {trainer.Specialization}\n" +
                $"Private Lesson Price: {trainer.PrivateLessonPrice}\n\n" +
                $"If you have any questions or concerns, please don't hesitate to reach out to us. Your contributions as a {trainer.Specialization} are integral to the success of our gym, and we are grateful to have you on our team.\n\n" +
                $"Thank you for your continued efforts!\n\nBest regards,\nPulseUp Gym";
            return body;
        }

    }
}
