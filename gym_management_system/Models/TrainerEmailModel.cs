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
    }
}
