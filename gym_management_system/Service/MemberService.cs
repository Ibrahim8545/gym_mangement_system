using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class MemberService
    {
        public List<MemberModel> Search(string search, bool includePicture, bool byId = false, bool byFName = false, bool bySName = false, bool byFulName = false)
        {
            try
            {
                List<MemberModel> memberModels = new List<MemberModel>();
                string query = "";
                if (byId && int.TryParse(search, out int id))
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM member WHERE id = {id}";
                }
                else if (byFName || bySName)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM member WHERE first_name = '{search}' OR second_name = '{search}'";
                }
                else if (byFulName)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM member WHERE CONCAT(first_name , ' ' , second_name) = '{search}'";
                }
                if (query == "")
                {
                    Console.WriteLine($"Error getting from Member search: No selected search tybe");
                    return null;
                }
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MemberModel mm = new MemberModel(id: Convert.ToInt32(reader["id"]), firstName: reader["first_name"].ToString(), secondName: reader["second_name"].ToString(), brithday: Convert.ToDateTime(reader["brithday"]), gender: reader["gender"].ToString(), email: reader["email"].ToString(), phoneNumber: reader["phone_number"].ToString(), attendanceCount: Convert.ToInt32(reader["attendance_count"]));
                        if (includePicture)
                        {
                            mm.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                            mm.Base64Image = reader["picture"].ToString();
                        }
                        memberModels.Add(mm);
                    }

                    return memberModels;
                }
                else
                {
                    Console.WriteLine($"Error getting from Member search: No records found for '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql Member search: {ex.Message}");
                return null;
            }
        }
        public List<MemberModel> getAllMember(bool includePicture = false)
        {
            try
            {
                List<MemberModel> memberModels = new List<MemberModel>();
                string query = $"SELECT {GetSelectColumns(includePicture)} FROM member";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MemberModel mm = new MemberModel(id: Convert.ToInt32(reader["id"]), firstName: reader["first_name"].ToString(), secondName: reader["second_name"].ToString(), brithday: Convert.ToDateTime(reader["brithday"]), gender: reader["gender"].ToString(), email: reader["email"].ToString(), phoneNumber: reader["phone_number"].ToString(), attendanceCount: Convert.ToInt32(reader["attendance_count"]));
                        if (includePicture)
                        {
                            mm.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                        }
                        memberModels.Add(mm);
                    }

                    return memberModels;
                }
                else
                {
                    Console.WriteLine("Error getting from getAllEmployee: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql getAllEmployee: {ex.Message}");
                return null;
            }
        }

        public bool addMember(MemberModel memberModel)
        {
            try
            {
                int id = memberModel.generateId();
                string query = $"INSERT INTO member (id, first_name, second_name, brithday, gender, picture, email, phone_number, attendance_count) VALUES " +
                               $"('{id}', '{memberModel.FirstName}', '{memberModel.SecondName}', '{memberModel.Brithday.ToString("yyyy-MM-dd")}', " +
                               $"'{memberModel.Gender}', '{memberModel.Base64Image}', " +
                               $"'{memberModel.Email}', '{memberModel.PhoneNumber}', {memberModel.AttendanceCount})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Member created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error add Member: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error add Member in MySql: {ex.Message}");
                return false;
            }
        }

        public bool UpdateMemberAttributes(MemberModel memberModel, bool firstName = false, bool secondName = false, bool gender = false, bool brithday = false, bool email = false, bool phoneNumber = false, bool attendanceCount = false, bool pictur = false)
        {
            try
            {
                string query = "UPDATE member SET";
                if (firstName)
                {
                    query += $" first_name = '{memberModel.FirstName}',";
                }
                if (secondName)
                {
                    query += $" second_name = '{memberModel.SecondName}',";
                }
                if (gender)
                {
                    query += $"gender = '{memberModel.Gender}',";
                }
                if (brithday)
                {
                    query += $"brithday = '{memberModel.Brithday}',";
                }
                if (email)
                {
                    query += $"email = '{memberModel.Email}',";
                }
                if (phoneNumber)
                {
                    query += $"phone_number = '{memberModel.PhoneNumber}',";
                }
                if (pictur)
                {
                    query += $"picture = '{memberModel.Base64Image}',";
                }
                if (attendanceCount)
                {
                    query += $"attendance_count = {memberModel.AttendanceCount},";
                }
                if (query == $"UPDATE member SET")
                {
                    Console.WriteLine($"Error updating member status attributes: No selected data modfied");
                    return false;
                }
                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {memberModel.Id}";
                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"member attributes updated successfully for ID: {memberModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating member attributes: No rows affected for ID: {memberModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating member attributes in MySql: {ex.Message}");
                return false;
            }
        }

        public int getLastId()
        {
            try
            {
                int id = 0;
                string query = "SELECT id FROM member ORDER BY id DESC LIMIT 1";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    reader.Read();
                    id = Convert.ToInt32(reader["id"]);
                    return id;
                }
                else
                {
                    Console.WriteLine("Error getting from getLastId of member: No last id found");
                    return id;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql getLastId of member: {ex.Message}");
                return -1;
            }
        }
        private string GetSelectColumns(bool includePicture)
        {
            if (includePicture)
            {
                return "*";
            }
            else
            {
                return "id, first_name, second_name, brithday, gender, email, phone_number, attendance_count";
            }
        }
    }
}
