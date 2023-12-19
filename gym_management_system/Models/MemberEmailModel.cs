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

        public string createEmployeeEmail()
        {
            body = $"Hi {memberModel.Name}\n\n" +
                $"Welcome to PulseUp Gym! We are thrilled to have you as a new member of our fitness community. Congratulations on taking the first step towards achieving your health and fitness goals.\n\n" +
                $"Here are the details of your member profile:\n\n" +
                $"ID: {memberModel.Id}\n" +
                $"Name: {memberModel.Name}\n" +
                $"Email: {memberModel.Email}\n" +
                $"Phone: {memberModel.PhoneNumber}\n\n" +
                $"Contact Information:\n" +
                $"Phone: 01xxxxxxxxxx\n" +
                $"Email: pulseupgym@gmail.com\n\n" +
                $"We have a variety of state-of-the-art equipment, experienced trainers, and a supportive environment to help you on your fitness journey. Whether you're a beginner or an experienced fitness enthusiast, PulseUp Gym is here to cater to your needs.\n"+
                $"We look forward to seeing you at PulseUp Gym and being a part of your fitness success!\n\n"+
                $"Best regards,"+
                $"PulseUp Gym";
            return body;
        }

        public string updateMemberInformationEmail(MemberModel updatedMember)
        {
            body = $"Hi {updatedMember.Name}\n\n" +
                $"We hope this email finds you well. We wanted to inform you that your member information at PulseUp Gym has been updated successfully. Thank you for keeping your details current!\n\n" +
                $"Here are the updated details of your member profile:\n\n" +
                $"ID: {updatedMember.Id}\n" +
                $"Name: {updatedMember.Name}\n" +
                $"Email: {updatedMember.Email}\n" +
                $"Phone: {updatedMember.PhoneNumber}\n\n" +
                $"Contact Information:\n" +
                $"Phone: 01xxxxxxxxxx\n" +
                $"Email: pulseupgym@gmail.com\n\n" +
                $"If you have any questions or concerns regarding your updated information, please feel free to contact us. We are here to assist you.\n" +
                $"Thank you for being a valued member of PulseUp Gym!\n\n" +
                $"Best regards," +
                $"PulseUp Gym";
            return body;
        }

        public string sendMessageToMember(MemberModel member, string message)
        {
            body = $"Hi {member.Name}\n\n" +
                $"We hope this message finds you well. {message}\n\n" +
                $"Here are the details of your member profile:\n\n" +
                $"ID: {member.Id}\n" +
                $"Name: {member.Name}\n" +
                $"Email: {member.Email}\n" +
                $"Phone: {member.PhoneNumber}\n\n" +
                $"Contact Information:\n" +
                $"Phone: 01xxxxxxxxxx\n" +
                $"Email: pulseupgym@gmail.com\n\n" +
                $"Whether you have questions about your membership, need assistance with your fitness routine, or have any other inquiries, our team is here to help. Feel free to reach out to us at any time.\n" +
                $"Thank you for being a part of the PulseUp Gym community. We appreciate your commitment to your health and fitness goals!\n\n" +
                $"Best regards," +
                $"PulseUp Gym";
            return body;
        }


    }
}
