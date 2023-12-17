using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class MemberAttendanceModel : AttendanceModel
    {
        private MemberModel memberModel;

        public MemberAttendanceModel(int id = 0, DateTime date = default, MemberModel memberModel = null) : base(id, date)
        {
            MemberModel = memberModel;
        }

        public MemberModel MemberModel { get => memberModel; set => memberModel = value; }

        public MemberModel getMemberData()
        {
            List<MemberModel> memberModels = Global.memberService.Search(memberModel.Id.ToString(), false, byId: false);
            if (memberModels != null)
            {
                memberModel = memberModels[0];
                return memberModel;
            }
            else
            {
                Console.WriteLine("Error getting from getMemberData in MemberAttendance Model: no member found");
                return null;
            }
        }
    }
}
