using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class MemberEmailModel : EmailModel
    {
        private MemberModel memberModel;

        public MemberEmailModel(int id = 0, string subject = null, DateTime date = default, MemberModel memberModel = null, EmployeeModel employeeModel = null) : base(id,subject,date,employeeModel)
        {
            MemberModel = memberModel;
        }

        public MemberModel MemberModel { get {  return memberModel; } set {  memberModel = value; } }

        public override PersonModel getreciverData()
        {
            List<MemberModel> memberModels = Global.memberService.Search(memberModel.Id.ToString(), false, byId: false);
            if (memberModels != null)
            {
                memberModel = memberModels[0];
                return memberModel;
            }
            else
            {
                Console.WriteLine("Error getting from getMemberData in MemberEmail Model: no member found");
                return null;
            }
        }
    }
}
