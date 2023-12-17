using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class TrainerAttendanceModel : AttendanceModel
    {
        private TrainerModel trainerModel;

        public TrainerAttendanceModel(int id = 0, DateTime date = default, TrainerModel trainerModel = null) : base(id, date)
        {
            TrainerModel = trainerModel;
        }

        public TrainerModel TrainerModel { get { return trainerModel; }  set { trainerModel = value; } }

        public TrainerModel getTrainerData()
        {
            List<TrainerModel> trainerModels = Global.trainerService.Search(trainerModel.Id.ToString(), false, byId: false);
            if (trainerModel != null)
            {
                trainerModel = trainerModels[0];
                return trainerModel;
            }
            else
            {
                Console.WriteLine("Error getting from getTrainerData in TrainerAttendance model: no trainer found");
                return null;
            }
        }
    }
}
