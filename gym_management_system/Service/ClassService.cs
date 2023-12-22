using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class ClassService
    {
        public List<ClassModel> Search(string search, bool byId = false, bool byName = false)
        {
            try
            {
                List<ClassModel> classModels = new List<ClassModel>();
                string query = "";

                if (byId && int.TryParse(search, out int id))
                {
                    query = $"SELECT c.*, t.first_name AS trainerFirstName, t.second_name AS trainerSecondName " +
                            $"FROM class c " +
                            $"INNER JOIN trainer t ON c.trainerID = t.id " +
                            $"WHERE c.id = {id}";
                }
                else if (byName)
                {
                    query = $"SELECT c.*, t.first_name AS trainerFirstName, t.second_name AS trainerSecondName " +
                            $"FROM class c " +
                            $"INNER JOIN trainer t ON c.trainerID = t.id " +
                            $"WHERE c.name LIKE '%{search}%'";
                }

                if (query == "")
                {
                    Console.WriteLine("Error getting from Class search: No selected search type");
                    return null;
                }

                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassModel classModel = new ClassModel(
                            id: Convert.ToInt32(reader["id"]),
                            name: reader["name"].ToString(),
                            enrollmentNumber: Convert.ToInt32(reader["enrollment_num"]),
                            maxEnrollmentNumber: Convert.ToInt32(reader["max_enrollment_num"]),
                            price: Convert.ToInt32(reader["price"]),
                            sessionOneDayName: reader["s1_day_name"].ToString(),
                            sessionTwoDayName: reader["s2_day_name"].ToString(),
                            status: Convert.ToBoolean(reader["status"].ToString()),
                            trainerModel: new TrainerModel
                            {
                                Id = Convert.ToInt32(reader["trainerID"]),
                                FirstName = reader["trainerFirstName"].ToString(),
                                SecondName = reader["trainerSecondName"].ToString()
                            }
                        );

                        classModels.Add(classModel);
                    }

                    return classModels;
                }
                else
                {
                    Console.WriteLine($"Error getting from Class search: No records found for '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql Class search: {ex.Message}");
                return null;
            }
        }

        public bool GetNumberOfClassesPerDay(string dayName)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM class WHERE s1_day_name = '{dayName}' OR s2_day_name = '{dayName}'";
                int count = Global.sqlService.sqlExecuteScalar(query);
                return count >= 3;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting number of classes per day in MySql: {ex.Message}");
                return true;
            }
        }

        public List<ClassModel> GetAllClasses(bool includeOnlyActive = false, bool onlyAvailable = false)
        {
            try
            {
                List<ClassModel> classModels = new List<ClassModel>();
                string statusFilter;
                if (onlyAvailable)
                {
                    statusFilter = includeOnlyActive ? "WHERE c.status = '1' AND c.enrollment_num != c.max_enrollment_num AND t.status = '1'" : "";
                }
                else
                {
                    statusFilter = includeOnlyActive ? "WHERE c.status = '1' AND t.status = '1'" : "";
                }

                string query = $"SELECT c.*, t.* FROM class c " +
                               $"LEFT JOIN trainer t ON c.trainerID = t.id {statusFilter}";

                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();
                        int enrollmentNumber = Convert.ToInt32(reader["enrollment_num"]);
                        int maxEnrollmentNumber = Convert.ToInt32(reader["max_enrollment_num"]);
                        int price = Convert.ToInt32(reader["price"]);
                        string sessionOneDayName = reader["s1_day_name"].ToString();
                        string sessionTwoDayName = reader["s2_day_name"].ToString();
                        bool status = Convert.ToBoolean(reader["status"]);
                        int trainerID = Convert.ToInt32(reader["trainerID"]);

                        // Check if trainer status is 1
                        if (Convert.ToBoolean(reader["status"]))
                        {
                            // Read TrainerModel properties
                            string firstName = reader["first_name"].ToString();
                            string secondName = reader["second_name"].ToString();
                            string gender = reader["gender"].ToString();
                            DateTime birthday = Convert.ToDateTime(reader["brithday"]);
                            string specialization = reader["specialization"].ToString();
                            int privateLessonPrice = Convert.ToInt32(reader["private_lesson_price"]);
                            bool trainerStatus = Convert.ToBoolean(reader["status"]);

                            TrainerModel trainerModel = new TrainerModel(trainerID, firstName, secondName, gender, null, null, birthday, null, specialization, privateLessonPrice, trainerStatus);

                            ClassModel classModel = new ClassModel(id, enrollmentNumber, maxEnrollmentNumber, price, name, sessionOneDayName, sessionTwoDayName, status, trainerModel);
                            classModels.Add(classModel);
                        }
                    }

                    return classModels;
                }
                else
                {
                    Console.WriteLine("Error getting from GetAllClasses: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql GetAllClasses: {ex.Message}");
                return null;
            }
        }

        public List<ClassModel> GetUnsubscribedClasses(int memberId, bool includeOnlyActive = false, bool onlyAvailable = false)
        {
            try
            {
                List<ClassModel> classModels = new List<ClassModel>();
                string statusFilter;
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string dateFilter = $"AND DATE_ADD(start_date, INTERVAL 1 MONTH) >= '{currentDate}'";

                if (onlyAvailable)
                {
                    statusFilter = includeOnlyActive ? "WHERE c.status = '1' AND c.enrollment_num != c.max_enrollment_num AND t.status = '1'" : "";
                }
                else
                {
                    statusFilter = includeOnlyActive ? "WHERE c.status = '1' AND t.status = '1'" : "";
                }

                string query = $"SELECT c.*, t.*, cs.memberID, cs.start_date " +
                               $"FROM class c " +
                               $"LEFT JOIN trainer t ON c.trainerID = t.id " +
                               $"LEFT JOIN class_subscription cs ON c.id = cs.classID AND cs.memberID = {memberId} {dateFilter} " +
                               $"{statusFilter}";

                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();
                        int enrollmentNumber = Convert.ToInt32(reader["enrollment_num"]);
                        int maxEnrollmentNumber = Convert.ToInt32(reader["max_enrollment_num"]);
                        int price = Convert.ToInt32(reader["price"]);
                        string sessionOneDayName = reader["s1_day_name"].ToString();
                        string sessionTwoDayName = reader["s2_day_name"].ToString();
                        bool status = Convert.ToBoolean(reader["status"]);
                        int trainerID = Convert.ToInt32(reader["trainerID"]);

                        // Check if class is not subscribed by the member
                        int classMemberID = reader["memberID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["memberID"]);

                        if (classMemberID == 0)
                        {
                            // Read TrainerModel properties
                            string firstName = reader["first_name"].ToString();
                            string secondName = reader["second_name"].ToString();
                            string gender = reader["gender"].ToString();
                            DateTime birthday = Convert.ToDateTime(reader["brithday"]);
                            string specialization = reader["specialization"].ToString();
                            int privateLessonPrice = Convert.ToInt32(reader["private_lesson_price"]);
                            bool trainerStatus = Convert.ToBoolean(reader["status"]);

                            TrainerModel trainerModel = new TrainerModel(trainerID, firstName, secondName, gender, null, null, birthday, null, specialization, privateLessonPrice, trainerStatus);

                            ClassModel classModel = new ClassModel(id, enrollmentNumber, maxEnrollmentNumber, price, name, sessionOneDayName, sessionTwoDayName, status, trainerModel);
                            classModels.Add(classModel);
                        }
                    }

                    return classModels;
                }
                else
                {
                    Console.WriteLine("Error getting from GetUnsubscribedClasses: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql GetUnsubscribedClasses: {ex.Message}");
                return null;
            }
        }


        public bool UpdateClassAttributes(ClassModel classModel, bool name = false, bool enrollmentNumber = false, bool maxEnrollmentNumber = false, bool price = false, bool sessionOneDayName = false, bool sessionTwoDayName = false, bool status = false, bool trainer = false)
        {
            try
            {
                string query = "UPDATE class SET";

                if (name)
                {
                    query += $" name = '{classModel.Name}',";
                }
                if (enrollmentNumber)
                {
                    query += $" enrollment_num = {classModel.EnrollmentNumber},";
                }
                if (maxEnrollmentNumber)
                {
                    query += $" max_enrollment_num = {classModel.MaxEnrollmentNumber},";
                }
                if (price)
                {
                    query += $" price = {classModel.Price},";
                }
                if (sessionOneDayName)
                {
                    query += $" s1_day_name = '{classModel.SessionOneDayName}',";
                }
                if (sessionTwoDayName)
                {
                    query += $" s2_day_name = '{classModel.SessionTwoDayName}',";
                }
                if (status)
                {
                    query += $" status = '{classModel.Status}',";
                }
                if (trainer)
                {
                    query += $" trainerID = {classModel.TrainerModel.Id},";
                }

                if (query == $"UPDATE class SET")
                {
                    Console.WriteLine($"Error updating class attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {classModel.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Class attributes updated successfully for ID: {classModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating class attributes: No rows affected for ID: {classModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating class attributes in MySql: {ex.Message}");
                return false;
            }
        }

        public bool AddClass(ClassModel classModel)
        {
            try
            {
                string query = $"INSERT INTO class (name, enrollment_num, max_enrollment_num, price, s1_day_name, s2_day_name, trainerID, status) VALUES " +
                               $"('{classModel.Name}', '{classModel.EnrollmentNumber}', '{classModel.MaxEnrollmentNumber}', " +
                               $"'{classModel.Price}', '{classModel.SessionOneDayName}', '{classModel.SessionTwoDayName}', '{classModel.TrainerModel.Id}', '{classModel.Status}')";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Class created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding class: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding class in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
