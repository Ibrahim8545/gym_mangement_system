using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class TrainerService
    {
        public List<TrainerModel> Search(string search, bool includePicture, bool byId = false, bool byFName = false, bool bySName = false, bool byFulName = false)
        {
            try
            {
                List<TrainerModel> trainerModels = new List<TrainerModel>();
                string query = "";

                if (byId && int.TryParse(search, out int id))
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM trainer WHERE id = {id}";
                }
                else if (byFName || bySName)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM trainer WHERE first_name = '{search}' OR second_name = '{search}'";
                }
                else if (byFulName)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM trainer WHERE CONCAT(first_name , ' ' , second_name) = '{search}'";
                }
                if (query == "")
                {
                    Console.WriteLine($"Error getting from trainer search by Id or Username: No selected search tybe");
                    return null;
                }
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TrainerModel tm = new TrainerModel(id: Convert.ToInt32(reader["id"]), firstName: reader["first_name"].ToString(), secondName: reader["second_name"].ToString(), brithday: Convert.ToDateTime(reader["brithday"]), gender: reader["gender"].ToString(), email: reader["email"].ToString(), phoneNumber: reader["phone_number"].ToString(), specialization: reader["specialization"].ToString(), privateLessonPrice: Convert.ToInt32(reader["private_lesson_price"]), status: Convert.ToBoolean(reader["status"]));
                        if (includePicture)
                        {
                            tm.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                            tm.Base64Image = reader["picture"].ToString();
                        }
                        trainerModels.Add(tm);
                    }

                    return trainerModels;
                }
                else
                {
                    Console.WriteLine($"Error getting from trainer search by Id or Username: No records found for the specified ID or Username '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql trainer search by Id or Username: {ex.Message}");
                return null;
            }
        }

        public bool addTrainer(TrainerModel trainerModel)
        {
            try
            {
                int id = trainerModel.generateId();
                string query = $"INSERT INTO trainer (id, first_name, second_name, brithday, gender, picture, email, phone_number, specialization, private_lesson_price) VALUES " +
                               $"('{id}', '{trainerModel.FirstName}', '{trainerModel.SecondName}', '{trainerModel.Brithday.ToString("yyyy-MM-dd")}', " +
                               $"'{trainerModel.Gender}', '{trainerModel.Base64Image}', " +
                               $"'{trainerModel.Email}', '{trainerModel.PhoneNumber}', '{trainerModel.Specialization}', '{trainerModel.PrivateLessonPrice}', '{trainerModel.Status}'";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("trainer created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error add trainer: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error add trainer in MySql: {ex.Message}");
                return false;
            }
        }

        public bool updateTrainerAttributes(TrainerModel trainerModel, bool firstName = false, bool secondName = false, bool gender = false, bool brithday = false, bool email = false, bool phoneNumber = false, bool pictur = false, bool specialization = false, bool privateLessonPrice = false, bool status = false)
        {
            try
            {
                string query = "UPDATE trainer SET";
                if (firstName)
                {
                    query += $" first_name = '{trainerModel.FirstName}',";
                }
                if (secondName)
                {
                    query += $" second_name = '{trainerModel.SecondName}',";
                }
                if (gender)
                {
                    query += $" gender = '{trainerModel.Gender}',";
                }
                if (brithday)
                {
                    query += $" brithday = '{trainerModel.Brithday}',";
                }
                if (email)
                {
                    query += $" email = '{trainerModel.Email}',";
                }
                if (phoneNumber)
                {
                    query += $" phone_number = '{trainerModel.PhoneNumber}',";
                }
                if (pictur)
                {
                    query += $" picture = '{trainerModel.Base64Image}',";
                }
                if (specialization)
                {
                    query += $" specialization = '{trainerModel.Specialization}',";
                }
                if (privateLessonPrice)
                {
                    query += $" private_lesson_price = {trainerModel.PrivateLessonPrice},";
                }
                if (status)
                {
                    query += $" status = {trainerModel.Status},";
                }
                if (query == $"UPDATE trainer SET")
                {
                    Console.WriteLine($"Error updating trainer attributes: No selected data modfied");
                    return false;
                }
                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {trainerModel.Id}";
                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"trainer attributes updated successfully for ID: {trainerModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating trainer attributes: No rows affected for ID: {trainerModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating trainer attributes in MySql: {ex.Message}");
                return false;
            }
        }

        public List<TrainerModel> getAllTrainer(bool status, bool includePicture)
        {
            try
            {
                List<TrainerModel> trainerModels = new List<TrainerModel>();
                string query;
                if (status)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM trainer WHERE status = 1";
                }
                else
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM trainer";
                }
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TrainerModel tm = new TrainerModel(id: Convert.ToInt32(reader["id"]), firstName: reader["first_name"].ToString(), secondName: reader["second_name"].ToString(), brithday: Convert.ToDateTime(reader["brithday"]), gender: reader["gender"].ToString(), email: reader["email"].ToString(), phoneNumber: reader["phone_number"].ToString(), specialization: reader["specialization"].ToString(), privateLessonPrice: Convert.ToInt32(reader["private_lesson_price"]), status: Convert.ToBoolean(reader["status"]));
                        if (includePicture)
                        {
                            tm.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                            tm.Base64Image = reader["picture"].ToString();
                        }
                        trainerModels.Add(tm);
                    }
                    return trainerModels;
                }
                else
                {
                    Console.WriteLine("Error getting from getAllTrainer: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql getAllTrainer: {ex.Message}");
                return null;
            }
        }

        public int getLastId()
        {
            try
            {
                int id = 0;
                string query = "SELECT id FROM trainer ORDER BY id DESC LIMIT 1";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    reader.Read();
                    id = Convert.ToInt32(reader["id"]);
                    return id;
                }
                else
                {
                    Console.WriteLine("Error getting from getLastId of trainer: No last id found");
                    return id;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql getLastId of trainer: {ex.Message}");
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
                return "id, first_name, second_name, brithday, gender, email, phone_number, specialization, private_lesson_price, status";
            }
        }
    }
}
